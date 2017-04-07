using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace FJD_REST
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            //use {servidor}/{api}/{controller}/?{op}&type=json para que o metodo retorne automaticamente um JSON
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "json", new MediaTypeHeaderValue("application/json")));
            //use {servidor}/{api}/{controller}/?{op}&type=xml para que o metodo retorne automaticamente um XML
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.MediaTypeMappings.Add(
                new QueryStringMapping("type", "xml", new MediaTypeHeaderValue("application/xml")));
              
                //Caso o parametro TYPE nao seja informado automaticamente a WebApi gerara um XML como retorno
        }
    }
}
