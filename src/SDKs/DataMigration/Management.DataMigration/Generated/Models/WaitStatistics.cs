// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.Management.DataMigration.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// Wait statistics gathered during query batch execution
    /// </summary>
    public partial class WaitStatistics
    {
        /// <summary>
        /// Initializes a new instance of the WaitStatistics class.
        /// </summary>
        public WaitStatistics()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the WaitStatistics class.
        /// </summary>
        /// <param name="waitType">Type of the Wait</param>
        /// <param name="waitTimeMs">Total wait time in millisecond(s) </param>
        /// <param name="waitCount">Total no. of waits</param>
        public WaitStatistics(string waitType = default(string), double? waitTimeMs = default(double?), long? waitCount = default(long?))
        {
            WaitType = waitType;
            WaitTimeMs = waitTimeMs;
            WaitCount = waitCount;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets type of the Wait
        /// </summary>
        [JsonProperty(PropertyName = "waitType")]
        public string WaitType { get; set; }

        /// <summary>
        /// Gets or sets total wait time in millisecond(s)
        /// </summary>
        [JsonProperty(PropertyName = "waitTimeMs")]
        public double? WaitTimeMs { get; set; }

        /// <summary>
        /// Gets or sets total no. of waits
        /// </summary>
        [JsonProperty(PropertyName = "waitCount")]
        public long? WaitCount { get; set; }

    }
}
