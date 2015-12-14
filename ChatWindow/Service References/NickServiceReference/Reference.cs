﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ChatWindow.NickServiceReference {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="NickServiceReference.INickService")]
    public interface INickService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INickService/registerNick", ReplyAction="http://tempuri.org/INickService/registerNickResponse")]
        bool registerNick(string nick, string hash);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/INickService/registerNick", ReplyAction="http://tempuri.org/INickService/registerNickResponse")]
        System.Threading.Tasks.Task<bool> registerNickAsync(string nick, string hash);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface INickServiceChannel : ChatWindow.NickServiceReference.INickService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class NickServiceClient : System.ServiceModel.ClientBase<ChatWindow.NickServiceReference.INickService>, ChatWindow.NickServiceReference.INickService {
        
        public NickServiceClient() {
        }
        
        public NickServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public NickServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NickServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public NickServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public bool registerNick(string nick, string hash) {
            return base.Channel.registerNick(nick, hash);
        }
        
        public System.Threading.Tasks.Task<bool> registerNickAsync(string nick, string hash) {
            return base.Channel.registerNickAsync(nick, hash);
        }
    }
}
