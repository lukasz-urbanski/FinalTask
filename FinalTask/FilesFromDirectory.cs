using System.Collections.Generic;
using System.IO;

namespace FinalTask
{
    static class FilesFromDirectory
    {
        public static List<FileInfo> GetAllFilesFromDirectory(string path)
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            string[]allfiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
            foreach (var files in allfiles)
            {
                fileInfos.Add(new FileInfo(files));
            }
            return fileInfos;
        }
    }
}