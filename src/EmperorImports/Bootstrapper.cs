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

        protected override void RequestStartup(TinyIoCContainer container, IPipelines pipelines, NancyContext context)
        {
            base.RequestStartup(container, pipelines, context);

            pipelines.AfterRequest.AddItemToEndOfPipeline(c =>
            {
                //Disable XSS filter
                c.Response.Headers["X-XSS-Protection"] = "0";
            });
        }

    }
}