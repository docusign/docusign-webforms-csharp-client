/* 
 * Web Forms API version 1.1
 *
 * The Web Forms API facilitates generating semantic HTML forms around everyday contracts. 
 *
 * OpenAPI spec version: 1.1.0
 * Contact: devcenter@docusign.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace DocuSign.WebForms.Model
{
    /// <summary>
    /// Form metadata
    /// </summary>
    [DataContract]
    public partial class WebFormMetadata :  IEquatable<WebFormMetadata>, IValidatableObject
    {
        public WebFormMetadata()
        {
            // Empty Constructor
        }

        /// <summary>
        /// The source from which the webform is created. Accepted values are [templates, blank, form]
        /// </summary>
        /// <value>The source from which the webform is created. Accepted values are [templates, blank, form]</value>
        [DataMember(Name="source", EmitDefaultValue=false)]
        public WebFormSource? Source { get; set; }
        /// <summary>
        /// Represents webform type. Possible values are [standalone, hasEsignTemplate]
        /// </summary>
        /// <value>Represents webform type. Possible values are [standalone, hasEsignTemplate]</value>
        [DataMember(Name="type", EmitDefaultValue=false)]
        public WebFormType? Type { get; set; }
        /// <summary>
        /// Initializes a new instance of the <see cref="WebFormMetadata" /> class.
        /// </summary>
        /// <param name="Source">The source from which the webform is created. Accepted values are [templates, blank, form].</param>
        /// <param name="Type">Represents webform type. Possible values are [standalone, hasEsignTemplate].</param>
        /// <param name="SourceFormId">The source form id from which the webform is created..</param>
        /// <param name="Owner">The user that created the form or has been transferred ownership.</param>
        /// <param name="Sender">The user that has added their consent to the form for sending actions.</param>
        /// <param name="LastModifiedBy">Track the user that last modified anything related to the form.</param>
        /// <param name="FormContentModifiedBy">Track the user that last modified the form content.</param>
        /// <param name="FormPropertiesModifiedBy">Track the user that last modified the form properties.</param>
        /// <param name="LastPublishedBy">Track the user that last published a draft version to active.</param>
        /// <param name="LastEnabledBy">Track the user that last unpublished an active version.</param>
        /// <param name="LastDisabledBy">Track the user that last unpublished an active version.</param>
        /// <param name="ArchivedDateTime">The last time the web form was archived.</param>
        /// <param name="CreatedDateTime">Track the time the web form was created.</param>
        /// <param name="LastModifiedDateTime">The last time anything was modified on the form.</param>
        /// <param name="FormContentModifiedDateTime">Track the last time web form content changed..</param>
        /// <param name="FormPropertiesModifiedDateTime">Track the last time the form properties changed..</param>
        /// <param name="LastPublishedDateTime">Track the last time a draft version was published to active.</param>
        /// <param name="LastEnabledDateTime">Track the last time the form was enabled.</param>
        /// <param name="LastDisabledDateTime">Track the last time the form was disabled.</param>
        /// <param name="LastSenderConsentDateTime">Track the last time a user added their consent for the form..</param>
        /// <param name="PublishedSlug">The public friendly slug that is used to access the form from the player.</param>
        /// <param name="PublishedComponentNames">A dictionary containing the mapping of component names to their respective component types for all the published components..</param>
        public WebFormMetadata(WebFormSource? Source = default(WebFormSource?), WebFormType? Type = default(WebFormType?), string SourceFormId = default(string), WebFormUserInfo Owner = default(WebFormUserInfo), WebFormUserInfo Sender = default(WebFormUserInfo), WebFormUserInfo LastModifiedBy = default(WebFormUserInfo), WebFormUserInfo FormContentModifiedBy = default(WebFormUserInfo), WebFormUserInfo FormPropertiesModifiedBy = default(WebFormUserInfo), WebFormUserInfo LastPublishedBy = default(WebFormUserInfo), WebFormUserInfo LastEnabledBy = default(WebFormUserInfo), WebFormUserInfo LastDisabledBy = default(WebFormUserInfo), DateTime? ArchivedDateTime = default(DateTime?), DateTime? CreatedDateTime = default(DateTime?), DateTime? LastModifiedDateTime = default(DateTime?), DateTime? FormContentModifiedDateTime = default(DateTime?), DateTime? FormPropertiesModifiedDateTime = default(DateTime?), DateTime? LastPublishedDateTime = default(DateTime?), DateTime? LastEnabledDateTime = default(DateTime?), DateTime? LastDisabledDateTime = default(DateTime?), DateTime? LastSenderConsentDateTime = default(DateTime?), string PublishedSlug = default(string), Dictionary<string, WebFormComponentType> PublishedComponentNames = default(Dictionary<string, WebFormComponentType>))
        {
            this.Source = Source;
            this.Type = Type;
            this.SourceFormId = SourceFormId;
            this.Owner = Owner;
            this.Sender = Sender;
            this.LastModifiedBy = LastModifiedBy;
            this.FormContentModifiedBy = FormContentModifiedBy;
            this.FormPropertiesModifiedBy = FormPropertiesModifiedBy;
            this.LastPublishedBy = LastPublishedBy;
            this.LastEnabledBy = LastEnabledBy;
            this.LastDisabledBy = LastDisabledBy;
            this.ArchivedDateTime = ArchivedDateTime;
            this.CreatedDateTime = CreatedDateTime;
            this.LastModifiedDateTime = LastModifiedDateTime;
            this.FormContentModifiedDateTime = FormContentModifiedDateTime;
            this.FormPropertiesModifiedDateTime = FormPropertiesModifiedDateTime;
            this.LastPublishedDateTime = LastPublishedDateTime;
            this.LastEnabledDateTime = LastEnabledDateTime;
            this.LastDisabledDateTime = LastDisabledDateTime;
            this.LastSenderConsentDateTime = LastSenderConsentDateTime;
            this.PublishedSlug = PublishedSlug;
            this.PublishedComponentNames = PublishedComponentNames;
        }
        
        /// <summary>
        /// The source form id from which the webform is created.
        /// </summary>
        /// <value>The source form id from which the webform is created.</value>
        [DataMember(Name="sourceFormId", EmitDefaultValue=false)]
        public string SourceFormId { get; set; }
        /// <summary>
        /// The user that created the form or has been transferred ownership
        /// </summary>
        /// <value>The user that created the form or has been transferred ownership</value>
        [DataMember(Name="owner", EmitDefaultValue=false)]
        public WebFormUserInfo Owner { get; set; }
        /// <summary>
        /// The user that has added their consent to the form for sending actions
        /// </summary>
        /// <value>The user that has added their consent to the form for sending actions</value>
        [DataMember(Name="sender", EmitDefaultValue=false)]
        public WebFormUserInfo Sender { get; set; }
        /// <summary>
        /// Track the user that last modified anything related to the form
        /// </summary>
        /// <value>Track the user that last modified anything related to the form</value>
        [DataMember(Name="lastModifiedBy", EmitDefaultValue=false)]
        public WebFormUserInfo LastModifiedBy { get; set; }
        /// <summary>
        /// Track the user that last modified the form content
        /// </summary>
        /// <value>Track the user that last modified the form content</value>
        [DataMember(Name="formContentModifiedBy", EmitDefaultValue=false)]
        public WebFormUserInfo FormContentModifiedBy { get; set; }
        /// <summary>
        /// Track the user that last modified the form properties
        /// </summary>
        /// <value>Track the user that last modified the form properties</value>
        [DataMember(Name="formPropertiesModifiedBy", EmitDefaultValue=false)]
        public WebFormUserInfo FormPropertiesModifiedBy { get; set; }
        /// <summary>
        /// Track the user that last published a draft version to active
        /// </summary>
        /// <value>Track the user that last published a draft version to active</value>
        [DataMember(Name="lastPublishedBy", EmitDefaultValue=false)]
        public WebFormUserInfo LastPublishedBy { get; set; }
        /// <summary>
        /// Track the user that last unpublished an active version
        /// </summary>
        /// <value>Track the user that last unpublished an active version</value>
        [DataMember(Name="lastEnabledBy", EmitDefaultValue=false)]
        public WebFormUserInfo LastEnabledBy { get; set; }
        /// <summary>
        /// Track the user that last unpublished an active version
        /// </summary>
        /// <value>Track the user that last unpublished an active version</value>
        [DataMember(Name="lastDisabledBy", EmitDefaultValue=false)]
        public WebFormUserInfo LastDisabledBy { get; set; }
        /// <summary>
        /// The last time the web form was archived
        /// </summary>
        /// <value>The last time the web form was archived</value>
        [DataMember(Name="archivedDateTime", EmitDefaultValue=false)]
        public DateTime? ArchivedDateTime { get; set; }
        /// <summary>
        /// Track the time the web form was created
        /// </summary>
        /// <value>Track the time the web form was created</value>
        [DataMember(Name="createdDateTime", EmitDefaultValue=false)]
        public DateTime? CreatedDateTime { get; set; }
        /// <summary>
        /// The last time anything was modified on the form
        /// </summary>
        /// <value>The last time anything was modified on the form</value>
        [DataMember(Name="lastModifiedDateTime", EmitDefaultValue=false)]
        public DateTime? LastModifiedDateTime { get; set; }
        /// <summary>
        /// Track the last time web form content changed.
        /// </summary>
        /// <value>Track the last time web form content changed.</value>
        [DataMember(Name="formContentModifiedDateTime", EmitDefaultValue=false)]
        public DateTime? FormContentModifiedDateTime { get; set; }
        /// <summary>
        /// Track the last time the form properties changed.
        /// </summary>
        /// <value>Track the last time the form properties changed.</value>
        [DataMember(Name="formPropertiesModifiedDateTime", EmitDefaultValue=false)]
        public DateTime? FormPropertiesModifiedDateTime { get; set; }
        /// <summary>
        /// Track the last time a draft version was published to active
        /// </summary>
        /// <value>Track the last time a draft version was published to active</value>
        [DataMember(Name="lastPublishedDateTime", EmitDefaultValue=false)]
        public DateTime? LastPublishedDateTime { get; set; }
        /// <summary>
        /// Track the last time the form was enabled
        /// </summary>
        /// <value>Track the last time the form was enabled</value>
        [DataMember(Name="lastEnabledDateTime", EmitDefaultValue=false)]
        public DateTime? LastEnabledDateTime { get; set; }
        /// <summary>
        /// Track the last time the form was disabled
        /// </summary>
        /// <value>Track the last time the form was disabled</value>
        [DataMember(Name="lastDisabledDateTime", EmitDefaultValue=false)]
        public DateTime? LastDisabledDateTime { get; set; }
        /// <summary>
        /// Track the last time a user added their consent for the form.
        /// </summary>
        /// <value>Track the last time a user added their consent for the form.</value>
        [DataMember(Name="lastSenderConsentDateTime", EmitDefaultValue=false)]
        public DateTime? LastSenderConsentDateTime { get; set; }
        /// <summary>
        /// The public friendly slug that is used to access the form from the player
        /// </summary>
        /// <value>The public friendly slug that is used to access the form from the player</value>
        [DataMember(Name="publishedSlug", EmitDefaultValue=false)]
        public string PublishedSlug { get; set; }
        /// <summary>
        /// A dictionary containing the mapping of component names to their respective component types for all the published components.
        /// </summary>
        /// <value>A dictionary containing the mapping of component names to their respective component types for all the published components.</value>
        [DataMember(Name="publishedComponentNames", EmitDefaultValue=false)]
        public Dictionary<string, WebFormComponentType> PublishedComponentNames { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WebFormMetadata {\n");
            sb.Append("  Source: ").Append(Source).Append("\n");
            sb.Append("  Type: ").Append(Type).Append("\n");
            sb.Append("  SourceFormId: ").Append(SourceFormId).Append("\n");
            sb.Append("  Owner: ").Append(Owner).Append("\n");
            sb.Append("  Sender: ").Append(Sender).Append("\n");
            sb.Append("  LastModifiedBy: ").Append(LastModifiedBy).Append("\n");
            sb.Append("  FormContentModifiedBy: ").Append(FormContentModifiedBy).Append("\n");
            sb.Append("  FormPropertiesModifiedBy: ").Append(FormPropertiesModifiedBy).Append("\n");
            sb.Append("  LastPublishedBy: ").Append(LastPublishedBy).Append("\n");
            sb.Append("  LastEnabledBy: ").Append(LastEnabledBy).Append("\n");
            sb.Append("  LastDisabledBy: ").Append(LastDisabledBy).Append("\n");
            sb.Append("  ArchivedDateTime: ").Append(ArchivedDateTime).Append("\n");
            sb.Append("  CreatedDateTime: ").Append(CreatedDateTime).Append("\n");
            sb.Append("  LastModifiedDateTime: ").Append(LastModifiedDateTime).Append("\n");
            sb.Append("  FormContentModifiedDateTime: ").Append(FormContentModifiedDateTime).Append("\n");
            sb.Append("  FormPropertiesModifiedDateTime: ").Append(FormPropertiesModifiedDateTime).Append("\n");
            sb.Append("  LastPublishedDateTime: ").Append(LastPublishedDateTime).Append("\n");
            sb.Append("  LastEnabledDateTime: ").Append(LastEnabledDateTime).Append("\n");
            sb.Append("  LastDisabledDateTime: ").Append(LastDisabledDateTime).Append("\n");
            sb.Append("  LastSenderConsentDateTime: ").Append(LastSenderConsentDateTime).Append("\n");
            sb.Append("  PublishedSlug: ").Append(PublishedSlug).Append("\n");
            sb.Append("  PublishedComponentNames: ").Append(PublishedComponentNames).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }
  
        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as WebFormMetadata);
        }

        /// <summary>
        /// Returns true if WebFormMetadata instances are equal
        /// </summary>
        /// <param name="other">Instance of WebFormMetadata to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WebFormMetadata other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Source == other.Source ||
                    this.Source != null &&
                    this.Source.Equals(other.Source)
                ) && 
                (
                    this.Type == other.Type ||
                    this.Type != null &&
                    this.Type.Equals(other.Type)
                ) && 
                (
                    this.SourceFormId == other.SourceFormId ||
                    this.SourceFormId != null &&
                    this.SourceFormId.Equals(other.SourceFormId)
                ) && 
                (
                    this.Owner == other.Owner ||
                    this.Owner != null &&
                    this.Owner.Equals(other.Owner)
                ) && 
                (
                    this.Sender == other.Sender ||
                    this.Sender != null &&
                    this.Sender.Equals(other.Sender)
                ) && 
                (
                    this.LastModifiedBy == other.LastModifiedBy ||
                    this.LastModifiedBy != null &&
                    this.LastModifiedBy.Equals(other.LastModifiedBy)
                ) && 
                (
                    this.FormContentModifiedBy == other.FormContentModifiedBy ||
                    this.FormContentModifiedBy != null &&
                    this.FormContentModifiedBy.Equals(other.FormContentModifiedBy)
                ) && 
                (
                    this.FormPropertiesModifiedBy == other.FormPropertiesModifiedBy ||
                    this.FormPropertiesModifiedBy != null &&
                    this.FormPropertiesModifiedBy.Equals(other.FormPropertiesModifiedBy)
                ) && 
                (
                    this.LastPublishedBy == other.LastPublishedBy ||
                    this.LastPublishedBy != null &&
                    this.LastPublishedBy.Equals(other.LastPublishedBy)
                ) && 
                (
                    this.LastEnabledBy == other.LastEnabledBy ||
                    this.LastEnabledBy != null &&
                    this.LastEnabledBy.Equals(other.LastEnabledBy)
                ) && 
                (
                    this.LastDisabledBy == other.LastDisabledBy ||
                    this.LastDisabledBy != null &&
                    this.LastDisabledBy.Equals(other.LastDisabledBy)
                ) && 
                (
                    this.ArchivedDateTime == other.ArchivedDateTime ||
                    this.ArchivedDateTime != null &&
                    this.ArchivedDateTime.Equals(other.ArchivedDateTime)
                ) && 
                (
                    this.CreatedDateTime == other.CreatedDateTime ||
                    this.CreatedDateTime != null &&
                    this.CreatedDateTime.Equals(other.CreatedDateTime)
                ) && 
                (
                    this.LastModifiedDateTime == other.LastModifiedDateTime ||
                    this.LastModifiedDateTime != null &&
                    this.LastModifiedDateTime.Equals(other.LastModifiedDateTime)
                ) && 
                (
                    this.FormContentModifiedDateTime == other.FormContentModifiedDateTime ||
                    this.FormContentModifiedDateTime != null &&
                    this.FormContentModifiedDateTime.Equals(other.FormContentModifiedDateTime)
                ) && 
                (
                    this.FormPropertiesModifiedDateTime == other.FormPropertiesModifiedDateTime ||
                    this.FormPropertiesModifiedDateTime != null &&
                    this.FormPropertiesModifiedDateTime.Equals(other.FormPropertiesModifiedDateTime)
                ) && 
                (
                    this.LastPublishedDateTime == other.LastPublishedDateTime ||
                    this.LastPublishedDateTime != null &&
                    this.LastPublishedDateTime.Equals(other.LastPublishedDateTime)
                ) && 
                (
                    this.LastEnabledDateTime == other.LastEnabledDateTime ||
                    this.LastEnabledDateTime != null &&
                    this.LastEnabledDateTime.Equals(other.LastEnabledDateTime)
                ) && 
                (
                    this.LastDisabledDateTime == other.LastDisabledDateTime ||
                    this.LastDisabledDateTime != null &&
                    this.LastDisabledDateTime.Equals(other.LastDisabledDateTime)
                ) && 
                (
                    this.LastSenderConsentDateTime == other.LastSenderConsentDateTime ||
                    this.LastSenderConsentDateTime != null &&
                    this.LastSenderConsentDateTime.Equals(other.LastSenderConsentDateTime)
                ) && 
                (
                    this.PublishedSlug == other.PublishedSlug ||
                    this.PublishedSlug != null &&
                    this.PublishedSlug.Equals(other.PublishedSlug)
                ) && 
                (
                    this.PublishedComponentNames == other.PublishedComponentNames ||
                    this.PublishedComponentNames != null &&
                    this.PublishedComponentNames.SequenceEqual(other.PublishedComponentNames)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                if (this.Source != null)
                    hash = hash * 59 + this.Source.GetHashCode();
                if (this.Type != null)
                    hash = hash * 59 + this.Type.GetHashCode();
                if (this.SourceFormId != null)
                    hash = hash * 59 + this.SourceFormId.GetHashCode();
                if (this.Owner != null)
                    hash = hash * 59 + this.Owner.GetHashCode();
                if (this.Sender != null)
                    hash = hash * 59 + this.Sender.GetHashCode();
                if (this.LastModifiedBy != null)
                    hash = hash * 59 + this.LastModifiedBy.GetHashCode();
                if (this.FormContentModifiedBy != null)
                    hash = hash * 59 + this.FormContentModifiedBy.GetHashCode();
                if (this.FormPropertiesModifiedBy != null)
                    hash = hash * 59 + this.FormPropertiesModifiedBy.GetHashCode();
                if (this.LastPublishedBy != null)
                    hash = hash * 59 + this.LastPublishedBy.GetHashCode();
                if (this.LastEnabledBy != null)
                    hash = hash * 59 + this.LastEnabledBy.GetHashCode();
                if (this.LastDisabledBy != null)
                    hash = hash * 59 + this.LastDisabledBy.GetHashCode();
                if (this.ArchivedDateTime != null)
                    hash = hash * 59 + this.ArchivedDateTime.GetHashCode();
                if (this.CreatedDateTime != null)
                    hash = hash * 59 + this.CreatedDateTime.GetHashCode();
                if (this.LastModifiedDateTime != null)
                    hash = hash * 59 + this.LastModifiedDateTime.GetHashCode();
                if (this.FormContentModifiedDateTime != null)
                    hash = hash * 59 + this.FormContentModifiedDateTime.GetHashCode();
                if (this.FormPropertiesModifiedDateTime != null)
                    hash = hash * 59 + this.FormPropertiesModifiedDateTime.GetHashCode();
                if (this.LastPublishedDateTime != null)
                    hash = hash * 59 + this.LastPublishedDateTime.GetHashCode();
                if (this.LastEnabledDateTime != null)
                    hash = hash * 59 + this.LastEnabledDateTime.GetHashCode();
                if (this.LastDisabledDateTime != null)
                    hash = hash * 59 + this.LastDisabledDateTime.GetHashCode();
                if (this.LastSenderConsentDateTime != null)
                    hash = hash * 59 + this.LastSenderConsentDateTime.GetHashCode();
                if (this.PublishedSlug != null)
                    hash = hash * 59 + this.PublishedSlug.GetHashCode();
                if (this.PublishedComponentNames != null)
                    hash = hash * 59 + this.PublishedComponentNames.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }
}
