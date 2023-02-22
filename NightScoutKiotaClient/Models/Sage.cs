using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class Sage : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The min property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Min { get; set; }
#nullable restore
#else
        public string Min { get; set; }
#endif
        /// <summary>The SensorChange property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NightScoutV3.Models.SensorChange? SensorChange { get; set; }
#nullable restore
#else
        public NightScoutV3.Models.SensorChange SensorChange { get; set; }
#endif
        /// <summary>The SensorStart property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NightScoutV3.Models.SensorStart? SensorStart { get; set; }
#nullable restore
#else
        public NightScoutV3.Models.SensorStart SensorStart { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Sage and sets the default values.
        /// </summary>
        public Sage() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Sage CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Sage();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"min", n => { Min = n.GetStringValue(); } },
                {"Sensor Change", n => { SensorChange = n.GetObjectValue<NightScoutV3.Models.SensorChange>(NightScoutV3.Models.SensorChange.CreateFromDiscriminatorValue); } },
                {"Sensor Start", n => { SensorStart = n.GetObjectValue<NightScoutV3.Models.SensorStart>(NightScoutV3.Models.SensorStart.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("min", Min);
            writer.WriteObjectValue<NightScoutV3.Models.SensorChange>("Sensor Change", SensorChange);
            writer.WriteObjectValue<NightScoutV3.Models.SensorStart>("Sensor Start", SensorStart);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
