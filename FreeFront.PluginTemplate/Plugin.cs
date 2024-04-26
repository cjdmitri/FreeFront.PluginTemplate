using Microsoft.Extensions.DependencyInjection;
using FreeFront.Plugins.Bridge ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeFront.PluginTemplate
{
     public class Plugin : IPlugin
     {
          
          public string Name => "Template API Plugin";

          public string Description => "Description Template API plugin";

          public string Version => "0.1";

          public string SiteUrl => string.Empty;

          public string LinkName => "Template API";

          /// <summary>
          /// Здесь находится контент страницы плагина. Если Вы создаёте простой API плагин, то можно оставить string.empty
          /// </summary>
          private string _pluginPageContent = String.Empty;
          public string PluginPageContent
          { 
               get 
               { 
                    return _pluginPageContent; 
               } 
               set 
               { 
                    _pluginPageContent = value; 
               } 
          }

          public PluginType TypePlugin => PluginType.Api;

          public string Author => "Plugin author";

          public string ButtonTitle => "Подробнее";

          public void Initialize(IServiceCollection services, IApplicationService appService)
          {
               appService.LogAddInfo($"Инициализация плагина: {Name}");
               services.AddSingleton<IPluginService, PluginService>();
          }
     }
}
