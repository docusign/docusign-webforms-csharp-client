/* 
 * Web Forms API version 1.1
 *
 * The Web Forms API facilitates generating semantic HTML forms around everyday contracts. 
 *
 * OpenAPI spec version: 1.1.0
 * Contact: devcenter@docusign.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System.Collections.Generic;
using System.Net;
using System.Net.Http.Headers;

namespace DocuSign.WebForms.Client
{
    public class DocuSignResponse
    {
        readonly HttpStatusCode statusCode = HttpStatusCode.OK;
        readonly IDictionary<string, string> headers = null;
        readonly string errorMessage = string.Empty;
        readonly string contentType = string.Empty;
        readonly byte[] rawBytes = null;

        public byte[] RawBytes => rawBytes;

        public string ContentType => contentType;

        public HttpStatusCode StatusCode => statusCode;
        
        public string Content => rawBytes != null ? System.Text.Encoding.UTF8.GetString(rawBytes) : null;
        
        public string ErrorMessage => errorMessage;

        public IDictionary<string, string> Headers => headers;

        public DocuSignResponse(HttpStatusCode _statusCode, IDictionary<string, string> _headers, byte[] _rawBytes, string _contentType)
        {
            statusCode = _statusCode;
            headers = _headers;
            rawBytes = _rawBytes;
            contentType = _contentType;
        }
    }
}
