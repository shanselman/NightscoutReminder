using Microsoft.Kiota.Abstractions.Serialization;
using NightScoutV3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.V3.Lastmodified {
    public class LastmodifiedResponse : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The result property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public LastModifiedResult? Result { get; set; }
#nullable restore
#else
        public LastModifiedResult Result { get; set; }
#endif
        /// <summary>The status property</summary>
        public int? Status { get; set; }
        /// <summary>
        /// Instantiates a new lastmodifiedResponse and sets the default values.
        /// </summary>
        public LastmodifiedResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static LastmodifiedResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new LastmodifiedResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"result", n => { Result = n.GetObjectValue<LastModifiedResult>(LastModifiedResult.CreateFromDiscriminatorValue); } },
                {"status", n => { Status = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<LastModifiedResult>("result", Result);
            writer.WriteIntValue("status", Status);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
