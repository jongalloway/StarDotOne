using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc.Routing;
using System.Web.Routing;

namespace StarDotOne
{
    public class LocaleRouteAttribute : RouteFactoryAttribute
    {
        public LocaleRouteAttribute(string template, string locale)
            : base(template)
        {
            Locale = locale;

        }

        public string Locale
        {
            get;
            private set;
        }

        public override RouteValueDictionary Constraints
        {
            get
            {
                var constraints = new RouteValueDictionary();
                constraints.Add("locale", new LocaleRouteConstraint(Locale));
                return constraints;
            }
        }

        public override RouteValueDictionary Defaults
        {
            get
            {
                var defaults = new RouteValueDictionary();
                defaults.Add("locale", "en-us");
                return defaults;
            }
        }
    }
}