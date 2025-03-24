using compress.model;
using System.Reflection;

namespace compress.Compressor
{
    public static class CompressorFactory
    {
        private static readonly Dictionary<string, ICompressor> _compressors = new();

        static CompressorFactory()
        {
            LoadCompressors();
        }

        private static void LoadCompressors()
        {
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string[] dllFiles = Directory.GetFiles(directory, "*.dll", SearchOption.TopDirectoryOnly);

            foreach (string dll in dllFiles)
            {
                try
                {
                    Assembly assembly = Assembly.LoadFrom(dll);
                    var assemblyTypes = assembly.GetTypes()
                        .Where(assemblyType => typeof(ICompressor).IsAssignableFrom(assemblyType) && !assemblyType.IsInterface);

                    foreach (var assemblyType in assemblyTypes)
                    {
                        if (Activator.CreateInstance(assemblyType) is ICompressor instance)
                        {
                            _compressors[instance.GetName()] = instance;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to load compressors from {dll}: {ex.Message}");
                }
            }
        }

        public static ICompressor? GetCompressor(string type)
        {
            _compressors.TryGetValue(type, out var compressor);
            return compressor;
        }
    }
}
