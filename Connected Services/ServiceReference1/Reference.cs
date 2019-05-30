//------------------------------------------------------------------------------
// <généré automatiquement>
//     Ce code a été généré par un outil.
//     //
//     Les changements apportés à ce fichier peuvent provoquer un comportement incorrect et seront perdus si
//     le code est regénéré.
// </généré automatiquement>
//------------------------------------------------------------------------------

namespace ServiceReference1
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Categorie", Namespace="http://schemas.datacontract.org/2004/07/WcfService1.Model")]
    public partial class Categorie : object
    {
        
        private int idCategorieField;
        
        private string nomField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idCategorie
        {
            get
            {
                return this.idCategorieField;
            }
            set
            {
                this.idCategorieField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string nom
        {
            get
            {
                return this.nomField;
            }
            set
            {
                this.nomField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference1.ICategorieService")]
    public interface ICategorieService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategorieService/GetCategorieById", ReplyAction="http://tempuri.org/ICategorieService/GetCategorieByIdResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Categorie> GetCategorieByIdAsync(int idCategorie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategorieService/GetAllCategories", ReplyAction="http://tempuri.org/ICategorieService/GetAllCategoriesResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Categorie[]> GetAllCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/ICategorieService/GetCategorieByName", ReplyAction="http://tempuri.org/ICategorieService/GetCategorieByNameResponse")]
        System.Threading.Tasks.Task<ServiceReference1.Categorie> GetCategorieByNameAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface ICategorieServiceChannel : ServiceReference1.ICategorieService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class CategorieServiceClient : System.ServiceModel.ClientBase<ServiceReference1.ICategorieService>, ServiceReference1.ICategorieService
    {
        
    /// <summary>
    /// Implémentez cette méthode partielle pour configurer le point de terminaison de service.
    /// </summary>
    /// <param name="serviceEndpoint">Point de terminaison à configurer</param>
    /// <param name="clientCredentials">Informations d'identification du client</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public CategorieServiceClient() : 
                base(CategorieServiceClient.GetDefaultBinding(), CategorieServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_ICategorieService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategorieServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(CategorieServiceClient.GetBindingForEndpoint(endpointConfiguration), CategorieServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategorieServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(CategorieServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategorieServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(CategorieServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public CategorieServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Categorie> GetCategorieByIdAsync(int idCategorie)
        {
            return base.Channel.GetCategorieByIdAsync(idCategorie);
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Categorie[]> GetAllCategoriesAsync()
        {
            return base.Channel.GetAllCategoriesAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference1.Categorie> GetCategorieByNameAsync(string name)
        {
            return base.Channel.GetCategorieByNameAsync(name);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICategorieService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Le point de terminaison nommé \'{0}\' est introuvable.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_ICategorieService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:51768/Services/CategorieService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Le point de terminaison nommé \'{0}\' est introuvable.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return CategorieServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_ICategorieService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return CategorieServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_ICategorieService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_ICategorieService,
        }
    }
}
