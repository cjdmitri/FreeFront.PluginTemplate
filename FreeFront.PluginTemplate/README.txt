Проект шаблона плагина для FreeFrontMVC

Создание и настройка
1. Создайте новый проект по типу "Библиотека классов" (Net 8.0 для версии FreeFrontCMS 0.4)
2. Добавьте ссылку на "Microsoft.AspNetCore.App"
3. Добавьте ссылку на "Asp.Versioning.Mvc" Version="8.0.0" (для версии FreeFrontCMS 0.4)
4. Установите пакет "FreeFront.Plugins.Bridge"
5. Добавьте класс PluginService : IPluginService (Реализующий интерфейс IPluginService)
6. Добавьте класс Plugin : IPlugin (Реализующий интерфейс IPlugin). В данном классе находится основная информация о плагине и метод инициализации
	6.1. В классе Plugin укажите тип плагина. 
		PluginType.Api - простой плагин, с API контроллером
		PluginType.Universal - универсальнеый плагин, для которого будет создана отдельная страница в БД (/admin/plugins/{idPlugin})
7. Создайте класс контроллера.
	7.1. Укажите Route("api/v{version:apiVersion}/plugins/templateapi")
	7.2. Укажите [ApiController]
8. Наполните контроллер логикой и конечными точками.

Подготовка проекта для публикации и установки
1. Выполните Release сборку проекта
2. Создайте временный каталог по названию проекта
	Структура каталога:
		- Plugins
			- FreeFront.PluginTemplate.dll (файл плагина)
			- FreeFront.PluginTemplate.html (страница плагина, при необходимости)
		- wwwroot (каталог ресурсов плагина)
			- plugins
				- css
				- js
				- img
3. Создайте .zip архив данного каталога
Так же, для загрузки плагина вы можете воспользоваться ftp

Установка плагина



