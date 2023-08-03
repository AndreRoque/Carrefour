using HTTPBase;
using System.Runtime.Serialization;

namespace FluxoCaixa.Application
{
    [DataContract]
    public class DebitarRequest : IRequest
    {
        #region Public Properties

        [DataMember(Name = "valor")]
        public decimal Valor { get; set; }

        #endregion Public Properties
    }

    
}