using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using VersionOne.Integration.Tfs.Core.Adapters;
using VersionOne.Integration.Tfs.Core.DataLayer;
using VersionOne.Integration.Tfs.Core.DataLayer.Collections;
using VersionOne.Integration.Tfs.Core.DataLayer.Providers;
using VersionOne.Integration.Tfs.Core.DTO;
using VersionOne.Integration.Tfs.Core.Structures;
using VersionOne.Integration.Tfs.Core.Security;
using VersionOne.Integration.Tfs.Listener.ModelBinders;

namespace VersionOne.Integration.Tfs.Listener
{

    public class ConfigurationController : ApiController
    {
        // GET <controller>
        [HttpGet]
        public string Get()
        {
            var configProvider = new ConfigurationProvider(ProtectData.Unprotect);

            var config = new TfsServerConfiguration
                {
                    VersionOneUrl = configProvider.VersionOneUrl.ToString(),
                    VersionOnePassword = configProvider.VersionOnePassword,
                    VersionOneUserName = configProvider.VersionOneUserName,
                    TfsUrl = configProvider.TfsUrl.ToString(),
                    TfsUserName = configProvider.TfsUserName,
                    TfsPassword = configProvider.TfsPassword,
                    TfsWorkItemRegex = configProvider.TfsWorkItemRegex,
                    IsWindowsIntegratedSecurity = configProvider.IsWindowsIntegratedSecurity,
                    DebugMode = configProvider.DebugMode,
                    BaseListenerUrl = configProvider.BaseListenerUrl.ToString()
                };
            
            if (configProvider.ProxySettings.ProxyIsEnabled)
            {
                config.ProxyDomain = configProvider.ProxySettings.Domain;
                config.ProxyIsEnabled = configProvider.ProxySettings.ProxyIsEnabled;
                config.ProxyUrl = configProvider.ProxySettings.Url.ToString();
                config.ProxyUsername = configProvider.ProxySettings.Username;
                config.ProxyPassword = configProvider.ProxySettings.Password;
            }

            var json = JsonConvert.SerializeObject(config);
            return ProtectData.Protect(json);
        }

        //POST <controller>
        [HttpPost]
        public Dictionary<string, string> Post([ModelBinder(typeof(TfsServerConfigurationModelBinder))] TfsServerConfiguration config)
        {

            var enumerable = ValidatePostData(config);

            var configToSave = new Dictionary<string, string>
                {
                    {AppSettingKeys.VersionOneUrl, config.VersionOneUrl},
                    {AppSettingKeys.VersionOnePassword, config.VersionOnePassword},
                    {AppSettingKeys.VersionOneUserName, config.VersionOneUserName},
                    {AppSettingKeys.TfsUrl, config.TfsUrl},
                    {AppSettingKeys.TfsUserName, config.TfsUserName},
                    {AppSettingKeys.TfsPassword, config.TfsPassword},
                    {AppSettingKeys.IsWindowsIntegratedSecurity, config.IsWindowsIntegratedSecurity.ToString()},
                    {AppSettingKeys.DebugMode, config.DebugMode.ToString()},
                    {AppSettingKeys.TfsWorkItemRegex, config.TfsWorkItemRegex},
                    {AppSettingKeys.ProxyIsEnabled, config.ProxyIsEnabled.ToString()},
                    {AppSettingKeys.ProxyUrl, config.ProxyUrl},
                    {AppSettingKeys.ProxyUserName, config.ProxyUsername},
                    {AppSettingKeys.ProxyPassword, config.ProxyPassword},
                    {AppSettingKeys.ProxyDomain, config.ProxyDomain},
                    {AppSettingKeys.BaseListenerUrl, config.BaseListenerUrl}
                };

            var returnValue = enumerable.ToDictionary(x => x.Key, x => x.Value);
            returnValue.Add(StatusKey.Status, returnValue.Count == 0 ? StatusCode.Ok : StatusCode.Exception);
            if (returnValue[StatusKey.Status] == StatusCode.Ok) SettingsFileAdapter.SaveSettings(configToSave, Paths.ConfigurationDirectory, Paths.ConfigurationFileName, ProtectData.Protect);
            
            return returnValue;
        }

        private static IEnumerable<KeyValuePair<string, string>> ValidatePostData(TfsServerConfiguration config)
        {
            if (string.IsNullOrEmpty(config.VersionOneUrl))
                yield return RequiredFieldError("VersionOneUrl");
            if (string.IsNullOrEmpty(config.VersionOnePassword))
                yield return RequiredFieldError("VersionOnePassword");
            if (string.IsNullOrEmpty(config.VersionOneUserName))
                yield return RequiredFieldError("VersionOneUserName");
            if (string.IsNullOrEmpty(config.TfsUrl))
                yield return RequiredFieldError("TfsUrl");
            if (string.IsNullOrEmpty(config.TfsUserName))
                yield return RequiredFieldError("TfsUserName");
            if (string.IsNullOrEmpty(config.TfsPassword))
                yield return RequiredFieldError("TfsPassword");
            if (string.IsNullOrEmpty(config.BaseListenerUrl))
                yield return RequiredFieldError("BaseListenerUrl");
        }

        private static KeyValuePair<string, string> RequiredFieldError(string fieldName)
        {
            return new KeyValuePair<string, string>(fieldName, StatusCode.Required);
        } 

    }
}