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

    public partial class KeyCreateParameters
    {
        /// <summary>
        /// Initializes a new instance of the KeyCreateParameters class.
        /// </summary>
        public KeyCreateParameters() { }

        /// <summary>
        /// Initializes a new instance of the KeyCreateParameters class.
        /// </summary>
        public KeyCreateParameters(string kty, int? keySize = default(int?), IList<string> keyOps = default(IList<string>), KeyAttributes keyAttributes = default(KeyAttributes), IDictionary<string, string> tags = default(IDictionary<string, string>))
        {
            Kty = kty;
            KeySize = keySize;
            KeyOps = keyOps;
            KeyAttributes = keyAttributes;
            Tags = tags;
        }

        /// <summary>
        /// The type of key to create. For valid key types, see WebKeyTypes.
        /// </summary>
        [JsonProperty(PropertyName = "kty")]
        public string Kty { get; set; }

        /// <summary>
        /// Size of the key
        /// </summary>
        [JsonProperty(PropertyName = "key_size")]
        public int? KeySize { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "key_ops")]
        public IList<string> KeyOps { get; set; }

        /// <summary>
        /// </summary>
        [JsonProperty(PropertyName = "attributes")]
        public KeyAttributes KeyAttributes { get; set; }

        /// <summary>
        /// Application-specific metadata in the form of key-value pairs
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public IDictionary<string, string> Tags { get; set; }

        /// <summary>
        /// Validate the object. Throws ValidationException if validation fails.
        /// </summary>
        public virtual void Validate()
        {
            if (Kty == null)
            {
                throw new ValidationException(ValidationRules.CannotBeNull, "Kty");
            }
            if (this.Kty != null)
            {
                if (this.Kty.Length < 1)
                {
                    throw new ValidationException(ValidationRules.MinLength, "Kty", 1);
                }
            }
        }
    }
}
