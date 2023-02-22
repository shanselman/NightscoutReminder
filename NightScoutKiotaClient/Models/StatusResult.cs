using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class StatusResult : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The apiPermissions property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NightScoutV3.Models.ApiPermissions? ApiPermissions { get; set; }
#nullable restore
#else
        public NightScoutV3.Models.ApiPermissions ApiPermissions { get; set; }
#endif
        /// <summary>The version property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public VersionResult? Version { get; set; }
#nullable restore
#else
        public VersionResult Version { get; set; }
#endif
        /// <summary>
        /// Instantiates a new StatusResult and sets the default values.
        /// </summary>
        public StatusResult() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static StatusResult CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new StatusResult();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"apiPermissions", n => { ApiPermissions = n.GetObjectValue<NightScoutV3.Models.ApiPermissions>(NightScoutV3.Models.ApiPermissions.CreateFromDiscriminatorValue); } },
                {"version", n => { Version = n.GetObjectValue<VersionResult>(VersionResult.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<NightScoutV3.Models.ApiPermissions>("apiPermissions", ApiPermissions);
            writer.WriteObjectValue<VersionResult>("version", Version);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
