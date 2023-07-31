using HTTPBase;
using System.Runtime.Serialization;

namespace FluxoCaixa.Application
{
    [DataContract]
    public class CreditarRequest : IRequest
    {
        #region Public Properties

        [DataMember]
        public decimal Valor { get; set; }

        #endregion Public Properties
    }
}