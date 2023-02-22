using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class ApiPermissions : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The devicestatus property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Devicestatus { get; set; }
#nullable restore
#else
        public string Devicestatus { get; set; }
#endif
        /// <summary>The entries property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Entries { get; set; }
#nullable restore
#else
        public string Entries { get; set; }
#endif
        /// <summary>The food property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Food { get; set; }
#nullable restore
#else
        public string Food { get; set; }
#endif
        /// <summary>The profile property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Profile { get; set; }
#nullable restore
#else
        public string Profile { get; set; }
#endif
        /// <summary>The treatments property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Treatments { get; set; }
#nullable restore
#else
        public string Treatments { get; set; }
#endif
        /// <summary>
        /// Instantiates a new ApiPermissions and sets the default values.
        /// </summary>
        public ApiPermissions() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static ApiPermissions CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new ApiPermissions();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"devicestatus", n => { Devicestatus = n.GetStringValue(); } },
                {"entries", n => { Entries = n.GetStringValue(); } },
                {"food", n => { Food = n.GetStringValue(); } },
                {"profile", n => { Profile = n.GetStringValue(); } },
                {"treatments", n => { Treatments = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("devicestatus", Devicestatus);
            writer.WriteStringValue("entries", Entries);
            writer.WriteStringValue("food", Food);
            writer.WriteStringValue("profile", Profile);
            writer.WriteStringValue("treatments", Treatments);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
