//------------------------------------------------------------------------------
// <généré automatiquement>
//     Ce code a été généré par un outil.
//     //
//     Les changements apportés à ce fichier peuvent provoquer un comportement incorrect et seront perdus si
//     le code est regénéré.
// </généré automatiquement>
//------------------------------------------------------------------------------

namespace ServiceReference2
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
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Article", Namespace="http://schemas.datacontract.org/2004/07/WcfService1")]
    public partial class Article : object
    {
        
        private ServiceReference2.Categorie CategorieField;
        
        private string DescriptionField;
        
        private int EnfantInventaireIdField;
        
        private int InventaireIdField;
        
        private string PhotoField;
        
        private int idArticleField;
        
        private string nomField;
        
        private int quantiteField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public ServiceReference2.Categorie Categorie
        {
            get
            {
                return this.CategorieField;
            }
            set
            {
                this.CategorieField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Description
        {
            get
            {
                return this.DescriptionField;
            }
            set
            {
                this.DescriptionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int EnfantInventaireId
        {
            get
            {
                return this.EnfantInventaireIdField;
            }
            set
            {
                this.EnfantInventaireIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int InventaireId
        {
            get
            {
                return this.InventaireIdField;
            }
            set
            {
                this.InventaireIdField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string Photo
        {
            get
            {
                return this.PhotoField;
            }
            set
            {
                this.PhotoField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int idArticle
        {
            get
            {
                return this.idArticleField;
            }
            set
            {
                this.idArticleField = value;
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
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int quantite
        {
            get
            {
                return this.quantiteField;
            }
            set
            {
                this.quantiteField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="ServiceReference2.IGarderieService")]
    public interface IGarderieService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGarderieService/GetCategorieById", ReplyAction="http://tempuri.org/IGarderieService/GetCategorieByIdResponse")]
        System.Threading.Tasks.Task<ServiceReference2.Categorie> GetCategorieByIdAsync(int idCategorie);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGarderieService/GetAllCategories", ReplyAction="http://tempuri.org/IGarderieService/GetAllCategoriesResponse")]
        System.Threading.Tasks.Task<ServiceReference2.Categorie[]> GetAllCategoriesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGarderieService/GetCategorieByName", ReplyAction="http://tempuri.org/IGarderieService/GetCategorieByNameResponse")]
        System.Threading.Tasks.Task<ServiceReference2.Categorie> GetCategorieByNameAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGarderieService/GetArticleById", ReplyAction="http://tempuri.org/IGarderieService/GetArticleByIdResponse")]
        System.Threading.Tasks.Task<ServiceReference2.Article> GetArticleByIdAsync(int idArticle);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGarderieService/GetAllArticles", ReplyAction="http://tempuri.org/IGarderieService/GetAllArticlesResponse")]
        System.Threading.Tasks.Task<ServiceReference2.Article[]> GetAllArticlesAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IGarderieService/GetArticleByName", ReplyAction="http://tempuri.org/IGarderieService/GetArticleByNameResponse")]
        System.Threading.Tasks.Task<ServiceReference2.Article> GetArticleByNameAsync(string name);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public interface IGarderieServiceChannel : ServiceReference2.IGarderieService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.1")]
    public partial class GarderieServiceClient : System.ServiceModel.ClientBase<ServiceReference2.IGarderieService>, ServiceReference2.IGarderieService
    {
        
    /// <summary>
    /// Implémentez cette méthode partielle pour configurer le point de terminaison de service.
    /// </summary>
    /// <param name="serviceEndpoint">Point de terminaison à configurer</param>
    /// <param name="clientCredentials">Informations d'identification du client</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public GarderieServiceClient() : 
                base(GarderieServiceClient.GetDefaultBinding(), GarderieServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IGarderieService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GarderieServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(GarderieServiceClient.GetBindingForEndpoint(endpointConfiguration), GarderieServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GarderieServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(GarderieServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GarderieServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(GarderieServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public GarderieServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.Categorie> GetCategorieByIdAsync(int idCategorie)
        {
            return base.Channel.GetCategorieByIdAsync(idCategorie);
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.Categorie[]> GetAllCategoriesAsync()
        {
            return base.Channel.GetAllCategoriesAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.Categorie> GetCategorieByNameAsync(string name)
        {
            return base.Channel.GetCategorieByNameAsync(name);
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.Article> GetArticleByIdAsync(int idArticle)
        {
            return base.Channel.GetArticleByIdAsync(idArticle);
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.Article[]> GetAllArticlesAsync()
        {
            return base.Channel.GetAllArticlesAsync();
        }
        
        public System.Threading.Tasks.Task<ServiceReference2.Article> GetArticleByNameAsync(string name)
        {
            return base.Channel.GetArticleByNameAsync(name);
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IGarderieService))
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
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IGarderieService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:51768/Services/GarderieService.svc");
            }
            throw new System.InvalidOperationException(string.Format("Le point de terminaison nommé \'{0}\' est introuvable.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return GarderieServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IGarderieService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return GarderieServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IGarderieService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IGarderieService,
        }
    }
}
