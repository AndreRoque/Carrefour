﻿using HTTPBase;
using System.Runtime.Serialization;

namespace FluxoCaixa.Application
{
    [DataContract]
    public class CreditarResponse : SuccessResponse, IResponse
    {
    }
}