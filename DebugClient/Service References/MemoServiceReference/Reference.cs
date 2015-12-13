﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DebugClient.MemoServiceReference {
    using System.Runtime.Serialization;
    using System;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Runtime.Serialization", "4.0.0.0")]
    [System.Runtime.Serialization.DataContractAttribute(Name="MemoData", Namespace="http://schemas.datacontract.org/2004/07/NickServer")]
    [System.SerializableAttribute()]
    public partial class MemoData : object, System.Runtime.Serialization.IExtensibleDataObject, System.ComponentModel.INotifyPropertyChanged {
        
        [System.NonSerializedAttribute()]
        private System.Runtime.Serialization.ExtensionDataObject extensionDataField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string MessageField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private string SenderField;
        
        [System.Runtime.Serialization.OptionalFieldAttribute()]
        private System.DateTime TimestampField;
        
        [global::System.ComponentModel.BrowsableAttribute(false)]
        public System.Runtime.Serialization.ExtensionDataObject ExtensionData {
            get {
                return this.extensionDataField;
            }
            set {
                this.extensionDataField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Message {
            get {
                return this.MessageField;
            }
            set {
                if ((object.ReferenceEquals(this.MessageField, value) != true)) {
                    this.MessageField = value;
                    this.RaisePropertyChanged("Message");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Sender {
            get {
                return this.SenderField;
            }
            set {
                if ((object.ReferenceEquals(this.SenderField, value) != true)) {
                    this.SenderField = value;
                    this.RaisePropertyChanged("Sender");
                }
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public System.DateTime Timestamp {
            get {
                return this.TimestampField;
            }
            set {
                if ((this.TimestampField.Equals(value) != true)) {
                    this.TimestampField = value;
                    this.RaisePropertyChanged("Timestamp");
                }
            }
        }
        
        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
        
        protected void RaisePropertyChanged(string propertyName) {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null)) {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MemoServiceReference.IMemoService")]
    public interface IMemoService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemoService/putPublicMemo", ReplyAction="http://tempuri.org/IMemoService/putPublicMemoResponse")]
        void putPublicMemo(string message, string sender, string hash);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemoService/putPublicMemo", ReplyAction="http://tempuri.org/IMemoService/putPublicMemoResponse")]
        System.Threading.Tasks.Task putPublicMemoAsync(string message, string sender, string hash);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemoService/putMemo", ReplyAction="http://tempuri.org/IMemoService/putMemoResponse")]
        void putMemo(string message, string to, string from, string hash);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemoService/putMemo", ReplyAction="http://tempuri.org/IMemoService/putMemoResponse")]
        System.Threading.Tasks.Task putMemoAsync(string message, string to, string from, string hash);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemoService/getMyMemos", ReplyAction="http://tempuri.org/IMemoService/getMyMemosResponse")]
        DebugClient.MemoServiceReference.MemoData[] getMyMemos(string nick, string hash);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IMemoService/getMyMemos", ReplyAction="http://tempuri.org/IMemoService/getMyMemosResponse")]
        System.Threading.Tasks.Task<DebugClient.MemoServiceReference.MemoData[]> getMyMemosAsync(string nick, string hash);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IMemoServiceChannel : DebugClient.MemoServiceReference.IMemoService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class MemoServiceClient : System.ServiceModel.ClientBase<DebugClient.MemoServiceReference.IMemoService>, DebugClient.MemoServiceReference.IMemoService {
        
        public MemoServiceClient() {
        }
        
        public MemoServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public MemoServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MemoServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public MemoServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void putPublicMemo(string message, string sender, string hash) {
            base.Channel.putPublicMemo(message, sender, hash);
        }
        
        public System.Threading.Tasks.Task putPublicMemoAsync(string message, string sender, string hash) {
            return base.Channel.putPublicMemoAsync(message, sender, hash);
        }
        
        public void putMemo(string message, string to, string from, string hash) {
            base.Channel.putMemo(message, to, from, hash);
        }
        
        public System.Threading.Tasks.Task putMemoAsync(string message, string to, string from, string hash) {
            return base.Channel.putMemoAsync(message, to, from, hash);
        }
        
        public DebugClient.MemoServiceReference.MemoData[] getMyMemos(string nick, string hash) {
            return base.Channel.getMyMemos(nick, hash);
        }
        
        public System.Threading.Tasks.Task<DebugClient.MemoServiceReference.MemoData[]> getMyMemosAsync(string nick, string hash) {
            return base.Channel.getMyMemosAsync(nick, hash);
        }
    }
}