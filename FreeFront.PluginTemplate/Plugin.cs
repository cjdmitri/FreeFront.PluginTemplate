using Microsoft.Extensions.DependencyInjection;
using FreeFront.Plugins.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreeFront.Models;

namespace FreeFront.PluginTemplate
{
     public class Plugin : IPlugin
     {

          public string Name => "Template API Plugin";

          public string Description => "Description Template API plugin";

          public string Version => "0.5";

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

          public string UrlApiService => string.Empty;

          public void Initialize(IServiceCollection services, IApplicationService appService)
          {
               appService.LogAddInfo($"Инициализация плагина: {Name}");
               services.AddSingleton<IPluginService, PluginService>();

               //Если плагину необходимо создание, хранение и чтение настроек,
               //то можно воспользоваться сервисами приложения
               //Настройки будут храниться в файле настроек приложения settings.xml
               //key должен быть уникальным, иначе создание настройки будет проигнарировано
               //Настройки для плагина можно создать в отдельной группе
               string goupName = "My Plugin";
               string setKey = "PLUGIN_KEY";

               Setting set1 = new Setting
               {
                    Description = "Description setting",
                    ItsPublic = true, //false - то параметр не будет доступен через {set setKey}
                    Key = setKey,
                    Name = "Мой параметр",
                    Type = SettingType.text.ToString(),
                    Value = "Value 1"
               };

               /// 0 - настройка создана и сохранена
               /// -1 - параметр Key не уникален, или пустое название группы
               /// -2 - ошибка при сохранении файла
               /// -3 - ошибка при чтении файла настроек
               int success = appService.SettingsAppend(goupName, set1);
               if (success == 0)
                    appService.LogAddInfo($"Добавлен новый параметр плагина: {Name}");

               //Получить значение
               //string? myParamValue =  appService.SettingsGetValue(setKey);

               //Изменить значение
               //appService.SettingsSetValue(setKey, "New value");

          }
     }
}
