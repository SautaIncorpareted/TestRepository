using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using IOHelper;

namespace FTP_Connector
{
    public class FTPConnector
    {
        public Uri uri = null;
        Action<string> ErrLog;
        public FTPConnector(string ip, int port, string password, string userName, Action<string> errLog)
        {
            UriBuilder builder = new UriBuilder("ftp", ip, port) { Password = password, UserName = userName };
            ErrLog = errLog;
            uri = builder.Uri;
        }
        public string ReadFile(string path)
        {
            try
            {
                var localUri = new Uri(uri, path);
                FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(localUri);
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                using (var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse())
                {
                    using (var stream = ftpResponse.GetResponseStream())
                    {
                        using (StreamReader RD = new StreamReader(stream))
                        {
                            var file = RD.ReadToEnd();
                            ftpResponse.Close();
                            return file;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrLog(ex.Message + "\nError file:" + path.Replace("%", @"\%"));
                return string.Empty;
            }
        }
        public string GetFtpPathData(string path)
        {
            while (true)
            {
                try
                {
                    var localUri = new Uri(uri, path);
                    FtpWebRequest ftpRequest = (FtpWebRequest)WebRequest.Create(localUri);
                    ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                    var ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    var stream = ftpResponse.GetResponseStream();
                    StreamReader RD = new StreamReader(stream);
                    var conf = RD.ReadToEnd();
                    ftpResponse.Close();
                    return conf;
                }
                catch (Exception ex)
                {
                    ErrLog("Error:" + ex.Message);
                }
            }
        }
    }
}
