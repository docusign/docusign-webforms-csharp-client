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
    /// A list of 0 or more paginated and filtered form summary items
    /// </summary>
    [DataContract]
    public partial class WebFormSummaryList :  IEquatable<WebFormSummaryList>, IValidatableObject
    {
        public WebFormSummaryList()
        {
            // Empty Constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebFormSummaryList" /> class.
        /// </summary>
        /// <param name="Items">List of web form summary items.</param>
        /// <param name="ResultSetSize">Result set size for current page.</param>
        /// <param name="TotalSetSize">Total result set size.</param>
        /// <param name="StartPosition">Starting position of fields returned for the current page.</param>
        /// <param name="EndPosition">Ending position of fields returned for the current page.</param>
        /// <param name="NextUrl">Url for the next page of results.</param>
        /// <param name="PreviousUrl">Url for the previous page of results.</param>
        public WebFormSummaryList(List<WebFormSummary> Items = default(List<WebFormSummary>), decimal? ResultSetSize = default(decimal?), decimal? TotalSetSize = default(decimal?), decimal? StartPosition = default(decimal?), decimal? EndPosition = default(decimal?), string NextUrl = default(string), string PreviousUrl = default(string))
        {
            this.Items = Items;
            this.ResultSetSize = ResultSetSize;
            this.TotalSetSize = TotalSetSize;
            this.StartPosition = StartPosition;
            this.EndPosition = EndPosition;
            this.NextUrl = NextUrl;
            this.PreviousUrl = PreviousUrl;
        }
        
        /// <summary>
        /// List of web form summary items
        /// </summary>
        /// <value>List of web form summary items</value>
        [DataMember(Name="items", EmitDefaultValue=false)]
        public List<WebFormSummary> Items { get; set; }
        /// <summary>
        /// Result set size for current page
        /// </summary>
        /// <value>Result set size for current page</value>
        [DataMember(Name="resultSetSize", EmitDefaultValue=false)]
        public decimal? ResultSetSize { get; set; }
        /// <summary>
        /// Total result set size
        /// </summary>
        /// <value>Total result set size</value>
        [DataMember(Name="totalSetSize", EmitDefaultValue=false)]
        public decimal? TotalSetSize { get; set; }
        /// <summary>
        /// Starting position of fields returned for the current page
        /// </summary>
        /// <value>Starting position of fields returned for the current page</value>
        [DataMember(Name="startPosition", EmitDefaultValue=false)]
        public decimal? StartPosition { get; set; }
        /// <summary>
        /// Ending position of fields returned for the current page
        /// </summary>
        /// <value>Ending position of fields returned for the current page</value>
        [DataMember(Name="endPosition", EmitDefaultValue=false)]
        public decimal? EndPosition { get; set; }
        /// <summary>
        /// Url for the next page of results
        /// </summary>
        /// <value>Url for the next page of results</value>
        [DataMember(Name="nextUrl", EmitDefaultValue=false)]
        public string NextUrl { get; set; }
        /// <summary>
        /// Url for the previous page of results
        /// </summary>
        /// <value>Url for the previous page of results</value>
        [DataMember(Name="previousUrl", EmitDefaultValue=false)]
        public string PreviousUrl { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WebFormSummaryList {\n");
            sb.Append("  Items: ").Append(Items).Append("\n");
            sb.Append("  ResultSetSize: ").Append(ResultSetSize).Append("\n");
            sb.Append("  TotalSetSize: ").Append(TotalSetSize).Append("\n");
            sb.Append("  StartPosition: ").Append(StartPosition).Append("\n");
            sb.Append("  EndPosition: ").Append(EndPosition).Append("\n");
            sb.Append("  NextUrl: ").Append(NextUrl).Append("\n");
            sb.Append("  PreviousUrl: ").Append(PreviousUrl).Append("\n");
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
            return this.Equals(obj as WebFormSummaryList);
        }

        /// <summary>
        /// Returns true if WebFormSummaryList instances are equal
        /// </summary>
        /// <param name="other">Instance of WebFormSummaryList to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WebFormSummaryList other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Items == other.Items ||
                    this.Items != null &&
                    this.Items.SequenceEqual(other.Items)
                ) && 
                (
                    this.ResultSetSize == other.ResultSetSize ||
                    this.ResultSetSize != null &&
                    this.ResultSetSize.Equals(other.ResultSetSize)
                ) && 
                (
                    this.TotalSetSize == other.TotalSetSize ||
                    this.TotalSetSize != null &&
                    this.TotalSetSize.Equals(other.TotalSetSize)
                ) && 
                (
                    this.StartPosition == other.StartPosition ||
                    this.StartPosition != null &&
                    this.StartPosition.Equals(other.StartPosition)
                ) && 
                (
                    this.EndPosition == other.EndPosition ||
                    this.EndPosition != null &&
                    this.EndPosition.Equals(other.EndPosition)
                ) && 
                (
                    this.NextUrl == other.NextUrl ||
                    this.NextUrl != null &&
                    this.NextUrl.Equals(other.NextUrl)
                ) && 
                (
                    this.PreviousUrl == other.PreviousUrl ||
                    this.PreviousUrl != null &&
                    this.PreviousUrl.Equals(other.PreviousUrl)
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
                if (this.Items != null)
                    hash = hash * 59 + this.Items.GetHashCode();
                if (this.ResultSetSize != null)
                    hash = hash * 59 + this.ResultSetSize.GetHashCode();
                if (this.TotalSetSize != null)
                    hash = hash * 59 + this.TotalSetSize.GetHashCode();
                if (this.StartPosition != null)
                    hash = hash * 59 + this.StartPosition.GetHashCode();
                if (this.EndPosition != null)
                    hash = hash * 59 + this.EndPosition.GetHashCode();
                if (this.NextUrl != null)
                    hash = hash * 59 + this.NextUrl.GetHashCode();
                if (this.PreviousUrl != null)
                    hash = hash * 59 + this.PreviousUrl.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            yield break;
        }
    }
}
