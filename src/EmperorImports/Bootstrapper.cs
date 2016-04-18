using Nancy;
using Nancy.Elmah;
using Nancy.Bootstrapper;
using Nancy.TinyIoc;

namespace EmperorImports
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {

        protected override void ApplicationStartup(TinyIoCContainer container, IPipelines pipelines)
        {
            base.ApplicationStartup(container, pipelines);
            /// <summary>
            /// Elmah Logging - Enable Exception logging with select HttpStatusCode logging
            /// </summary>

            //Note: Elmah left unsecured purposely.
            Elmahlogging.Enable(pipelines, "elmah", new string[0], new HttpStatusCode[] { HttpStatusCode.NotFound, HttpStatusCode.InsufficientStorage, });
        }

    }
}