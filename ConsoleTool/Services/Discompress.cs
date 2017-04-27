using System;
using System.IO;
using ICSharpCode.SharpZipLib.Zip;

namespace ConsoleTool.Services
{
    class Discompress : BaseService
    {
        string password;

        public Discompress(string[] args, Result result)
        {
            if (args.Length > 1)
            {
                password = args[1];
            }
            this.Result = result;
        }

        public override void Invoke()
        {
            try
            {
                string[] files = Directory.GetFiles(@"C:\temp", "*.zip", SearchOption.AllDirectories);
                
                foreach(var file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);
                    string zipFileName = file;
                    string targetDirectory = @"C:\temp\" + fileInfo.Name.Replace(".zip", "");
                    string fileFilter = "";

                    var fastZip = new FastZip();
                    //Attributes
                    fastZip.RestoreAttributesOnExtract = true;
                    //DateTime
                    fastZip.RestoreDateTimeOnExtract = true;
                    //EmptyDirectories
                    fastZip.CreateEmptyDirectories = true;

                    //Password
                    //Password requied:ZipException
                    if (!string.IsNullOrEmpty(password))
                    {
                        fastZip.Password = password;
                    }

                    fastZip.ExtractZip(zipFileName, targetDirectory, fileFilter);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Invoke2()
        {
            try
            {
                string zipFileName = @"C:\doc1234.zip";
                string targetDirectory = @"C:\";
                string fileFilter = "";

                FastZip fastZip = new FastZip();
                fastZip.Password = password;
                fastZip.ExtractZip(zipFileName, targetDirectory, fileFilter);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
