using Microsoft.Kiota.Abstractions.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace NightScoutV3.Models {
    public class DocumentBase : IAdditionalDataHolder, IParsable {
        /// <summary>Stores additional data not described in the OpenAPI description found when deserializing. Can be used for serialization as well.</summary>
        public IDictionary<string, object> AdditionalData { get; set; }
        /// <summary>    Application or system in which the record was entered by human or device for the first time.    Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? App { get; set; }
#nullable restore
#else
        public string App { get; set; }
#endif
        /// <summary>    Required timestamp when the record or event occured, you can choose from three input formats    - Unix epoch in milliseconds (1525383610088)    - Unix epoch in seconds (1525383610)    - ISO 8601 with optional timezone (&apos;2018-05-03T21:40:10.088Z&apos; or &apos;2018-05-03T23:40:10.088+02:00&apos;)    The date is always stored in a normalized form - UTC with zero offset. If UTC offset was present, it is going to be set in the `utcOffset` field.    Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
        public long? Date { get; set; }
        /// <summary>    The device from which the data originated (including serial number of the device, if it is relevant and safe).    Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Device { get; set; }
#nullable restore
#else
        public string Device { get; set; }
#endif
        /// <summary>    Internally assigned database id. This field is for internal server purposes only, clients communicate with API by using identifier field.</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Id { get; set; }
#nullable restore
#else
        public string Id { get; set; }
#endif
        /// <summary>    Main addressing, required field that identifies document in the collection.     The client should not create the identifier, the server automatically assigns it when the document is inserted.    The server calculates the identifier in such a way that duplicate records are automatically merged (deduplicating is made by `date`, `device` and `eventType` fields).    The best practise for all applications is not to loose identifiers from received documents, but save them carefully for other consumer applications/systems.    API v3 has a fallback mechanism in place, for documents without `identifier` field the `identifier` is set to internal `_id`, when reading or addressing these documents.    Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Identifier { get; set; }
#nullable restore
#else
        public string Identifier { get; set; }
#endif
        /// <summary>    A flag set by client that locks the document from any changes. Every document marked with `isReadOnly=true` is forever immutable and cannot even be deleted.    Any attempt to modify the read-only document will end with status 422 UNPROCESSABLE ENTITY.</summary>
        public bool? IsReadOnly { get; set; }
        /// <summary>    A flag set by the server only for deleted documents. This field appears    only within history operation and for documents which were deleted by API v3 (and they always have a false value)    Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
        public bool? IsValid { get; set; }
        /// <summary>    Name of the security subject (within Nightscout scope) which has patched or deleted the document for the last time. This field is automatically set by the server.    Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? ModifiedBy { get; set; }
#nullable restore
#else
        public string ModifiedBy { get; set; }
#endif
        /// <summary>    The server&apos;s timestamp of document insertion into the database (Unix epoch in ms). This field appears only for documents which were inserted by API v3.    Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
        public long? SrvCreated { get; set; }
        /// <summary>    The server&apos;s timestamp of the last document modification in the database (Unix epoch in ms). This field appears  only for documents which were somehow modified by API v3 (inserted, updated or deleted).    Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
        public long? SrvModified { get; set; }
        /// <summary>    Name of the security subject (within Nightscout scope) which has created the document. This field is automatically set by the server from the passed token or JWT.    Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
#if NETSTANDARD2_1_OR_GREATER || NETCOREAPP3_1_OR_GREATER
#nullable enable
        public string? Subject { get; set; }
#nullable restore
#else
        public string Subject { get; set; }
#endif
        /// <summary>    Local UTC offset (timezone) of the event in minutes. This field can be set either directly by the client (in the incoming document) or it is automatically parsed from the `date` field.    Note&amp;#58; this field is immutable by the client (it cannot be updated or patched)</summary>
        public int? UtcOffset { get; set; }
        /// <summary>
        /// Instantiates a new DocumentBase and sets the default values.
        /// </summary>
        public DocumentBase() {
            AdditionalData = new Dictionary<string, object>();
        }
        /// <summary>
        /// Creates a new instance of the appropriate class based on discriminator value
        /// </summary>
        /// <param name="parseNode">The parse node to use to read the discriminator value and create the object</param>
        public static DocumentBase CreateFromDiscriminatorValue(IParseNode parseNode) {
            _ = parseNode ?? throw new ArgumentNullException(nameof(parseNode));
            return new DocumentBase();
        }
        /// <summary>
        /// The deserialization information for the current model
        /// </summary>
        public IDictionary<string, Action<IParseNode>> GetFieldDeserializers() {
            return new Dictionary<string, Action<IParseNode>> {
                {"app", n => { App = n.GetStringValue(); } },
                {"date", n => { Date = n.GetLongValue(); } },
                {"device", n => { Device = n.GetStringValue(); } },
                {"_id", n => { Id = n.GetStringValue(); } },
                {"identifier", n => { Identifier = n.GetStringValue(); } },
                {"isReadOnly", n => { IsReadOnly = n.GetBoolValue(); } },
                {"isValid", n => { IsValid = n.GetBoolValue(); } },
                {"modifiedBy", n => { ModifiedBy = n.GetStringValue(); } },
                {"srvCreated", n => { SrvCreated = n.GetLongValue(); } },
                {"srvModified", n => { SrvModified = n.GetLongValue(); } },
                {"subject", n => { Subject = n.GetStringValue(); } },
                {"utcOffset", n => { UtcOffset = n.GetIntValue(); } },
            };
        }
        /// <summary>
        /// Serializes information the current object
        /// </summary>
        /// <param name="writer">Serialization writer to use to serialize this model</param>
        public void Serialize(ISerializationWriter writer) {
            _ = writer ?? throw new ArgumentNullException(nameof(writer));
            writer.WriteStringValue("app", App);
            writer.WriteLongValue("date", Date);
            writer.WriteStringValue("device", Device);
            writer.WriteStringValue("_id", Id);
            writer.WriteStringValue("identifier", Identifier);
            writer.WriteBoolValue("isReadOnly", IsReadOnly);
            writer.WriteBoolValue("isValid", IsValid);
            writer.WriteStringValue("modifiedBy", ModifiedBy);
            writer.WriteLongValue("srvCreated", SrvCreated);
            writer.WriteLongValue("srvModified", SrvModified);
            writer.WriteStringValue("subject", Subject);
            writer.WriteIntValue("utcOffset", UtcOffset);
            writer.WriteAdditionalData(AdditionalData);
        }
    }
}
