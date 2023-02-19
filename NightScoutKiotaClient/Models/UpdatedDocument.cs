using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class UpdatedDocument : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The deduplicatedIdentifier property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? DeduplicatedIdentifier { get; set; }
#nullable restore
#else
        public string DeduplicatedIdentifier { get; set; }
#endif
        /// <summary>The identifier property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Identifier { get; set; }
#nullable restore
#else
        public string Identifier { get; set; }
#endif
        /// <summary>The isDeduplication property</summary>
        public bool? IsDeduplication { get; set; }
        /// <summary>The status property</summary>
        public int? Status { get; set; }
        /// <summary>
        /// Instantiates a new UpdatedDocument and sets the default values.
        /// </summary>
        public UpdatedDocument() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static UpdatedDocument CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new UpdatedDocument();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"deduplicatedIdentifier", n => { DeduplicatedIdentifier = n.GetStringValue(); } },
                {"identifier", n => { Identifier = n.GetStringValue(); } },
                {"isDeduplication", n => { IsDeduplication = n.GetBoolValue(); } },
                {"status", n => { Status = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("deduplicatedIdentifier", DeduplicatedIdentifier);
            writer.WriteStringValue("identifier", Identifier);
            writer.WriteBoolValue("isDeduplication", IsDeduplication);
            writer.WriteIntValue("status", Status);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
