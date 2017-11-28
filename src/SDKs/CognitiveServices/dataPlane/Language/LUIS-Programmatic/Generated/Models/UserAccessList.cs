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
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public partial class UserAccessList
    {
        /// <summary>
        /// Initializes a new instance of the UserAccessList class.
        /// </summary>
        public UserAccessList()
        {
            CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the UserAccessList class.
        /// </summary>
        /// <param name="owner">The email address of owner of the
        /// application.</param>
        public UserAccessList(string owner = default(string), IList<string> emails = default(IList<string>))
        {
            Owner = owner;
            Emails = emails;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the email address of owner of the application.
        /// </summary>
        [JsonProperty(PropertyName = "owner")]
        public string Owner { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "emails")]
        public IList<string> Emails { get; set; }

    }
}