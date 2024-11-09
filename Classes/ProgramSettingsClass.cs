using Newtonsoft.Json;
using System.IO;


namespace BitCraft.Classes
{
    public class ProgramSettingsClass : AppSettings<ProgramSettingsClass>
    {
        public ProgramSettingsClass() : base()
        {
        }
        public ProgramSettingsClass(string configFile) : base(configFile)
        {
        }

        /// <summary>
        /// Разделитель между ключами, адресами
        /// </summary>
        public string Delimiter { get; set; } = " | ";
        /// <summary>
        ///Файл с базой данных адресов блокчейна
        /// </summary>
        public string AddressDataBaseFile { get; set; } = string.Empty;


    }

    public class AppSettings<T> where T : new()
    {
        public AppSettings(string configFile)
        {
            CONFIG_FILENAME = configFile;
        }
        public AppSettings()
        {

        }
        public static string CONFIG_FILENAME { get; private set; }

        public bool Save(string fileName = "")
        {
            if (fileName == "")
            {

                fileName = CONFIG_FILENAME;
            }
            else
            {
                CONFIG_FILENAME = fileName;
            }

            File.WriteAllText(fileName, JsonConvert.SerializeObject(this));
            return true;
        }

        public static bool Save(T pSettings, string fileName = "")
        {

            if (fileName == "")
            {
                return false;
      
            }
            else
                CONFIG_FILENAME = fileName;

            File.WriteAllText(fileName, JsonConvert.SerializeObject(pSettings));
            return true;
        }

        public static T Load(string fileName)
        {
            T t = new T();
            if (File.Exists(fileName))
            {
                t = JsonConvert.DeserializeObject<T>(File.ReadAllText(fileName));
                CONFIG_FILENAME = fileName;
            }
            return t;
        }
        /// <summary>
        /// Чтобы не сохранять пустышку
        /// </summary>
        public static void EmptyConfigPath()
        {
            CONFIG_FILENAME = null;
        }
    }
}
