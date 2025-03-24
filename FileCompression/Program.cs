using compress.Compressor;
using compress.model;

if (args.Length != 3)
{
    Console.WriteLine("Error: Invalid command-line arguments. Unable to compress the file.");
    return;
}

string inputFilePath = args[0];

if (!File.Exists(inputFilePath))
{
    Console.WriteLine($"Error: File '{inputFilePath}' does not exist.");
    return;
}

string compressorType = args[1].ToLower();
string outputFilePath = args[2];

ICompressor? compressor = CompressorFactory.GetCompressor(compressorType);

if (compressor == null)
{
    Console.WriteLine($"Error: Compression method '{compressorType}' is not supported.");
    return;
}

try
{
    compressor.Compress(inputFilePath, outputFilePath);
    Console.WriteLine($"File compressed successfully using {compressorType}!");
}
catch (Exception ex)
{
    Console.WriteLine($"Compression failed: {ex.Message}");
}