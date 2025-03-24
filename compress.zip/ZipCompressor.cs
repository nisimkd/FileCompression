using compress.model;

namespace compress.Compressor
{
    public class ZipCompressor : ICompressor
    {
        public void Compress(string inputFilePath, string outputFilePath)
        {
            Console.WriteLine("ZipCompressor compress method running!");
        }

        public string GetName()
        {
            return "zip";
        }
    }
}
