using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    /// <summary>
    /// Blood glucose measurements and CGM calibrations
    /// </summary>
    public class Entry : DocumentBase, IParsable {
        /// <summary>Direction of glucose trend reported by CGM. (only available for sgv types)Example: &quot;DoubleDown&quot;, &quot;SingleDown&quot;, &quot;FortyFiveDown&quot;, &quot;Flat&quot;, &quot;FortyFiveUp&quot;, &quot;SingleUp&quot;, &quot;DoubleUp&quot;, &quot;NOT COMPUTABLE&quot;, &quot;RATE OUT OF RANGE&quot; for xdrip</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Direction { get; set; }
#nullable restore
#else
        public string Direction { get; set; }
#endif
        /// <summary>The raw filtered value directly from CGM transmitter. (only available for sgv types)</summary>
        public int? Filtered { get; set; }
        /// <summary>Noise level at time of reading. (only available for sgv types)Example: xdrip: 0, 1, 2=high, 3=high_for_predict, 4=very high, 5=extreme</summary>
        public int? Noise { get; set; }
        /// <summary>The signal strength from CGM transmitter. (only available for sgv types)</summary>
        public int? Rssi { get; set; }
        /// <summary>The glucose reading. (only available for sgv types)</summary>
        public int? Sgv { get; set; }
        /// <summary>sgv, mbg, cal, etc</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Type { get; set; }
#nullable restore
#else
        public string Type { get; set; }
#endif
        /// <summary>The raw unfiltered value directly from CGM transmitter. (only available for sgv types)</summary>
        public int? Unfiltered { get; set; }
        /// <summary>The units for the glucose value, mg/dl or mmol/l. It is strongly recommended to fill in this field.Example: &quot;mg&quot;, &quot;mmol&quot;</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Units { get; set; }
#nullable restore
#else
        public string Units { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Entry CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Entry();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"direction", n => { Direction = n.GetStringValue(); } },
                {"filtered", n => { Filtered = n.GetIntValue(); } },
                {"noise", n => { Noise = n.GetIntValue(); } },
                {"rssi", n => { Rssi = n.GetIntValue(); } },
                {"sgv", n => { Sgv = n.GetIntValue(); } },
                {"type", n => { Type = n.GetStringValue(); } },
                {"unfiltered", n => { Unfiltered = n.GetIntValue(); } },
                {"units", n => { Units = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteStringValue("direction", Direction);
            writer.WriteIntValue("filtered", Filtered);
            writer.WriteIntValue("noise", Noise);
            writer.WriteIntValue("rssi", Rssi);
            writer.WriteIntValue("sgv", Sgv);
            writer.WriteStringValue("type", Type);
            writer.WriteIntValue("unfiltered", Unfiltered);
            writer.WriteStringValue("units", Units);
        }
    }
}
