using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class LastModifiedResult : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>Collections which the user have read access to.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public LastModifiedResult_collections? Collections { get; set; }
#nullable restore
#else
        public LastModifiedResult_collections Collections { get; set; }
#endif
        /// <summary>Actual storage server date (Unix epoch in ms).</summary>
        public long? SrvDate { get; set; }
        /// <summary>
        /// Instantiates a new LastModifiedResult and sets the default values.
        /// </summary>
        public LastModifiedResult() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static LastModifiedResult CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new LastModifiedResult();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"collections", n => { Collections = n.GetObjectValue<LastModifiedResult_collections>(LastModifiedResult_collections.CreateFromDiscriminatorValue); } },
                {"srvDate", n => { SrvDate = n.GetLongValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<LastModifiedResult_collections>("collections", Collections);
            writer.WriteLongValue("srvDate", SrvDate);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
