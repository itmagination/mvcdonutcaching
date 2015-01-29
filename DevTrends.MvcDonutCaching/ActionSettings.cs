using System;
using System.Runtime.Serialization;
using System.Web.Routing;

namespace DevTrends.MvcDonutCaching
{
    [Serializable, DataContract]
    public class ActionSettings
    {
        /// <summary>
        /// Gets or sets the action name.
        /// </summary>
        /// <value>
        /// The action's name.
        /// </value>
        [DataMember(Order = 1)]
        public string ActionName { get; set; }

        /// <summary>
        /// Gets or sets the controller name.
        /// </summary>
        /// <value>
        /// The controller's name.
        /// </value>
        [DataMember(Order = 2)]
        public string ControllerName { get; set; }

        /// <summary>
        /// Get or sets the controller area.
        /// </summary>
        /// <value>
        /// The controller's area.
        /// </value>
        [DataMember(Order = 3)]
        public string ControllerArea { get; set; }

        /// <summary>
        /// Gets or sets the route values.
        /// </summary>
        /// <value>
        /// The route values.
        /// </value>
        [DataMember(Order = 4)]
        public RouteValueDictionary RouteValues { get; set; }
    }
}
