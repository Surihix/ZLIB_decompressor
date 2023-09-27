using Ionic.Zlib;
using System;
using System.IO;

namespace ZLIB_decompressor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Check the number of arguements specified by the user 
                // and if its less than 3, then terminate the program
                if (args.Length < 3)
                {
                    Console.WriteLine("Error: Enough arguments not specified");
                    Console.WriteLine("");
                    Console.WriteLine("Specify arguments like this:");
                    Console.WriteLine("ZLIB_decompressor [file.extension] [byte-position] [outputfile.extension]");
                    Console.ReadLine();
                    return;
                }

                // Storing the values specified in each of the arguements as variables
                string inFile = args[0];
                long headerStart = Convert.ToInt64(args[1]);
                string outFile = args[2];

                // Check if the specified in_file in args[0] exists.
                if (!File.Exists(inFile))
                {
                    Console.WriteLine("Error: Specified input file does not exist");
                    Console.ReadLine();
                    return;
                }

                Console.WriteLine("Decompressing....");

                // Open the input file and create the output file specified in
                // arg[0] and arg[2] in two separate filestreams
                using (FileStream inFileStream = new FileStream(inFile, FileMode.Open, FileAccess.Read))
                {
                    if (File.Exists(outFile))
                    {
                        File.Delete(outFile);
                    }

                    using (FileStream outFileStream = new FileStream(outFile, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        // Seek to the specified byte position
                        // from arg[1]
                        inFileStream.Seek(headerStart, SeekOrigin.Begin);

                        // Attach outfileStream to decompressor
                        // and copy the inFileStream into the
                        // decompressor
                        // This will decompress the zlib data and 
                        // the decompressed data will be stored 
                        // inside the specified outFile
                        using (ZlibStream decompressor = new ZlibStream(outFileStream, CompressionMode.Decompress))
                        {
                            inFileStream.CopyTo(decompressor);
                        }
                    }
                }

                Console.WriteLine("Decompressed");
            }
            catch (Exception ex)
            {
                Console.WriteLine("");
                Console.WriteLine("Error: " + ex);
                Console.ReadLine();
                return;
            }
        }
    }
}