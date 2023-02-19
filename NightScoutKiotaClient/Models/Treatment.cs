using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class Treatment : DocumentBase, IParsable {
        /// <summary>Eventual basal change in absolute value (insulin units per hour).</summary>
        public float? Absolute { get; set; }
        /// <summary>Amount of carbs given.</summary>
        public float? Carbs { get; set; }
        /// <summary>Duration in minutes.</summary>
        public float? Duration { get; set; }
        /// <summary>Who entered the treatment.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? EnteredBy { get; set; }
#nullable restore
#else
        public string EnteredBy { get; set; }
#endif
        /// <summary>The type of treatment event.        Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? EventType { get; set; }
#nullable restore
#else
        public string EventType { get; set; }
#endif
        /// <summary>Amount of fat given.</summary>
        public float? Fat { get; set; }
        /// <summary>Current glucose.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Glucose { get; set; }
#nullable restore
#else
        public string Glucose { get; set; }
#endif
        /// <summary>Method used to obtain glucose, Finger or Sensor.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? GlucoseType { get; set; }
#nullable restore
#else
        public string GlucoseType { get; set; }
#endif
        /// <summary>Amount of insulin, if any.</summary>
        public float? Insulin { get; set; }
        /// <summary>Description/notes of treatment.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Notes { get; set; }
#nullable restore
#else
        public string Notes { get; set; }
#endif
        /// <summary>Eventual basal change in percent.</summary>
        public float? Percent { get; set; }
        /// <summary>How many minutes the bolus was given before the meal started.</summary>
        public float? PreBolus { get; set; }
        /// <summary>Name of the profile to which the pump has been switched.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Profile { get; set; }
#nullable restore
#else
        public string Profile { get; set; }
#endif
        /// <summary>Amount of protein given.</summary>
        public float? Protein { get; set; }
        /// <summary>For example the reason why the profile has been switched or why the temporary target has been set.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Reason { get; set; }
#nullable restore
#else
        public string Reason { get; set; }
#endif
        /// <summary>Extended part of combo bolus (in percent).</summary>
        public float? SplitExt { get; set; }
        /// <summary>Immediate part of combo bolus (in percent).</summary>
        public float? SplitNow { get; set; }
        /// <summary>Bottom limit of temporary target.</summary>
        public float? TargetBottom { get; set; }
        /// <summary>Top limit of temporary target.</summary>
        public float? TargetTop { get; set; }
        /// <summary>The units for the glucose value, mg/dl or mmol/l. It is strongly recommended to fill in this field when `glucose` is entered.</summary>
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
        public static new Treatment CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Treatment();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public new IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>>(base.GetFieldDeserializers()) {
                {"absolute", n => { Absolute = n.GetFloatValue(); } },
                {"carbs", n => { Carbs = n.GetFloatValue(); } },
                {"duration", n => { Duration = n.GetFloatValue(); } },
                {"enteredBy", n => { EnteredBy = n.GetStringValue(); } },
                {"eventType", n => { EventType = n.GetStringValue(); } },
                {"fat", n => { Fat = n.GetFloatValue(); } },
                {"glucose", n => { Glucose = n.GetStringValue(); } },
                {"glucoseType", n => { GlucoseType = n.GetStringValue(); } },
                {"insulin", n => { Insulin = n.GetFloatValue(); } },
                {"notes", n => { Notes = n.GetStringValue(); } },
                {"percent", n => { Percent = n.GetFloatValue(); } },
                {"preBolus", n => { PreBolus = n.GetFloatValue(); } },
                {"profile", n => { Profile = n.GetStringValue(); } },
                {"protein", n => { Protein = n.GetFloatValue(); } },
                {"reason", n => { Reason = n.GetStringValue(); } },
                {"splitExt", n => { SplitExt = n.GetFloatValue(); } },
                {"splitNow", n => { SplitNow = n.GetFloatValue(); } },
                {"targetBottom", n => { TargetBottom = n.GetFloatValue(); } },
                {"targetTop", n => { TargetTop = n.GetFloatValue(); } },
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
            writer.WriteFloatValue("absolute", Absolute);
            writer.WriteFloatValue("carbs", Carbs);
            writer.WriteFloatValue("duration", Duration);
            writer.WriteStringValue("enteredBy", EnteredBy);
            writer.WriteStringValue("eventType", EventType);
            writer.WriteFloatValue("fat", Fat);
            writer.WriteStringValue("glucose", Glucose);
            writer.WriteStringValue("glucoseType", GlucoseType);
            writer.WriteFloatValue("insulin", Insulin);
            writer.WriteStringValue("notes", Notes);
            writer.WriteFloatValue("percent", Percent);
            writer.WriteFloatValue("preBolus", PreBolus);
            writer.WriteStringValue("profile", Profile);
            writer.WriteFloatValue("protein", Protein);
            writer.WriteStringValue("reason", Reason);
            writer.WriteFloatValue("splitExt", SplitExt);
            writer.WriteFloatValue("splitNow", SplitNow);
            writer.WriteFloatValue("targetBottom", TargetBottom);
            writer.WriteFloatValue("targetTop", TargetTop);
            writer.WriteStringValue("units", Units);
        }
    }
}
