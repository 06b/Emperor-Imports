using Nancy;

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
        }
    }
}