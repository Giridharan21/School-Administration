﻿using System.Web;
using System.Web.Mvc;

namespace SchoolAdministration.Web_UI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
