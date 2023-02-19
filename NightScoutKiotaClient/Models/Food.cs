using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    /// <summary>
    /// Nutritional values of food
    /// </summary>
    public class Food : DocumentBase, IParsable {
        /// <summary>Amount of carbs in the portion in grams</summary>
        public float? Carbs { get; set; }
        /// <summary>Name for a group of related records</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Category { get; set; }
#nullable restore
#else
        public string Category { get; set; }
#endif
        /// <summary>Amount of energy in the portion in kJ</summary>
        public float? Energy { get; set; }
        /// <summary>Amount of fat in the portion in grams</summary>
        public float? Fat { get; set; }
        /// <summary>food, quickpick</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? FoodProp { get; set; }
#nullable restore
#else
        public string FoodProp { get; set; }
#endif
        /// <summary>Glycemic index (1=low, 2=medium, 3=high)</summary>
        public float? Gi { get; set; }
        /// <summary>Flag used for quickpick</summary>
        public bool? Hidden { get; set; }
        /// <summary>Flag used for quickpick</summary>
        public bool? Hideafteruse { get; set; }
        /// <summary>Name of the food described</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Name { get; set; }
#nullable restore
#else
        public string Name { get; set; }
#endif
        /// <summary>Number of units (e.g. grams) of the whole portion described</summary>
        public float? Portion { get; set; }
        /// <summary>component multiplier if defined inside quickpick compound</summary>
        public float? Portions { get; set; }
        /// <summary>Ordering field for quickpick</summary>
        public float? Position { get; set; }
        /// <summary>Amount of proteins in the portion in grams</summary>
        public float? Protein { get; set; }
        /// <summary>Name for a second level of groupping</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Subcategory { get; set; }
#nullable restore
#else
        public string Subcategory { get; set; }
#endif
        /// <summary>g, ml, oz</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Unit { get; set; }
#nullable restore
#else
        public string Unit { get; set; }
#endif
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static new Food CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Food();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"carbs", n => { Carbs = n.GetFloatValue(); } },
                {"category", n => { Category = n.GetStringValue(); } },
                {"energy", n => { Energy = n.GetFloatValue(); } },
                {"fat", n => { Fat = n.GetFloatValue(); } },
                {"food", n => { FoodProp = n.GetStringValue(); } },
                {"gi", n => { Gi = n.GetFloatValue(); } },
                {"hidden", n => { Hidden = n.GetBoolValue(); } },
                {"hideafteruse", n => { Hideafteruse = n.GetBoolValue(); } },
                {"name", n => { Name = n.GetStringValue(); } },
                {"portion", n => { Portion = n.GetFloatValue(); } },
                {"portions", n => { Portions = n.GetFloatValue(); } },
                {"position", n => { Position = n.GetFloatValue(); } },
                {"protein", n => { Protein = n.GetFloatValue(); } },
                {"subcategory", n => { Subcategory = n.GetStringValue(); } },
                {"unit", n => { Unit = n.GetStringValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public new void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            base.Serialize(writer);
            writer.WriteFloatValue("carbs", Carbs);
            writer.WriteStringValue("category", Category);
            writer.WriteFloatValue("energy", Energy);
            writer.WriteFloatValue("fat", Fat);
            writer.WriteStringValue("food", FoodProp);
            writer.WriteFloatValue("gi", Gi);
            writer.WriteBoolValue("hidden", Hidden);
            writer.WriteBoolValue("hideafteruse", Hideafteruse);
            writer.WriteStringValue("name", Name);
            writer.WriteFloatValue("portion", Portion);
            writer.WriteFloatValue("portions", Portions);
            writer.WriteFloatValue("position", Position);
            writer.WriteFloatValue("protein", Protein);
            writer.WriteStringValue("subcategory", Subcategory);
            writer.WriteStringValue("unit", Unit);
        }
    }
}
