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

    public partial class ApplicationPublishObject
    {
        /// <summary>
        /// Initializes a new instance of the ApplicationPublishObject class.
        /// </summary>
        public ApplicationPublishObject()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the ApplicationPublishObject class.
        /// </summary>
        public ApplicationPublishObject(string versionId = default(string), bool? isStaging = default(bool?), string region = default(string))
        {
            VersionId = versionId;
            IsStaging = isStaging;
            Region = region;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "versionId")]
        public string VersionId { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "isStaging")]
        public bool? IsStaging { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "region")]
        public string Region { get; set; }

    }
}
