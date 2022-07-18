# ZLIB_decompressor

This app can decompress ZLIB compressed data stored in game resource archive files. 
<br>Do note that the app can only decompress one continuous ZLIB chunk and if you want to decompress all of the chunks in the file, then you have to specify the header start position of the next ZLIB chunk and decompress that separately.

## Instructions
Place the file that has the ZLIB compressed data next to the app and open the app through command prompt with the following commandline arguements:
<br>```ZLIB_decompressor [file.extension] [byte-number] [outputfile.extension]```
<br>
<br>For Example:
<br>```ZLIB_decompressor myfile.bin 60 myfile_decmp.bin```
<br>
<br>
<br>The arguments would contain this app name, the filename with the extension, the byte position number from where the ZLIB chunk starts and the output file name with the extension.  
