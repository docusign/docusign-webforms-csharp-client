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
    /// Information about a DocuSign system user.  The user exists within the account associated with the form.
    /// </summary>
    [DataContract]
    public partial class WebFormUserInfo :  IEquatable<WebFormUserInfo>, IValidatableObject
    {
        public WebFormUserInfo()
        {
            // Empty Constructor
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebFormUserInfo" /> class.
        /// </summary>
        /// <param name="UserId">DocuSign user identifier..</param>
        /// <param name="UserName">Name of the user that can be displayed in the user interface..</param>
        public WebFormUserInfo(string UserId = default(string), string UserName = default(string))
        {
            this.UserId = UserId;
            this.UserName = UserName;
        }
        
        /// <summary>
        /// DocuSign user identifier.
        /// </summary>
        /// <value>DocuSign user identifier.</value>
        [DataMember(Name="userId", EmitDefaultValue=false)]
        public string UserId { get; set; }
        /// <summary>
        /// Name of the user that can be displayed in the user interface.
        /// </summary>
        /// <value>Name of the user that can be displayed in the user interface.</value>
        [DataMember(Name="userName", EmitDefaultValue=false)]
        public string UserName { get; set; }
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class WebFormUserInfo {\n");
            sb.Append("  UserId: ").Append(UserId).Append("\n");
            sb.Append("  UserName: ").Append(UserName).Append("\n");
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
            return this.Equals(obj as WebFormUserInfo);
        }

        /// <summary>
        /// Returns true if WebFormUserInfo instances are equal
        /// </summary>
        /// <param name="other">Instance of WebFormUserInfo to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(WebFormUserInfo other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.UserId == other.UserId ||
                    this.UserId != null &&
                    this.UserId.Equals(other.UserId)
                ) && 
                (
                    this.UserName == other.UserName ||
                    this.UserName != null &&
                    this.UserName.Equals(other.UserName)
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
                if (this.UserId != null)
                    hash = hash * 59 + this.UserId.GetHashCode();
                if (this.UserName != null)
                    hash = hash * 59 + this.UserName.GetHashCode();
                return hash;
            }
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        { 
            // UserName (string) maxLength
            if(this.UserName != null && this.UserName.Length > 150)
            {
                yield return new ValidationResult("Invalid value for UserName, length must be less than 150.", new [] { "UserName" });
            }

            yield break;
        }
    }
}
