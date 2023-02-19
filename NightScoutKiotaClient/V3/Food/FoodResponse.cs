using Microsoft.Kiota.Abstractions.Serialization;
using NightScoutV3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.V3.Food {
    public class FoodResponse : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The result property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<NightScoutV3.Models.Food>? Result { get; set; }
#nullable restore
#else
        public List<NightScoutV3.Models.Food> Result { get; set; }
#endif
        /// <summary>The status property</summary>
        public int? Status { get; set; }
        /// <summary>
        /// Instantiates a new foodResponse and sets the default values.
        /// </summary>
        public FoodResponse() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static FoodResponse CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new FoodResponse();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"result", n => { Result = n.GetCollectionOfObjectValues<NightScoutV3.Models.Food>(NightScoutV3.Models.Food.CreateFromDiscriminatorValue)?.ToList(); } },
                {"status", n => { Status = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteCollectionOfObjectValues<NightScoutV3.Models.Food>("result", Result);
            writer.WriteIntValue("status", Status);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
