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
    /// The status of Web Form Instance. If the form status is INITIATED, it means the form is accessible until it is submitted or expired. If the form status is SUBMITTED, it means the form is submitted already and hence, cannot be opened again.
    /// </summary>
    /// <value>The status of Web Form Instance. If the form status is INITIATED, it means the form is accessible until it is submitted or expired. If the form status is SUBMITTED, it means the form is submitted already and hence, cannot be opened again.</value>
    
    [JsonConverter(typeof(StringEnumConverter))]
    
    public enum InstanceStatus
    {
        
        /// <summary>
        /// Enum INITIATED for value: INITIATED
        /// </summary>
        [EnumMember(Value = "INITIATED")]
        INITIATED = 1,
        
        /// <summary>
        /// Enum INPROGRESS for value: IN_PROGRESS
        /// </summary>
        [EnumMember(Value = "IN_PROGRESS")]
        INPROGRESS = 2,
        
        /// <summary>
        /// Enum SUBMITTED for value: SUBMITTED
        /// </summary>
        [EnumMember(Value = "SUBMITTED")]
        SUBMITTED = 3,
        
        /// <summary>
        /// Enum EXPIRED for value: EXPIRED
        /// </summary>
        [EnumMember(Value = "EXPIRED")]
        EXPIRED = 4,
        
        /// <summary>
        /// Enum FAILED for value: FAILED
        /// </summary>
        [EnumMember(Value = "FAILED")]
        FAILED = 5
    }

}
