﻿
namespace MAGVA.Back.TransacoesFinanceiras.Infrastructure.Middlewares
{
    using System.Collections.Generic;

    public class FailingOptions
    {
        public string ConfigPath = "/Failing";
        public List<string> EndpointPaths { get; set; } = new List<string>();
    }
}
