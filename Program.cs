using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.IO;

namespace ZLIB_decompressor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Check the number of arguements specified by the user 
            // and if its less than 3, then terminate the program
            if (args.Length != 3)
            {
                Console.WriteLine("No arguments specified");
                Console.ReadLine();
                return;
            }

            // Storing the values specified in each of the arguements
            // as variables
            string in_file = (args[0]);
            long header_start = Convert.ToInt64(args[1]);
            string out_file = (args[2]);

            // Open the input file and create the output file specified in
            // arg[0] and arg[2] in two separate filestreams
            FileStream InFileStream = new FileStream(in_file, FileMode.Open, FileAccess.Read);
            FileStream OutFileStream = new FileStream(out_file, FileMode.OpenOrCreate);

            // Seek to the byte value specified in arg[1]
            InFileStream.Seek(header_start, SeekOrigin.Begin);

            // Open the input file inside a Inflatter input stream and copy the
            // decompressed zlib data into the output file
            InflaterInputStream ZLib_decmp = new InflaterInputStream(InFileStream);
            ZLib_decmp.CopyTo(OutFileStream);

        }
    }
}

