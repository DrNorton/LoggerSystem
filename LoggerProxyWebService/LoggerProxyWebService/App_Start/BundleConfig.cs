﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace LoggerProxyWebService.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                                    "~/Scripts/jquery-{version}.js"));

          

            bundles.Add(new ScriptBundle("~/bundles/signalr").Include(
                                        "~/Scripts/jquery.signalR-2.2.0.min.js"));

           

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
          

          

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                                "~/Scripts/bootstrap.js",
                                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                                "~/Content/bootstrap.css",
                                "~/Content/loading-bar.css",
                                "~/Content/ng-img-crop.css",
                                "~/Content/site.css"));

            // Set EnableOptimizations to false for debugging. For more information,
            // visit http://go.microsoft.com/fwlink/?LinkId=301862
            BundleTable.EnableOptimizations = false;
        }
    }
}
