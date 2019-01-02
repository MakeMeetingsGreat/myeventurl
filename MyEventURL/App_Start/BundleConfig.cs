using System.Web;
using System.Web.Optimization;

namespace MyEventURL
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/underscore.js",
                        "~/Scripts/url.js",
                        "~/Scripts/jquery.validate*",
                        "~/Scripts/chosen*",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/jquery-ui*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/vuejs").Include(
                      "~/Scripts/vue.js",
                      "~/Scripts/bluebird*",
                      "~/Scripts/axios.js"));

            bundles.Add(new ScriptBundle("~/bundles/momentjs").Include(
                      "~/Scripts/moment.js",
                      "~/Scripts/moment-timezone-with-data.js"));

            bundles.Add(new StyleBundle("~/Content/styles").Include(
                      "~/Content/chosen*",
                      "~/Content/jquery-ui*",
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
