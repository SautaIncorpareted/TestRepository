using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

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

        public static string GetPathToConfigs()
        {
            var location = Assembly.GetExecutingAssembly().Location;
            var dirName = Path.GetDirectoryName(location);
            var configPath = Path.Combine(dirName, "configs");
            if (!Directory.Exists(configPath))
            {
                Directory.CreateDirectory(configPath);
            }
            return configPath;
        }
        public static void Serialize(object serializibleObject)
        {
            Serialize(serializibleObject, Path.Combine(GetPathToConfigs(), serializibleObject.GetType().Name));
        }

        public static void Serialize(object serializibleObject, string path)
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);
            formatter.Serialize(stream, serializibleObject);
            stream.Close();
        }
        public static T DeSerialize<T>(string path) where T : class, new()
        {
            IFormatter formatter = new BinaryFormatter();
            if (!File.Exists(path))
            {
                Serialize(new T());
            }
            Stream stream = new FileStream(path, FileMode.Open);
            var obj = formatter.Deserialize(stream);
            stream.Close();
            return (T)obj;
        }
        public static T DeSerialize<T>() where T : class, new()
        {
            return DeSerialize<T>(Path.Combine(GetPathToConfigs(), (typeof(T)).Name));
        }
    }
}
