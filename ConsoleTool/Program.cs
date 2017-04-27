using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTool
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var result = new Result();

            if (args.Length < 1)
            {
                Console.WriteLine("Parameter requied.");
                Environment.Exit(0);
            }

            var executeService = args[0];

            try { 
                Type type = Type.GetType("ConsoleTool.Services." + executeService);

                if (type != null)
                {
                    object target = type.InvokeMember(null, System.Reflection.BindingFlags.CreateInstance, null, null, new object[] { args, result });
                    type.InvokeMember("Invoke", System.Reflection.BindingFlags.InvokeMethod, null, target, null);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }

    public class Result
    {
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }
}
