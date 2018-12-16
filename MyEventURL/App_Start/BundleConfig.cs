﻿using System.Web;
using System.Web.Optimization;

namespace MyEventURL
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/underscore.js",
                        "~/Scripts/url.js",
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/vuejs").Include(
                      "~/Scripts/vue.js",
                      "~/Scripts/bluebird*",
                      "~/Scripts/axios.js"));

            bundles.Add(new ScriptBundle("~/bundles/momentjs").Include(
                      "~/Scripts/moment.js",
                      "~/Scripts/moment-timezone-with-data.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                      "~/Scripts/jquery-ui*"));

            bundles.Add(new ScriptBundle("~/bundles/officejs").Include(
                       "~/Scripts/Office/1/office.js"));

            bundles.Add(new StyleBundle("~/Content/officefabric").Include(
                      "~/Content/fabric*",
                      "~/Content/AddIn/AddIn.css"));

            bundles.Add(new StyleBundle("~/Content/jqueryui").Include(
                      "~/Content/jquery-ui*"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
