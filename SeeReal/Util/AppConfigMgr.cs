using System.Configuration;

namespace SeeReal
{
    public class AppConfigMgr
    {
        /// <summary>
        /// App.config 에서 해당 키의 내용을 가져옴
        /// </summary>
        /// <param name="strKey">가져올 키값</param>
        /// <returns>키값의 내용</returns>
        public static string GetAppConfig(string strKey)
        {
            return ConfigurationManager.AppSettings[strKey];
        }

        /// <summary>
        /// App.config 에서 strKey에 strValue 내용을 설정함
        /// </summary>
        /// <param name="strKey">설정할 키값</param>
        /// <param name="strValue">해당 키값에 넣을 데이터</param>
        /// <returns>성공 유무</returns>
        public static bool SetAppConfig(string strKey, string strValue)
        {
            bool bResult;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection configCollection = config.AppSettings.Settings;

            try
            {
                configCollection.Remove(strKey);
                configCollection.Add(strKey, strValue);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

                bResult = true;
            }
            catch
            {
                bResult = false;
            }

            return bResult;
        }

        /// <summary>
        /// App.config 에서 strKey에 strValue 내용을 설정함
        /// </summary>
        /// <param name="strKey">설정할 키값</param>
        /// <param name="nValue">해당 키값에 넣을 데이터</param>
        /// <returns> 유무</returns>
        public static bool SetAppConfig(string strKey, int nValue)
        {
            bool bResult;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection configCollection = config.AppSettings.Settings;

            try
            {
                configCollection.Remove(strKey);

                string strNValue = nValue.ToString();
                configCollection.Add(strKey, strNValue);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

                bResult = true;
            }
            catch
            {
                bResult = false;
            }

            return bResult;
        }

        /// <summary>
        /// App.config 에서 strKey의 내용을 삭제함
        /// </summary>
        /// <param name="strKey">삭제할 키값</param>
        /// <returns>성공 유무</returns>
        public static bool RemoveAppConfig(string strKey)
        {
            bool bResult;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            KeyValueConfigurationCollection configCollection = config.AppSettings.Settings;

            try
            {
                configCollection.Remove(strKey);

                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(config.AppSettings.SectionInformation.Name);

                bResult = true;
            }
            catch
            {
                bResult = false;
            }

            return bResult;
        }
    }
}
