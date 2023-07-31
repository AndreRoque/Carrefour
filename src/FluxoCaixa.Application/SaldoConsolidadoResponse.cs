using HTTPBase;
using System.Runtime.Serialization;

namespace FluxoCaixa.Application
{
    [DataContract]
    public class SaldoConsolidadoResponse : SuccessResponse, IResponse
    {
        #region Public Properties

        [DataMember(Name = "saldoConsolidado")]
        public decimal SaldoConsolidado { get; set; }

        #endregion Public Properties
    }
}