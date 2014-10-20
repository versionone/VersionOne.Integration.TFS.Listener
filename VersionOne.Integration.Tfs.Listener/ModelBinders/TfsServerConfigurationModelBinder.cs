using System.Web.Http.Controllers;
using System.Web.Http.ModelBinding;
using Newtonsoft.Json;
using VersionOne.Integration.Tfs.Core.DTO;

namespace VersionOne.Integration.Tfs.Listener.ModelBinders
{
    public class TfsServerConfigurationModelBinder : IModelBinder
    {
        public bool BindModel(HttpActionContext actionContext, ModelBindingContext bindingContext)
        {
            var json = actionContext.Request.Content.ReadAsStringAsync().Result;
            bindingContext.Model = JsonConvert.DeserializeObject<TfsServerConfiguration>(json);
            return true;
        }
    }
}