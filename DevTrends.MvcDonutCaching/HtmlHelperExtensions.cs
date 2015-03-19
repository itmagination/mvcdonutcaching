﻿using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using DevTrends.MvcDonutCaching.Annotations;

namespace DevTrends.MvcDonutCaching
{
    public static class HtmlHelperExtensions
    {
        public const string RouteValuesDictionaryAreaKey = "Area";

        public static IActionSettingsSerialiser Serialiser
        {
            get { return MvcDonutCaching.EncryptingActionSettingsSerialiser; }
        }

        /// <summary>
        /// Invokes the specified child action method and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, bool excludeFromParentCache)
        {
            return htmlHelper.Action(actionName, null, null, null, excludeFromParentCache);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, object routeValues, bool excludeFromParentCache)
        {
            return htmlHelper.Action(actionName, null, null, new RouteValueDictionary(routeValues), excludeFromParentCache);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, RouteValueDictionary routeValues, bool excludeFromParentCache)
        {
            return htmlHelper.Action(actionName, null, null, routeValues, excludeFromParentCache);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, bool excludeFromParentCache)
        {
            return htmlHelper.Action(actionName, controllerName, null, null, excludeFromParentCache);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="controllerArea">The area of the controller that contains the action method.</param>
        /// <param name="routeValues">An object that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, [AspMvcAreaAttribute] string controllerArea,
            object routeValues, bool excludeFromParentCache)
        {
            return htmlHelper.Action(actionName, controllerName, controllerArea, new RouteValueDictionary(routeValues), excludeFromParentCache);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>

        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, bool excludeFromParentCache)
        {
            RenderAction(htmlHelper, actionName, null, null, null, excludeFromParentCache);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>

        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, object routeValues, bool excludeFromParentCache)
        {
            RenderAction(htmlHelper, actionName, null, null, new RouteValueDictionary(routeValues), excludeFromParentCache);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>        
        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, RouteValueDictionary routeValues, bool excludeFromParentCache)
        {
            RenderAction(htmlHelper, actionName, null, null, routeValues, excludeFromParentCache);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>        
        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, bool excludeFromParentCache)
        {
            RenderAction(htmlHelper, actionName, controllerName, null, null, excludeFromParentCache);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="controllerArea">The area of the controller that contains the action method.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, [AspMvcAreaAttribute] string controllerArea,
            object routeValues, bool excludeFromParentCache)
        {
            RenderAction(htmlHelper, actionName, controllerName, controllerArea, new RouteValueDictionary(routeValues), excludeFromParentCache);
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and renders the result inline in the parent view.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the child action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="controllerArea">The area of the controller that contains the action method.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        public static void RenderAction(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, [AspMvcAreaAttribute] string controllerArea,
            RouteValueDictionary routeValues, bool excludeFromParentCache)
        {
            var routeValuesWithArea = GetCopyOfRouteValueDictionaryWithControllerAreaValue(routeValues, controllerArea);
            if (excludeFromParentCache)
            {
                var serialisedActionSettings = GetSerialisedActionSettings(actionName, controllerName, routeValuesWithArea);

                htmlHelper.ViewContext.Writer.Write("<!--Donut#{0}#-->", serialisedActionSettings);
            }

            htmlHelper.RenderAction(actionName, controllerName, routeValuesWithArea);

            if (excludeFromParentCache)
            {
                htmlHelper.ViewContext.Writer.Write("<!--EndDonut-->");
            }
        }

        /// <summary>
        /// Invokes the specified child action method using the specified parameters and controller name and returns the result as an HTML string.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper instance that this method extends.</param>
        /// <param name="actionName">The name of the action method to invoke.</param>
        /// <param name="controllerName">The name of the controller that contains the action method.</param>
        /// <param name="controllerArea">The area of the controller that contains the action method.</param>
        /// <param name="routeValues">A dictionary that contains the parameters for a route. You can use routeValues to provide the parameters that are bound to the action method parameters. The routeValues parameter is merged with the original route values and overrides them.</param>
        /// <param name="excludeFromParentCache">A flag that determines whether the action should be excluded from any parent cache.</param>
        /// <returns>The child action result as an HTML string.</returns>
        public static MvcHtmlString Action(this HtmlHelper htmlHelper, [AspMvcAction] string actionName, [AspMvcController] string controllerName, [AspMvcAreaAttribute] string controllerArea,
            RouteValueDictionary routeValues, bool excludeFromParentCache)
        {
            var routeValuesWithArea = GetCopyOfRouteValueDictionaryWithControllerAreaValue(routeValues, controllerArea);

            if (excludeFromParentCache)
            {
                var serialisedActionSettings = GetSerialisedActionSettings(actionName, controllerName, routeValuesWithArea);

                return new MvcHtmlString(string.Format("<!--Donut#{0}#-->{1}<!--EndDonut-->", serialisedActionSettings, htmlHelper.Action(actionName, controllerName, routeValuesWithArea)));
            }

            return htmlHelper.Action(actionName, controllerName, routeValuesWithArea);
        }

        private static RouteValueDictionary GetCopyOfRouteValueDictionaryWithControllerAreaValue(
            RouteValueDictionary routeValues, [AspMvcAreaAttribute] string controllerArea)
        {
            var routeValuesCopy = new RouteValueDictionary(routeValues);
            if (controllerArea != null)
            {
                routeValuesCopy[RouteValuesDictionaryAreaKey] = controllerArea;
            }

            return routeValuesCopy;
        }

        private static string GetSerialisedActionSettings(string actionName, string controllerName, RouteValueDictionary routeValues)
        {
            var actionSettings = new ActionSettings
            {
                ActionName = actionName,
                ControllerName = controllerName,
                RouteValues = routeValues
            };

            return Serialiser.Serialise(actionSettings);
        }
    }
}