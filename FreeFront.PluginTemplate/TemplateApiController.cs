using Microsoft.AspNetCore.Authorization;
using Asp.Versioning;
using FreeFront.Plugins.Bridge;
using Microsoft.AspNetCore.Mvc;

namespace PluginExample
{
     [ApiController]
     [Area("api")]
     [ApiVersion("1.0")]
     [Route("api/v{version:apiVersion}/plugins/templateapi")]
     [Produces("application/json")]
     public class TemplateApiController : ControllerBase
     {
          private IPluginService ps;
          private IApplicationService appSvc;

          public TemplateApiController(IPluginService _ps, IApplicationService _appSvc)
          {
               this.ps = _ps;
               this.appSvc = _appSvc;
          }

          [AllowAnonymous]
          [HttpGet("testrequest")]
          public object TestRequest()
          {
               appSvc.LogAddInfo("Обращение к плагину");
               return $"Plugin Template v 1.0 {ps.Test()}";
          }

          [HttpGet("appservicetest")]
          public object AppServiceTest() => $"App version {appSvc.GetVersionApp}";

     }
}
