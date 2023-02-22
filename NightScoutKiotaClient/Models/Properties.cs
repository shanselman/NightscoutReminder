using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class Properties : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>The basal property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Basal { get; set; }
#nullable restore
#else
        public ObjectObject Basal { get; set; }
#endif
        /// <summary>The bgnow property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Bgnow { get; set; }
#nullable restore
#else
        public ObjectObject Bgnow { get; set; }
#endif
        /// <summary>The buckets property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public List<ObjectObject>? Buckets { get; set; }
#nullable restore
#else
        public List<ObjectObject> Buckets { get; set; }
#endif
        /// <summary>The bwp property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Bwp { get; set; }
#nullable restore
#else
        public ObjectObject Bwp { get; set; }
#endif
        /// <summary>The cage property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NightScoutV3.Models.Cage? Cage { get; set; }
#nullable restore
#else
        public NightScoutV3.Models.Cage Cage { get; set; }
#endif
        /// <summary>The cob property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Cob { get; set; }
#nullable restore
#else
        public ObjectObject Cob { get; set; }
#endif
        /// <summary>The dbsize property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Dbsize { get; set; }
#nullable restore
#else
        public ObjectObject Dbsize { get; set; }
#endif
        /// <summary>The delta property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Delta { get; set; }
#nullable restore
#else
        public ObjectObject Delta { get; set; }
#endif
        /// <summary>The direction property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Direction { get; set; }
#nullable restore
#else
        public ObjectObject Direction { get; set; }
#endif
        /// <summary>The iob property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Iob { get; set; }
#nullable restore
#else
        public ObjectObject Iob { get; set; }
#endif
        /// <summary>The loop property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Loop { get; set; }
#nullable restore
#else
        public ObjectObject Loop { get; set; }
#endif
        /// <summary>The pump property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Pump { get; set; }
#nullable restore
#else
        public ObjectObject Pump { get; set; }
#endif
        /// <summary>The runtimestate property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NightScoutV3.Models.RuntimeState? Runtimestate { get; set; }
#nullable restore
#else
        public NightScoutV3.Models.RuntimeState Runtimestate { get; set; }
#endif
        /// <summary>The sage property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public NightScoutV3.Models.Sage? Sage { get; set; }
#nullable restore
#else
        public NightScoutV3.Models.Sage Sage { get; set; }
#endif
        /// <summary>The upbat property</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public ObjectObject? Upbat { get; set; }
#nullable restore
#else
        public ObjectObject Upbat { get; set; }
#endif
        /// <summary>
        /// Instantiates a new Properties and sets the default values.
        /// </summary>
        public Properties() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static Properties CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new Properties();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"basal", n => { Basal = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
                {"bgnow", n => { Bgnow = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
                {"buckets", n => { Buckets = n.GetCollectionOfObjectValues<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue)?.ToList(); } },
                {"bwp", n => { Bwp = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
                {"cage", n => { Cage = n.GetObjectValue<NightScoutV3.Models.Cage>(NightScoutV3.Models.Cage.CreateFromDiscriminatorValue); } },
                {"cob", n => { Cob = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
                {"dbsize", n => { Dbsize = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
                {"delta", n => { Delta = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
                {"direction", n => { Direction = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
                {"iob", n => { Iob = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
                {"loop", n => { Loop = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
                {"pump", n => { Pump = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
                {"runtimestate", n => { Runtimestate = n.GetObjectValue<NightScoutV3.Models.RuntimeState>(NightScoutV3.Models.RuntimeState.CreateFromDiscriminatorValue); } },
                {"sage", n => { Sage = n.GetObjectValue<NightScoutV3.Models.Sage>(NightScoutV3.Models.Sage.CreateFromDiscriminatorValue); } },
                {"upbat", n => { Upbat = n.GetObjectValue<ObjectObject>(ObjectObject.CreateFromDiscriminatorValue); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteObjectValue<ObjectObject>("basal", Basal);
            writer.WriteObjectValue<ObjectObject>("bgnow", Bgnow);
            writer.WriteCollectionOfObjectValues<ObjectObject>("buckets", Buckets);
            writer.WriteObjectValue<ObjectObject>("bwp", Bwp);
            writer.WriteObjectValue<NightScoutV3.Models.Cage>("cage", Cage);
            writer.WriteObjectValue<ObjectObject>("cob", Cob);
            writer.WriteObjectValue<ObjectObject>("dbsize", Dbsize);
            writer.WriteObjectValue<ObjectObject>("delta", Delta);
            writer.WriteObjectValue<ObjectObject>("direction", Direction);
            writer.WriteObjectValue<ObjectObject>("iob", Iob);
            writer.WriteObjectValue<ObjectObject>("loop", Loop);
            writer.WriteObjectValue<ObjectObject>("pump", Pump);
            writer.WriteObjectValue<NightScoutV3.Models.RuntimeState>("runtimestate", Runtimestate);
            writer.WriteObjectValue<NightScoutV3.Models.Sage>("sage", Sage);
            writer.WriteObjectValue<ObjectObject>("upbat", Upbat);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
