using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ReleaseVersionInfo
{
    public static class ReleaseInfo
    {
        public static SortableBindingList<FilePackageInfo> GetDirectoryInfo(RequestInfo request)
        {
            var filePackages = new List<FilePackageInfo>();
            var dir = new DirectoryInfo(request.FilePath);
            if (dir.Exists)
            {
                var search = request.IncludeSubDir ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;

                var files = dir.GetFiles("*.*", search);
                foreach (FileInfo file in files)
                {
                    if (file.Extension.ToLower() == ".dll" && request.Extentions.Contains(".dll"))
                    {
                        var versionInfo = FileVersionInfo.GetVersionInfo(file.FullName);
                        var fpi = new FilePackageInfo(file, versionInfo);
                        filePackages.Add(fpi);
                    }
                    else if (file.Extension.ToLower() == ".js" && request.Extentions.Contains(".js"))
                    {
                        var addlInfo = GetCommentInfo(file.FullName);
                        var fpi = new FilePackageInfo(file, addlInfo);
                        filePackages.Add(fpi);
                    }
                }
                filePackages.Sort();
            }

            return new SortableBindingList<FilePackageInfo>(filePackages);
        }

        public static bool ExportCsvFile(DataGridView gridIn, string outputFile)
        {
            var results = false;
            //test to see if the DataGridView has any rows
            if (gridIn.RowCount > 0)
            {
                using (var fileWriter = new StreamWriter(outputFile, false))
                {
                    var headers = gridIn.Columns.Cast<DataGridViewColumn>();
                    fileWriter.WriteLine(string.Join(",",
                        headers.Select(column => "\"" + column.HeaderText + "\"").ToArray()));

                    foreach (DataGridViewRow row in gridIn.Rows)
                    {
                        var cells = row.Cells.Cast<DataGridViewCell>();
                        fileWriter.WriteLine(string.Join(",",
                            cells.Select(cell => "\"" + cell.Value + "\"").ToArray()));
                    }

                    results = true;
                }
            }
            return results;
        }

        private static AdditionalInfo GetCommentInfo(string filePath)
        {
            var BufferSize = 128;
            var addlInfo = new AdditionalInfo();
            using (var fileStream = File.OpenRead(filePath))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                {
                    var r = new char[1024]; 
                    var read = streamReader.ReadBlock(r,0, 1024);
                    var toptext = new string(r);

                    // look for Version
                    var regex = new Regex(@"(?<=v)\d+\.\d+\.\d+");
                    var match = regex.Match(toptext);
                    if (match.Success) { addlInfo.FileVersion = match.Value;}
                    else
                    {
                        regex = new Regex(@"(?<=\s)\d+\.\d+\.\d+");
                        match = regex.Match(toptext);
                        if (match.Success) { addlInfo.FileVersion = match.Value; }
                    }
                    // look for Copyright
                    regex = new Regex(@"Copyright [\w\s\-\.\,]+");
                    match = regex.Match(toptext);
                    if (match.Success) { addlInfo.LegalCopyright = match.Value; }
                    else
                    {
                        regex = new Regex(@"\(c\) [\w\s\-\.\,]+");
                        match = regex.Match(toptext);
                        if (match.Success) { addlInfo.LegalCopyright = match.Value; }
                    }
                }
            }


            return addlInfo;
        }
    }

    public struct AdditionalInfo
    {
        public AdditionalInfo(string version = "", string name = "", string copyright = "")
        {
            FileVersion = version;
            CompanyName = name;
            LegalCopyright = copyright;
        }
        public string FileVersion { get;  set; }
        public string CompanyName { get;  set; }
        public string LegalCopyright { get;  set; }
    }

    public struct FilePackageInfo :IComparable
    {
        public FilePackageInfo(FileInfo file, AdditionalInfo version)
        {
            FileName = file.Name;
            FileSize = file.Length;
            Path = file.Directory.FullName;
            IsReadOnly = file.IsReadOnly;
            Version = version.FileVersion;
            CompanyName = version.CompanyName;
            Copyright = version.LegalCopyright;
        }

        public FilePackageInfo(FileInfo file, FileVersionInfo version)
        {
            FileName = file.Name;
            FileSize = file.Length;
            Path = file.Directory.FullName;
            IsReadOnly = file.IsReadOnly;
            Version = version.FileVersion;
            CompanyName = version.CompanyName;
            Copyright = version.LegalCopyright;
        }

        public string FileName { get; private set; }
        public string Path { get; private set; }
        public bool IsReadOnly { get; private set; }
        public string Version { get; private set; }
        public string CompanyName { get; private set; }
        public string Copyright { get; private set; }

        public string Size
        {
            get
            {
                if (FileSize < 1024)
                {
                    return $"{FileSize} bytes";
                }

                if (FileSize < 1048576)
                {
                    return $"{Math.Round(FileSize / 1024.0, 1)} KB";
                }

                if (FileSize < 1073741824)
                {
                    return $"{Math.Round(FileSize / 1048576.0, 1)} MB";
                }

                return $"{Math.Round(FileSize / 1073741824.0, 1)} GB";
            }
        }

        private long FileSize { get; set; }

        public int CompareTo(object obj)
        {
            if(obj == null || obj.GetType() != typeof(FilePackageInfo)) { return 1; }

            var compare = this.FileName.CompareTo(((FilePackageInfo)obj).FileName);
            if (compare == 0)
            {
                this.Path.CompareTo(((FilePackageInfo)obj).Path);
            }
            if (compare == 0)
            {
                this.Version?.CompareTo(((FilePackageInfo)obj).Version);
            }
            if (compare == 0)
            {
                this.CompanyName?.CompareTo(((FilePackageInfo)obj).CompanyName);
            }
            if (compare == 0)
            {
                this.Copyright?.CompareTo(((FilePackageInfo)obj).Copyright);
            }
            return compare;
        }
    }

    public struct RequestInfo
    {
        public List<string> Extentions { get; set; }
        public string FilePath { get; set; }
        public bool IncludeSubDir { get; set; }
    }
}

