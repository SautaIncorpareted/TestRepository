using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOHelper
{
    public class IOHelperNet
    {
        public static string ReadIO(Stream stream)
        {
            List<int> byteList = new List<int>();
            while (true)
            {
                var item = stream.ReadByte();
                if (item == -1)
                {
                    break;
                }
                byteList.Add(item);
            }
            var charList = byteList.Select(x => (char)x);

            return new string(charList.ToArray());
        }
    }
}
