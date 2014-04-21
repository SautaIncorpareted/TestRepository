using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FTP_backaper.FTPTree
{
    public class FTPTreeFactory
    {
        private static Regex regexFtpConfLineParser = new Regex(@"((?<dir>drwxr-xr-x)|(?<file>-rw-r--r--))(?<data>\s+\d+\s+\d+\s+[\w\d]+\s+\d+\s+\w+\s+\d+\s+\d+:\d+\s+)(?<name>.+)", RegexOptions.Compiled);
        public FTPAbstractTreeNode GetTreeNode(string configLine, string globalPath, FTPAbstractTreeNode parent, FTPRootTreeNode root, string localPath)
        {
            var ftpMatch = regexFtpConfLineParser.Match(configLine);

            if (ftpMatch.Groups.Count < 3)
            {
                throw new Exception("flp line can't parsed");
            }

            if (ftpMatch.Groups["dir"].Success && ftpMatch.Groups["name"].Success)
            {
                Console.WriteLine(string.Format("DIR:{0}", globalPath + "/" + ftpMatch.Groups["name"].Value));
                return new FTPDirectoryTreeNode(ftpMatch.Groups["name"].Value.Trim(), globalPath, parent, root, localPath);
            }
            if (ftpMatch.Groups["file"].Success && ftpMatch.Groups["name"].Success)
            {
                Console.WriteLine(string.Format("file:{0}", globalPath + "/" + ftpMatch.Groups["name"].Value));
                return new FTPFileTreeNode(ftpMatch.Groups["name"].Value.Trim(), globalPath, parent, root, localPath);
            }

            throw new Exception("flp line faild parsed");
        }
    }
}
