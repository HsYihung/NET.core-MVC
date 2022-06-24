using Kendo.Mvc.Examples.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc.Filters;
using Kendo.Mvc.Examples.Extensions;

namespace Kendo.Mvc.Examples.Controllers
{
    public class DemoAttribute : ActionFilterAttributeBase
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            FindCurrentExample();

            NavigationExample currentExample = ViewBag.CurrentExample;
            NavigationWidget currentWidget = ViewBag.CurrentWidget;

            if (currentWidget == null)
            {
                return;
            }

            ViewBag.Description = Description(ViewBag.Product, currentExample, currentWidget);
            ViewBag.CtaType = GetCtaType(currentExample, currentWidget);
            ViewBag.HasConsole = currentExample.HasConsole;

            var exampleFiles = new List<ExampleFile>();
            exampleFiles.AddRange(SourceCode());
            exampleFiles.AddRange(AdditionalSources(currentWidget.Sources));
            exampleFiles.AddRange(AdditionalSources(currentExample.Sources));
            ViewBag.ExampleFiles = exampleFiles.Where(file => file.Exists(ContentRootPath));

            var api = currentExample.Api ?? ViewBag.CurrentWidget.Api;
            if (!string.IsNullOrEmpty(api))
            {
                if (api == "web/validator")
                {
                    ViewBag.Api = "https://docs.telerik.com/kendo-ui/aspnet-mvc/validation";
                }
                else
                {
                    ViewBag.Api = IUrlHelperExtensions.IsAbsoluteUrl(api) ? api : "https://docs.telerik.com/aspnet-core/api" + Regex.Replace(api, "(web|dataviz|framework)", "").Replace("mobile/", "/mobile");
                }
            }

            if (currentWidget.Documentation != null && currentWidget.Documentation.ContainsKey(ViewBag.Product))
            {
                var documentationLink = currentWidget.Documentation[ViewBag.Product];
                ViewBag.Documentation = IUrlHelperExtensions.IsAbsoluteUrl(documentationLink) ? documentationLink : "https://docs.telerik.com/aspnet-core/" + documentationLink;
            }

            if (currentWidget.Forum != null && currentWidget.Forum.ContainsKey(ViewBag.Product))
            {
                ViewBag.Forum = "https://www.telerik.com/forums/" + currentWidget.Forum[ViewBag.Product];
            }
        }

        protected void FindCurrentExample()
        {
            var found = false;

            NavigationExample current = null;
            NavigationWidget currentWidget = null;

            foreach (NavigationWidget widget in ViewBag.Navigation)
            {
                foreach (NavigationExample example in widget.Items)
                {
                    if (example.ShouldInclude())
                    {
                        examplesUrl.Add("~/" + example.Url);
                    }

                    if (!found && IsCurrentExample(example.Url))
                    {
                        current = example;
                        currentWidget = widget;
                        found = true;
                        LoadAltDescription(example);
                    }
                }
            }

            ViewBag.CurrentWidget = currentWidget;

            if (currentWidget == null)
            {
                return;
            }

            ViewBag.CurrentExample = current;

            if (current.Url.Contains("index"))
            {
                ViewBag.Title = string.Format("ASP.NET Core {0} Key Features Demo  | Telerik UI for ASP.NET Core", currentWidget.Text);
            }
            else
            {
                ViewBag.Title = string.Format("{0} in ASP.NET Core {1} Component Demo | Telerik UI for ASP.NET Core", current.Text, currentWidget.Text);
            }


            if (current.Meta != null)
            {
                if (current.Meta.ContainsKey(MvcFlavor.AspNetCore))
                {
                    ViewBag.Meta = current.Meta[MvcFlavor.AspNetCore];
                }
            }
            else
            {
                ViewBag.Meta = string.Format("This demo shows how to use {0} for ASP.NET Core {1}. Play with the example or check the source code.", current.Text, currentWidget.Text); ;
            }
        }

        private bool IsCurrentExample(string url)
        {
            var section = Controller.ControllerContext.RouteData.Values["controller"].ToString().ToLower().Replace("_", "-");
            var example = Controller.ControllerContext.RouteData.Values["action"].ToString().ToLower().Replace("_", "-");

            var components = url.Split('/');

            return (section == components[0] && example == components[1]) ||
                (section == "upload" && example.Contains("submit") && components[0] == "upload" && components[1] == "index");
        }

        protected string Description(string product, NavigationExample example, NavigationWidget widget)
        {
            if (example.Description != null && example.Description.ContainsKey(product))
            {
                return example.Description[product];
            }
            else if (widget.Description != null && widget.Description.ContainsKey(product))
            {
                return widget.Description[product];
            }

            return null;
        }

        protected string GetCtaType(NavigationExample example, NavigationWidget widget)
        {
            var restricted = new List<string>() { "Document Processing", "Reporting", "Framework" };

            if (!restricted.Contains(widget.Category) && example.Url.Contains("index"))
            {
                return "large";
            }

            return "small";
        }

        protected IEnumerable<ExampleFile> SourceCode()
        {
            var section = Controller.ControllerContext.RouteData.Values["controller"].ToString().ToLower().Replace("_", "-");
            var example = Controller.ControllerContext.RouteData.Values["action"].ToString().ToLower().Replace("_", "-");

            IFrameworkDescription framework = new AspNetCoreDescription();

            return framework.GetFiles(ContentRootPath, example, section);
        }

        protected IEnumerable<ExampleFile> AdditionalSources(IDictionary<string, IEnumerable<ExampleFile>> sources)
        {
            var files = new List<ExampleFile>();

            if (sources != null && sources.ContainsKey(MvcFlavor.AspNetCore))
            {
                files.AddRange(sources[MvcFlavor.AspNetCore]);
            }

            return files;
        }

        private void LoadAltDescription(NavigationExample example)
        {
            var segments = example.Url.Split(new char[] { '/' });
            segments[0] = segments[0].Replace("-", "_");
            var url = string.Join("/", segments);
            var path = Path.GetFullPath(Path.Combine(ContentRootPath, "Views\\" + url + ".html"));
            if (File.Exists(path))
            {
                example.AltDescription = File.ReadAllText(path);
            }
        }

    }
}