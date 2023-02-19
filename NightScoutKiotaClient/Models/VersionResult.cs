using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class VersionResult : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>API v3 subsystem version</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ApiVersion { get; set; }
#nullable restore
#else
        public string ApiVersion { get; set; }
#endif
        /// <summary>Actual server date and time in UNIX epoch format</summary>
        public long? SrvDate { get; set; }
        /// <summary>Type of storage engine used</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public VersionResult_storage? Storage { get; set; }
#nullable restore
#else
        public VersionResult_storage Storage { get; set; }
#endif
        /// <summary>The whole Nightscout instance version</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Version { get; set; }
#nullable restore
#else
        public string Version { get; set; }
#endif
        /// <summary>
        /// Instantiates a new VersionResult and sets the default values.
        /// </summary>
        public VersionResult() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static VersionResult CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new VersionResult();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"apiVersion", n => { ApiVersion = n.GetStringValue(); } },
                {"srvDate", n => { SrvDate = n.GetLongValue(); } },
                {"storage", n => { Storage = n.GetObjectValue<VersionResult_storage>(VersionResult_storage.CreateFromDiscriminatorValue); } },
                {"version", n => { Version = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("apiVersion", ApiVersion);
            writer.WriteLongValue("srvDate", SrvDate);
            writer.WriteObjectValue<VersionResult_storage>("storage", Storage);
            writer.WriteStringValue("version", Version);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
