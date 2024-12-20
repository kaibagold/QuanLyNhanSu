using Antlr.Runtime;
using DocumentFormat.OpenXml.Math;
using System.Web;
using System.Web.Optimization;

namespace QuanLyNhanSu
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // datatable
            bundles.Add(new ScriptBundle("~/bundles/datatable").Include(
                      "~/Scripts/dataTable/datatables.min.js"));
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
                      "~/Scripts/customjs/activedatatable.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                     "~/Content/bootstrap.css",
                     "~/Content/bootstrap.min.css",
                     "~/Content/bootstrap.css.map",
                     "~/Content/boostrap.min.css.map",
                     "~/Content/css/font-awesome.min.css",
                     "~/Content/css/account.css",
                     "~/Content/site.css",
                     "~/Content/css/index.css"));
            bundles.Add(new StyleBundle("~/Content/Admin/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap.min.css",
                        "~/Content/bootstrap.css.map",
                        "~/Content/boostrap.min.css.map",
                        "~/Content/datatables.min.css",
                        "~/Content/css/font-awesome.min.css",
                        "~/Content/sb-admin.css",
                        "~/Content/admin-lte/css/AdminLTE.min.css",
                        "~/Content/admin-lte/css/skins/_all-skins.min.css",
                        "~/Content/css/CreateSwap.css"));
            bundles.Add(new StyleBundle("~/Content/css").Include(
                        "~/Content/-/media/Themes/Wireframe/sass/base/fonts/fonts.scss",
                        "~/Content/-/media/themes/fpt-corporation/fpt/component-themes/cr/styles/pre-optimized-mina18a.css",
                        "~/Content/-/media/feature/experience-accelerator/bootstrap-4/bootstrap-4/styles/optimized-minf5f7.css",
                        "~/Content/-/media/base-themes/core-libraries/styles/optimized-min3f37.css",
                        "~/Content/-/media/base-themes/main-theme/styles/optimized-mind13f.css",
                        "~/Content/-/media/themes/fpt-corporation/fpt/fptweb/styles/pre-optimized-minc050.css",
                        "~/Content/-/media/themes/fpt-corporation/fpt/fptweb-base/styles/theme.css",
                        "~/Content/-/media/themes/fpt-corporation/fpt/component-themes/slick-theme/styles/slick.css",
                        "~/Content/css/login_index.css"));
            bundles.Add(new StyleBundle("~/Content/Luong/css").Include(
                        "~/Content/bootstrap.css",
                        "~/Content/bootstrap.min.css",
                        "~/Content/bootstrap.css.map",
                        "~/Content/boostrap.min.css.map",
                        "~/Content/datatables.min.css",
                        "~/Content/css/font-awesome.min.css"));
            bundles.Add(new StyleBundle("~/Content/font_awesome").Include(
                        "~/Content/css/font-awesome.min.css"));
        }
    }
}