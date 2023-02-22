using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class LastModdifiedCollections : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Timestamp of the last modification (Unix epoch in ms), `null` when there is no timestamp found.</summary>
        public long? Devicestatus { get; set; }
        /// <summary>Timestamp of the last modification (Unix epoch in ms), `null` when there is no timestamp found.</summary>
        public long? Entries { get; set; }
        /// <summary>Timestamp of the last modification (Unix epoch in ms), `null` when there is no timestamp found.</summary>
        public long? Profile { get; set; }
        /// <summary>Timestamp of the last modification (Unix epoch in ms), `null` when there is no timestamp found.</summary>
        public long? Treatments { get; set; }
        /// <summary>
        /// Instantiates a new LastModdifiedCollections and sets the default values.
        /// </summary>
        public LastModdifiedCollections() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static LastModdifiedCollections CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new LastModdifiedCollections();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"devicestatus", n => { Devicestatus = n.GetLongValue(); } },
                {"entries", n => { Entries = n.GetLongValue(); } },
                {"profile", n => { Profile = n.GetLongValue(); } },
                {"treatments", n => { Treatments = n.GetLongValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteLongValue("devicestatus", Devicestatus);
            writer.WriteLongValue("entries", Entries);
            writer.WriteLongValue("profile", Profile);
            writer.WriteLongValue("treatments", Treatments);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
