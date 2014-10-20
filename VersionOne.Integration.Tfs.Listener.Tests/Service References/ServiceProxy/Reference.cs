﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18444
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03", ConfigurationName="ServiceProxy.IService")]
    public interface IService {
        
        // CODEGEN: Generating message contract since element name eventXml from namespace http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03 is not marked nillable
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Noti" +
            "fy", ReplyAction="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/ISer" +
            "vice/NotifyResponse")]
        VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyResponse Notify(VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/Noti" +
            "fy", ReplyAction="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03/ISer" +
            "vice/NotifyResponse")]
        System.Threading.Tasks.Task<VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyResponse> NotifyAsync(VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequest request);
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class NotifyRequest {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="Notify", Namespace="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03", Order=0)]
        public VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequestBody Body;
        
        public NotifyRequest() {
        }
        
        public NotifyRequest(VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequestBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute(Namespace="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03")]
    public partial class NotifyRequestBody {
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=0)]
        public string eventXml;
        
        [System.Runtime.Serialization.DataMemberAttribute(EmitDefaultValue=false, Order=1)]
        public string tfsIdentityXml;
        
        public NotifyRequestBody() {
        }
        
        public NotifyRequestBody(string eventXml, string tfsIdentityXml) {
            this.eventXml = eventXml;
            this.tfsIdentityXml = tfsIdentityXml;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(IsWrapped=false)]
    public partial class NotifyResponse {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Name="NotifyResponse", Namespace="http://schemas.microsoft.com/TeamFoundation/2005/06/Services/Notification/03", Order=0)]
        public VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyResponseBody Body;
        
        public NotifyResponse() {
        }
        
        public NotifyResponse(VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyResponseBody Body) {
            this.Body = Body;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.Runtime.Serialization.DataContractAttribute()]
    public partial class NotifyResponseBody {
        
        public NotifyResponseBody() {
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IServiceChannel : VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.IService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class ServiceClient : System.ServiceModel.ClientBase<VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.IService>, VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.IService {
        
        public ServiceClient() {
        }
        
        public ServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public ServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public ServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyResponse VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.IService.Notify(VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequest request) {
            return base.Channel.Notify(request);
        }
        
        public void Notify(string eventXml, string tfsIdentityXml) {
            VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequest inValue = new VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequest();
            inValue.Body = new VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequestBody();
            inValue.Body.eventXml = eventXml;
            inValue.Body.tfsIdentityXml = tfsIdentityXml;
            VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyResponse retVal = ((VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.IService)(this)).Notify(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyResponse> VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.IService.NotifyAsync(VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequest request) {
            return base.Channel.NotifyAsync(request);
        }
        
        public System.Threading.Tasks.Task<VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyResponse> NotifyAsync(string eventXml, string tfsIdentityXml) {
            VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequest inValue = new VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequest();
            inValue.Body = new VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.NotifyRequestBody();
            inValue.Body.eventXml = eventXml;
            inValue.Body.tfsIdentityXml = tfsIdentityXml;
            return ((VersionOne.Integration.Integration.Tfs.Listener.Tests.ServiceProxy.IService)(this)).NotifyAsync(inValue);
        }
    }
}
