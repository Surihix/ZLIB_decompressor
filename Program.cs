using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.IO;

namespace ZLIB_decompressor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.WriteLine("No arguments specified");
                Console.ReadLine();
                return;
            }

            string in_file = Convert.ToString(args[0]);
            long header_start = Convert.ToInt64(args[1]);
            string out_file = Convert.ToString(args[2]);

            if (!File.Exists(in_file))
            {
                Console.WriteLine("Input file does not exist");
                Console.ReadLine();
                return;
            }


            FileStream InFileStream = new FileStream(in_file, FileMode.Open, FileAccess.Read);
            FileStream OutFileStream = new FileStream(out_file, FileMode.OpenOrCreate);

            InFileStream.Seek(header_start, SeekOrigin.Begin);

            InflaterInputStream ZLib_decmp = new InflaterInputStream(InFileStream);
            ZLib_decmp.CopyTo(OutFileStream);

        }
    }
}

