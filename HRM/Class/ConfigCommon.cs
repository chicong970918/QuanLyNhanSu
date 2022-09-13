using System ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace HRM.Class
{
   public class ConfigCommon
    {
        #region ---- Properties ----

        /// <summary>
        /// Gets the supper user.
        /// </summary>
        /// <value>The supper user.</value>
        public static string SuperUser
        {
            get
            {
                return ReadByKey("UserSuperAdmin");
            }
        }

        /// <summary>
        /// Gets the PWD supper user.
        /// </summary>
        /// <value>The PWD supper user.</value>
        public static string PwdSuperUser
        {
            get
            {
                return ReadByKey("PwdSuperAdmin");
            }
        }

        #endregion

        #region ---- Public methods ----

        /// <summary>
        /// Encrypts the connection strings.
        /// </summary>
        public static void EncryptConfigFile()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            EncryptConnectionStrings(config);
            EncryptAppStrings(config);
        }

        /// <summary>
        /// Reads the by key.
        /// </summary>
        /// <param name="pKey">The p key.</param>
        /// <returns></returns>
        public static string ReadByKey(string pKey)
        {
            return ConfigurationManager.AppSettings[pKey];
        }

        #endregion

        #region ---- Private methods ----

        /// <summary>
        /// Encrypts the connection strings.
        /// </summary>
        /// <param name="config">The config.</param>
        private static void EncryptConnectionStrings(Configuration config)
        {
            if (config != null)
            {
                ConfigurationSection section = config.GetSection("connectionStrings");

                if (section != null && !section.IsReadOnly())
                {
                    section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                    section.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
        }

        /// <summary>
        /// Encrypts the app strings.
        /// </summary>
        /// <param name="config">The config.</param>
        private static void EncryptAppStrings(Configuration config)
        {
            if (config != null)
            {
                ConfigurationSection section = config.GetSection("appSettings");

                if (section != null && !section.IsReadOnly())
                {
                    section.SectionInformation.ProtectSection("RsaProtectedConfigurationProvider");
                    section.SectionInformation.ForceSave = true;
                    config.Save(ConfigurationSaveMode.Full);
                }
            }
        }

        #endregion
    }
}
