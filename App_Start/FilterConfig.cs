﻿using System.Web;
using System.Web.Mvc;

namespace PANDA_MVC_V5
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}