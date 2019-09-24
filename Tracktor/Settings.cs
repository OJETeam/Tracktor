using System.IO;

namespace Tracktor
{
    public class Settings
    {
        public string SaveFolder;
        public string SaveFilename;

        public string GetSaveFilePath()
        {
            return Path.Combine(SaveFolder, SaveFilename);
        }
    }
}