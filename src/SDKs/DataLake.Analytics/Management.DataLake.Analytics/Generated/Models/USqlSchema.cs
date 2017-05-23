// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// Code generated by Microsoft (R) AutoRest Code Generator 1.0.1.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.Management.DataLake.Analytics.Models
{
    using Microsoft.Azure;
    using Microsoft.Azure.Management;
    using Microsoft.Azure.Management.DataLake;
    using Microsoft.Azure.Management.DataLake.Analytics;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// A Data Lake Analytics catalog U-SQL schema item.
    /// </summary>
    public partial class USqlSchema : CatalogItem
    {
        /// <summary>
        /// Initializes a new instance of the USqlSchema class.
        /// </summary>
        public USqlSchema()
        {
          CustomInit();
        }

        /// <summary>
        /// Initializes a new instance of the USqlSchema class.
        /// </summary>
        /// <param name="computeAccountName">the name of the Data Lake
        /// Analytics account.</param>
        /// <param name="version">the version of the catalog item.</param>
        /// <param name="databaseName">the name of the database.</param>
        /// <param name="name">the name of the schema.</param>
        public USqlSchema(string computeAccountName = default(string), System.Guid? version = default(System.Guid?), string databaseName = default(string), string name = default(string))
            : base(computeAccountName, version)
        {
            DatabaseName = databaseName;
            Name = name;
            CustomInit();
        }

        /// <summary>
        /// An initialization method that performs custom operations like setting defaults
        /// </summary>
        partial void CustomInit();

        /// <summary>
        /// Gets or sets the name of the database.
        /// </summary>
        [JsonProperty(PropertyName = "databaseName")]
        public string DatabaseName { get; set; }

        /// <summary>
        /// Gets or sets the name of the schema.
        /// </summary>
        [JsonProperty(PropertyName = "schemaName")]
        public string Name { get; set; }

    }
}