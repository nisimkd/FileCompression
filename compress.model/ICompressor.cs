namespace compress.model
{
    public interface ICompressor
    {
        void Compress(string inputFilePath, string outputFilePath);

        string GetName();
    }
}
