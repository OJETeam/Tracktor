using System;
using System.IO;
using System.Xml.Linq;

namespace Tracktor.Logic
{
    public class XmlSettingsSave : SettingsSave
    {
        public readonly string Path;

        public XmlSettingsSave(string xmlFilePath)
        {
            Path = xmlFilePath;
        }

        public override Settings ReadSettings()
        {
            if (!File.Exists(Path)) //TODO maybe remove check
                return null;

            using FileStream fileStream = new FileStream(Path, FileMode.Open, FileAccess.Read);
            XDocument doc = XDocument.Load(fileStream);
            XElement rootElement = doc.Root;

            Settings settings = new Settings();
            settings.SaveFolder = rootElement.Element(XmlSettingsNames.SaveFolder).Value;
            settings.SaveFilename = rootElement.Element(XmlSettingsNames.SaveFilename).Value;

            return settings;
        }

        public override void SaveSettings(Settings settings)
        {
            using FileStream fileStream = new FileStream(Path, FileMode.Create, FileAccess.Write);
            XDocument doc = new XDocument();
            XElement rootElement = new XElement(XmlSettingsNames.RootElementName);
            doc.Add(rootElement);

            XElement saveFolderNode = new XElement(XmlSettingsNames.SaveFolder) { Value = settings.SaveFolder };
            XElement saveFilenameNode = new XElement(XmlSettingsNames.SaveFilename) { Value = settings.SaveFilename };

            rootElement.Add(saveFolderNode);
            rootElement.Add(saveFilenameNode);

            doc.Save(fileStream);
        }
    }
}