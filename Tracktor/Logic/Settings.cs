using System.IO;

namespace Tracktor.Logic
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