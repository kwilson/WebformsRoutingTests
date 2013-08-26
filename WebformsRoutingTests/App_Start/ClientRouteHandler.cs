using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebformsRoutingTests.App_Start
{
    using System.Web.Compilation;
    using System.Web.Routing;
    using System.Web.UI;

    public class ClientRouteHandler : IRouteHandler
    {
        public ClientRouteHandler(string virtualPath)
        {
            this.VirtualPath = virtualPath;
        }

        public string VirtualPath { get; private set; }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            var page = BuildManager.CreateInstanceFromVirtualPath(this.VirtualPath, typeof(Page)) as IHttpHandler;
            return page;
        }
    }
}