using NSpec;
using VersionOne.Integration.Tfs.Core.DTO;
using VersionOne.Integration.Tfs.Core.Structures;
using VersionOne.Integration.Tfs.Core.DataLayer.Providers;
using VersionOne.Integration.Tfs.Listener;

namespace VersionOne.Integration.Tfs.Listener.Tests
{

    public class ConfigurationControllerSpecs : nspec
    {
        public void given_settings_are_being_retrieved_from_the_controller()
        {
            context["when a parameterless http get is issued"] = () =>
                {
                    var config = new ConfigurationController().Get();
                    it["then valid json is returned"] = () => config.should_not_be(null);
                };
        }

        public void given_settings_are_being_sent_to_the_controller()
        {

            context["when a valid set of data including all possible fields"] = () =>
                {

                    //all possible fields are set
                    var postData = new TfsServerConfiguration()
                    {
                        IsWindowsIntegratedSecurity = true,
                        TfsUrl = "http://www.mytfsserver.com/default/",
                        TfsUserName = "admin1",
                        TfsPassword = "password1",
                        VersionOneUrl = "http://www.versionone.com/",
                        VersionOneUserName = "admin2",
                        VersionOnePassword = "password2",
                        ProxyIsEnabled = true,
                        TfsWorkItemRegex = "[]",
                        BaseListenerUrl = "http://localhost:9090/",
                        DebugMode = true,
                        ProxyUrl = "http://192.168.1.1/home/",
                        ProxyDomain = "AD1",
                        ProxyUsername = "admin3",
                        ProxyPassword = "password3"
                    };

                    it["then the data is saved accurately"] = () =>
                        {
                            new ConfigurationProvider().ClearAllSettings();
                            var postResult = new ConfigurationController().Post(postData);
                            var getData = new ConfigurationController().Get();
                            postResult[StatusKey.Status].should_be(StatusCode.Ok);
                            getData.should_be(postData);
                        };
                };

            context["when a valid object is sent to the server"] = () =>
                {
                    //min acceptable valid set of data
                    var postData = new TfsServerConfiguration()
                    {
                        TfsUrl = "http://www.mytfsserver.com/default/",
                        TfsUserName = "admin1",
                        TfsPassword = "password1",
                        VersionOneUrl = "http://www.versionone.com/",
                        VersionOneUserName = "admin2",
                        VersionOnePassword = "password2",
                        ProxyIsEnabled = false,
                        BaseListenerUrl = "http://locahost:9090/",
                        TfsWorkItemRegex = "[]" //not a required field, but returns a default so needs to be set in order for a valid comparison to occur below.
                    };

                    it["then the data is saved accurately"] = () =>
                        {

                            new ConfigurationProvider().ClearAllSettings();
                            var postResult = new ConfigurationController().Post(postData);
                            var getData = new ConfigurationController().Get();
                            
                            //the data retrieved should equal the data posted
                            getData.should_be(postData);

                            it["and the status of 'ok' is in the result data"] = () =>
                                {
                                    postResult.should_contain(kvp => kvp.Key == StatusKey.Status);
                                    postResult[StatusKey.Status].should_be(StatusCode.Ok);
                                };
                        };
                };

            context["when an invalid object is sent to the server"] = () =>
                {
                    
                    //invalid data missing v1url
                    var postData = new TfsServerConfiguration()
                    {
                        TfsUrl = "http://www.mytfsserver.com/default/",
                        TfsUserName = "admin1",
                        TfsPassword = "password1",
                        VersionOneUserName = "admin2",
                        VersionOnePassword = "password2",
                        ProxyIsEnabled = false
                    };

                    it["then a proper list of errors is received"] = () =>
                        {
                            new ConfigurationProvider().ClearAllSettings();
                            var postResult = new ConfigurationController().Post(postData);
                            postResult.should_contain(x => x.Key == "VersionOneUrl");
                            postResult["VersionOneUrl"].should_be(StatusCode.Required);
                            postResult[StatusKey.Status].should_be(StatusCode.Exception);
                        };
                };

        }

    }

}