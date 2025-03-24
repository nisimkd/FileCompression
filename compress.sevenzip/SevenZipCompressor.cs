using compress.model;

namespace compress.Compressor
{
    public class SevenZipCompressor : ICompressor
    {
        public void Compress(string inputFilePath, string outputFilePath)
        {
            Console.WriteLine("SevenZipCompressor compress method running!");
        }

        public string GetName()
        {
            return "7zip";
        }
    }
}
