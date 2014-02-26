using System;
using System.Linq;
using System.Web;
using System.Web.Routing;

namespace StarDotOne
{
    public class LocaleRouteConstraint : IRouteConstraint
    {
        public string Locale { get; private set; }

        public LocaleRouteConstraint(string locale)
        {
            Locale = locale;
        }
        public bool Match(HttpContextBase httpContext, Route route, string parameterName, RouteValueDictionary values, RouteDirection routeDirection)
        {
            object value;
            if (values.TryGetValue("locale", out value) && !string.IsNullOrWhiteSpace(value as string))
            {
                string locale = value as string;
                if (isValid(locale))
                {
                    return string.Equals(Locale, locale, StringComparison.OrdinalIgnoreCase);
                }
            }
            return false;
        }

        private bool isValid(string locale)
        {
            string[] validOptions = "EN-US|EN-GB|FR-FR".Split('|') ;
            return validOptions.Contains(locale.ToUpper());
        }
    }
}