using System;
using System.Collections.Generic;
using System.Linq;
using ThirdPartyTools;

namespace FileData
{
    public static class Program
    {
        private static string applicationName = "Program.exe";

        private static string errorMessageParseArgs = "";
        private static string errorMessage01 = "Error: Wrong arguments number.";
        private static string errorMessage02 = "Error: 1rst arguments is wrong. Acceptable values: –v, --v, /v, --version, –s, --s, /s, --size.";

        private static FunctionToCall functionToCall = FunctionToCall.Size;

        public static void Main(string[] args)
        {
            if (Program.ParseArgs(args))
            {
                try
                {
                    FileDetails fileDetails = new FileDetails();

                    if (functionToCall == FunctionToCall.Version)
                    {
                        Console.WriteLine("File Version: " + fileDetails.Version(args[1]));
                    }
                    else
                    {
                        Console.WriteLine("File Size: " + fileDetails.Size(args[1]));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Third party application error: " + ex.Message);
                }
            }
            else
            {
                Console.WriteLine(errorMessageParseArgs);
                Console.WriteLine();
                Program.ShowUsage();
            }
        }

        public static void ShowUsage()
        {
            Console.WriteLine("<Application Owner, Usage License, ...>");
            Console.WriteLine("");
            Console.WriteLine("Application provides functionality to return Version or Size for a specified file. Application uses \"ThirdPartyTools\" for return Version or Size for a specified file.");
            Console.WriteLine("");
            Console.WriteLine("Run:");
            Console.WriteLine(applicationName + " <–v|--v|/v|--version|–s|--s|/s|--size> <filename|filepath>");
            Console.WriteLine("");
            Console.WriteLine("Where:");
            Console.WriteLine("If the first argument is anyone of –v, --v, /v, --version then application returns the version of the file.");
            Console.WriteLine("If the first argument is anyone of –s, --s, /s, --size then application returns the size of the file.");
            Console.WriteLine("");
            Console.WriteLine("Example:");
            Console.WriteLine(applicationName + " –v c:\\test.txt");
            Console.WriteLine(applicationName + " –s c:\\test.txt");
        }

        //Requirements:
        //Takes in two arguments(argument 1 = functionality to perform, argument 2 = filename)
        //If the first argument is anyone of –v, --v, /v, --version then return the version of the file(use FileDetails.Version to get the version number, don’t worry about accessing the file or checking if it exists etc.)
        //If the first argument is anyone of –s, --s, /s, --size the return the size of the file(use FileDetails.Size) 

        public static bool ParseArgs(string[] args)
        {
            bool result = true;

            if (args == null)
            {
                errorMessageParseArgs = errorMessage01;
                return false;
            }

            if (args.Length != 2)
            {
                errorMessageParseArgs = errorMessage01;
                return false;
            }

            if (args[0].ToLower() == "-v"
                || args[0].ToLower() == "--v"
                || args[0].ToLower() == "/v"
                || args[0].ToLower() == "--version")
            {
                Program.functionToCall = FunctionToCall.Version;
            }
            else if (args[0].ToLower() == "-s"
                || args[0].ToLower() == "--s"
                || args[0].ToLower() == "/s"
                || args[0].ToLower() == "--size")
            {
                Program.functionToCall = FunctionToCall.Size;
            }
            else
            {
                errorMessageParseArgs = errorMessage02;
                return false;
            }

            return result;

        }
    }
}
