﻿
namespace MAGVA.Front.TransacoesFinanceiras
{
    public class AppSettings
    {

        public bool ActivateCampaignDetailFunction { get; set; }
        public Logging Logging { get; set; }
        public bool UseCustomizationData { get; set; }

        public string TransacoesFinanceirasUrl {get; set;}
    }

    public class Connectionstrings
    {
        public string DefaultConnection { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }
}
