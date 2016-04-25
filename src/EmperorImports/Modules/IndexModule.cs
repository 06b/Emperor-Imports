using Nancy;
using Nancy.Responses;

namespace EmperorImports.Modules
{
    public class IndexModule : NancyModule
    {
        public IndexModule()
        {
            Get["/"] = parameters =>
            {
                return View["index"];
            };

            Get["/credits"] = _ => { return View["credits"]; };

            Get["/wp-admin/"] = _ => { return Response.AsRedirect("/wp-admin.php", RedirectResponse.RedirectType.SeeOther); };

            Get["/wp-admin.php"] = _ => { return View["admin/login"]; };

            Post["/wp-admin.php"] = _ => { return "submitted"; };
        }
    }
}