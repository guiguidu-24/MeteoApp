using System;
using System.Collections.Generic;

namespace MeteoApp
{
    public static class WeatherRessources
    {

        #region Uris

        private readonly static Uri neigeUri = new Uri("/Resources/Images/neige.png", UriKind.Relative);
        private readonly static Uri nuageUri = new Uri("/Resources/Images/nuages.png", UriKind.Relative);
        private readonly static Uri orageUri = new Uri("/Resources/Images/orage.png", UriKind.Relative);
        private readonly static Uri pluieUri = new Uri("/Resources/Images/pluie.png", UriKind.Relative);
        private readonly static Uri soleilUri = new Uri("/Resources/Images/soleil.png", UriKind.Relative);
        private readonly static Uri soleilNuageUri = new Uri("/Resources/Images/soleilNuage.png", UriKind.Relative);
        private readonly static Uri brouillardUri = new Uri("/Resources/Images/brouillard.png", UriKind.Relative);
        private readonly static Uri rainSnowUri = new Uri("/Resources/Images/rainSnow.png", UriKind.Relative);
        private readonly static Uri snowThunderstormUri = new Uri("/Resources/Images/snowThunderstorm.png", UriKind.Relative);
        private readonly static Uri rainSunUri = new Uri("/Resources/Images/rainSun.png", UriKind.Relative);
        private readonly static Uri snowSunUri = new Uri("/Resources/Images/snowSun.png", UriKind.Relative);

        #endregion

        public static Dictionary<int, (string Type, Uri LogoUri)> Weather { get; } = new Dictionary<int, (string, Uri)>
        {
            { 0, ("Soleil", soleilUri) },
            { 1, ("Peu nuageux", soleilNuageUri) },
            { 2, ("Ciel voilé", soleilNuageUri) },
            { 3, ("Nuageux", nuageUri) },
            { 4, ("Très nuageux", nuageUri) },
            { 5, ("Couvert", nuageUri) },
            { 6, ("Brouillard", brouillardUri) },
            { 7, ("Brouillard givrant", brouillardUri) },
            { 10, ("Pluie faible", pluieUri) },
            { 11, ("Pluie modérée", pluieUri) },
            { 12, ("Pluie forte", pluieUri) },
            { 13, ("Pluie faible verglaçante", pluieUri) },
            { 14, ("Pluie modérée verglaçante", pluieUri) },
            { 15, ("Pluie forte verglaçante", pluieUri) },
            { 16, ("Bruine", pluieUri) },
            { 20, ("Neige faible", neigeUri) },
            { 21, ("Neige modérée", neigeUri) },
            { 22, ("Neige forte", neigeUri) },
            { 30, ("Pluie et neige mêlées faibles", rainSnowUri) },
            { 31, ("Pluie et neige mêlées modérées", rainSnowUri) },
            { 32, ("Pluie et neige mêlées fortes", rainSnowUri) },
            { 40, ("Averses de pluie locales et faibles", pluieUri) },
            { 41, ("Averses de pluie locales", pluieUri) },
            { 42, ("Averses locales et fortes", pluieUri) },
            { 43, ("Averses de pluie faibles", pluieUri) },
            { 44, ("Averses de pluie", pluieUri) },
            { 45, ("Averses de pluie fortes", pluieUri) },
            { 46, ("Averses de pluie faibles et fréquentes", pluieUri) },
            { 47, ("Averses de pluie fréquentes", pluieUri) },
            { 48, ("Averses de pluie fortes et fréquentes", pluieUri) },
            { 60, ("Averses de neige localisées et faibles", neigeUri) },
            { 61, ("Averses de neige localisées", neigeUri) },
            { 62, ("Averses de neige localisées et fortes", neigeUri) },
            { 63, ("Averses de neige faibles", neigeUri) },
            { 64, ("Averses de neige", neigeUri) },
            { 65, ("Averses de neige fortes", neigeUri) },
            { 66, ("Averses de neige faibles et fréquentes", neigeUri) },
            { 67, ("Averses de neige fréquentes", neigeUri) },
            { 68, ("Averses de neige fortes et fréquentes", neigeUri) },
            { 70, ("Averses de pluie et neige mêlées localisées et faibles", rainSnowUri) },
            { 71, ("Averses de pluie et neige mêlées localisées", rainSnowUri) },
            { 72, ("Averses de pluie et neige mêlées localisées et fortes", rainSnowUri) },
            { 73, ("Averses de pluie et neige mêlées faibles", rainSnowUri) },
            { 74, ("Averses de pluie et neige mêlées", rainSnowUri) },
            { 75, ("Averses de pluie et neige mêlées fortes", rainSnowUri) },
            { 76, ("Averses de pluie et neige mêlées faibles et nombreuses", rainSnowUri) },
            { 77, ("Averses de pluie et neige mêlées fréquentes", rainSnowUri) },
            { 78, ("Averses de pluie et neige mêlées fortes et fréquentes", rainSnowUri) },
            { 100, ("Orages faibles et locaux", orageUri) },
            { 101, ("Orages locaux", orageUri) },
            { 102, ("Orages fort et locaux", orageUri) },
            { 103, ("Orages faibles", orageUri) },
            { 104, ("Orages", orageUri) },
            { 105, ("Orages forts", orageUri) },
            { 106, ("Orages faibles et fréquents", orageUri) },
            { 107, ("Orages fréquents", orageUri) },
            { 108, ("Orages forts et fréquents", orageUri) },
            { 120, ("Orages faibles et locaux de neige ou grésil", snowThunderstormUri) },
            { 121, ("Orages locaux de neige ou grésil", snowThunderstormUri) },
            { 122, ("Orages locaux de neige ou grésil", snowThunderstormUri) },
            { 123, ("Orages faibles de neige ou grésil", snowThunderstormUri) },
            { 124, ("Orages de neige ou grésil", snowThunderstormUri) },
            { 125, ("Orages de neige ou grésil", snowThunderstormUri) },
            { 126, ("Orages faibles et fréquents de neige ou grésil", snowThunderstormUri) },
            { 127, ("Orages fréquents de neige ou grésil", snowThunderstormUri) },
            { 128, ("Orages fréquents de neige ou grésil", snowThunderstormUri) },
            { 130, ("Orages faibles et locaux de pluie et neige mêlées ou grésil", snowThunderstormUri) },
            { 131, ("Orages locaux de pluie et neige mêlées ou grésil", snowThunderstormUri) },
            { 132, ("Orages fort et locaux de pluie et neige mêlées ou grésil", snowThunderstormUri) },
            { 133, ("Orages faibles de pluie et neige mêlées ou grésil", snowThunderstormUri) },
            { 134, ("Orages de pluie et neige mêlées ou grésil", snowThunderstormUri) },
            { 135, ("Orages forts de pluie et neige mêlées ou grésil", snowThunderstormUri) },
            { 136, ("Orages faibles et fréquents de pluie et neige mêlées ou grésil", snowThunderstormUri) },
            { 137, ("Orages fréquents de pluie et neige mêlées ou grésil", snowThunderstormUri) },
            { 138, ("Orages forts et fréquents de pluie et neige mêlées ou grésil", snowThunderstormUri) },
            { 140, ("Pluies orageuses", orageUri) },
            { 141, ("Pluie et neige mêlées à caractère orageux", snowThunderstormUri) },
            { 142, ("Neige à caractère orageux", snowThunderstormUri) },
            { 210, ("Pluie faible intermittente", rainSunUri) },
            { 211, ("Pluie modérée intermittente", rainSunUri) },
            { 212, ("Pluie forte intermittente", rainSunUri) },
            { 220, ("Neige faible intermittente", snowSunUri) },
            { 221, ("Neige modérée intermittente", snowSunUri) },
            { 222, ("Neige forte intermittente", snowSunUri) },
            { 230, ("Pluie et neige mêlées", rainSnowUri) },
            { 231, ("Pluie et neige mêlées", rainSnowUri) },
            { 232, ("Pluie et neige mêlées", rainSnowUri) },
            { 235, ("Averses de grêle", pluieUri) },
        };

       
    }
}