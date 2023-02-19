using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class Cage : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The age property</summary>
        public int? Age { get; set; }
        /// <summary>The checkForAlert property</summary>
        public bool? CheckForAlert { get; set; }
        /// <summary>The days property</summary>
        public int? Days { get; set; }
        /// <summary>The display property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Display { get; set; }
#nullable restore
#else
        public string Display { get; set; }
#endif
        /// <summary>The found property</summary>
        public bool? Found { get; set; }
        /// <summary>The hours property</summary>
        public int? Hours { get; set; }
        /// <summary>The level property</summary>
        public int? Level { get; set; }
        /// <summary>The minFractions property</summary>
        public int? MinFractions { get; set; }
        /// <summary>The notes property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Notes { get; set; }
#nullable restore
#else
        public string Notes { get; set; }
#endif
        /// <summary>The treatmentDate property</summary>
        public long? TreatmentDate { get; set; }
        /// <summary>
        /// Instantiates a new Cage and sets the default values.
        /// </summary>
        public Cage() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Cage CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Cage();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"age", n => { Age = n.GetIntValue(); } },
                {"checkForAlert", n => { CheckForAlert = n.GetBoolValue(); } },
                {"days", n => { Days = n.GetIntValue(); } },
                {"display", n => { Display = n.GetStringValue(); } },
                {"found", n => { Found = n.GetBoolValue(); } },
                {"hours", n => { Hours = n.GetIntValue(); } },
                {"level", n => { Level = n.GetIntValue(); } },
                {"minFractions", n => { MinFractions = n.GetIntValue(); } },
                {"notes", n => { Notes = n.GetStringValue(); } },
                {"treatmentDate", n => { TreatmentDate = n.GetLongValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteIntValue("age", Age);
            writer.WriteBoolValue("checkForAlert", CheckForAlert);
            writer.WriteIntValue("days", Days);
            writer.WriteStringValue("display", Display);
            writer.WriteBoolValue("found", Found);
            writer.WriteIntValue("hours", Hours);
            writer.WriteIntValue("level", Level);
            writer.WriteIntValue("minFractions", MinFractions);
            writer.WriteStringValue("notes", Notes);
            writer.WriteLongValue("treatmentDate", TreatmentDate);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
