// <auto-generated>
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator.
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.
// </auto-generated>

namespace Microsoft.Azure.CognitiveServices.Language.LUIS.Programmatic.Models
{
    using Newtonsoft.Json;
    using System.Linq;

    public partial class ApplicationPublishResponse
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationPublishResponse class.
        /// </summary>
        public ApplicationPublishResponse()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationPublishResponse class.
        /// </summary>
        public ApplicationPublishResponse(string endpointUrl = default(string), string subscriptionKey = default(string), string endpointRegion = default(string), bool? isStaging = default(bool?))
        {
            EndpointUrl = endpointUrl;
            SubscriptionKey = subscriptionKey;
            EndpointRegion = endpointRegion;
            IsStaging = isStaging;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "endpointUrl")]
        public string EndpointUrl { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "subscription-key")]
        public string SubscriptionKey { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "endpointRegion")]
        public string EndpointRegion { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isStaging")]
        public bool? IsStaging { get; set; }

    }
}