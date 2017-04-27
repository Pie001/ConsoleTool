using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICSharpCode.SharpZipLib.Zip;

namespace ConsoleTool.Services
{
    class Compress : BaseService
    {
        string password;

        public Compress(string[] args, Result result)
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
                string zipFileName = @"C:\doc1234.zip";
                string sourceDirectory = @"C:\doc";
                //subdirectory ok
                bool recurse = true;

                FastZip fastZip = new FastZip();
                //EmptyDirectories
                fastZip.CreateEmptyDirectories = false;
                //Zip64
                fastZip.UseZip64 = UseZip64.Dynamic;

                if (!string.IsNullOrEmpty(password))
                {
                    fastZip.Password = password;
                }

                fastZip.CreateZip(zipFileName, sourceDirectory, recurse, null, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }
}
