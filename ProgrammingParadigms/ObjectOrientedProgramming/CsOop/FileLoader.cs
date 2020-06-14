using System.IO;

namespace CsOop
{
    public class FileLoader : IDataLoader
    {
        private readonly string FilePath;

        public FileLoader(string filePath)
        {
            FilePath = filePath;
        }

        public string LoadData()
        {
            return File.ReadAllText(FilePath);
        }
    }
}
