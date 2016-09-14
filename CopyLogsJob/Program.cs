using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;

namespace CopyLogsJob
{
    class Program
    {
        static string ReadSetting(string key)
        {
            var appSettings = ConfigurationManager.AppSettings;
            string result = appSettings[key];
            return result;
        }

        static void CopyFiles(string src, string dst)
        {

            if (!Directory.Exists(dst))
            {
                Directory.CreateDirectory(dst);
                Console.WriteLine("Created directory " + dst);
            }


            if (Directory.Exists(src))
            {
                var files = Directory.EnumerateFiles(src);
                foreach (var srcPath in files)
                {
                    string fileName = Path.GetFileName(srcPath);
                    string dstPath = Path.Combine(dst, fileName);
                    if (File.Exists(dstPath))
                    {
                        File.Delete(dstPath);
                    }
                    File.Copy(srcPath, dstPath);
                    Console.WriteLine("Copied " + fileName);
                }
            }
        }
        static void Main(string[] args)
        {
            string sourcePath = ReadSetting("sourcepath");
            Console.Out.WriteLine("sourcepath: " + sourcePath);
            string destPath = ReadSetting("destpath");
            Console.Out.WriteLine("destpath: " + destPath);
            if (null == sourcePath || null == destPath)
            {
                Console.Out.WriteLine("Please configure sourcepath and destpath elements in the app config");
            } else
            {
                try
                {
                    CopyFiles(sourcePath, destPath);
                }
                catch (IOException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }

            
        }
    }
}
