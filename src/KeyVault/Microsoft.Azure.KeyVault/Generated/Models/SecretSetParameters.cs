// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Microsoft.Azure.KeyVault.Models
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Microsoft.Rest;
    using Microsoft.Rest.Serialization;
    using Microsoft.Rest.Azure;

    public partial class SecretSetParameters
    {
        /// <summary>
        /// Initializes a new instance of the SecretSetParameters class.
        /// </summary>
        public SecretSetParameters() { }

        /// <summary>
        /// Initializes a new instance of the SecretSetParameters class.
        /// </summary>
        public SecretSetParameters(string value, IDictionary<string, string> tags = default(IDictionary<string, string>), string contentType = default(string), SecretAttributes secretAttributes = default(SecretAttributes))
        {
            Value = value;
            Tags = tags;
            ContentType = contentType;
            SecretAttributes = secretAttributes;
        }

        /// <summary>
        /// The value of the secret
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Application-specific metadata in the form of key-value pairs
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Type of the secret value such as a password
        /// </summary>
        [JsonProperty(PropertyName = "contentType")]
        public string ContentType { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public SecretAttributes SecretAttributes { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Value == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Value");
            }
        }
    }
}
