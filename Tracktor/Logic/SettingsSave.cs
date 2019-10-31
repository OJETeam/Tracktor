namespace Tracktor.Logic
{
    public abstract class SettingsSave
    {
        public abstract Settings ReadSettings();

        public abstract void SaveSettings(Settings settings);
    }
}