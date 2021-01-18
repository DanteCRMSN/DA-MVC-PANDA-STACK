using System.Web;
using System.Web.Optimization;

namespace PANDA_MVC_V5
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/wwwroot/js").Include(
            "~/wwwroot/js/registro.js"));
            bundles.Add(new ScriptBundle("~/wwwroot/js").Include(
                        "~/wwwroot/js/site.js"));

            bundles.Add(new ScriptBundle("~/wwwroot/lib/dist/js/bootstrap").Include(
                      "~/wwwroot/lib/dist/js/bootstrap.js"));

            bundles.Add(new StyleBundle("~/wwwroot/css").Include(
                      "~/wwwroot/css/ingreso.css",
                      "~/wwwroot/css/registro.css",
                      "~/wwwroot/css/site.css"));
            bundles.Add(new StyleBundle("~/wwwroot/lib/dist/css/bootstrap").Include(
                      "~/wwwroot/lib/dist/css/bootstrap.css"));
            
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/jquery.timeago.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            
        }
    }
}
