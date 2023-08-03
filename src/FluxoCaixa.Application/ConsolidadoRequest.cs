using HTTPBase;
using System.Runtime.Serialization;

namespace FluxoCaixa.Application
{
    [DataContract]
    public class ConsolidadoRequest : IRequest
    {
        #region Public Properties

        [DataMember(Name = "data")]
        public DateTime Data { get; set; }

        #endregion Public Properties
    }

    
}