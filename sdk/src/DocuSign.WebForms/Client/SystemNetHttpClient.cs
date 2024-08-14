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
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace DocuSign.WebForms.Client
{
    public class SystemNetHttpClient : IHttpClient
    {
        readonly HttpClient httpClient;

        public SystemNetHttpClient(HttpClient _client = null)
        {
            httpClient = _client ?? new HttpClient();
        }

        public DocuSignResponse SendRequest(DocuSignRequest request)
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            Task<DocuSignResponse> t = Task.Run(async () => await SendRequestAsync(request, cts.Token));
            t.Wait();
            return t.Result;
        }

        public void AddDefaultRequestHeader(string header, string value)
        {
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header, value);
        }

        public async Task<DocuSignResponse> SendRequestAsync(DocuSignRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await this.SendHttpRequestAsync(request, cancellationToken).ConfigureAwait(false);

                IDictionary<string, string> combinedHeaders = new Dictionary<string, string>();
                response.Headers.ToList().ForEach((kvp) =>
                {
                    if (!combinedHeaders.ContainsKey(kvp.Key))
                    {
                        combinedHeaders.Add(kvp.Key, kvp.Value.FirstOrDefault());
                    }
                });
                response.Content.Headers.ToList().ForEach((kvp) => {
                    if (!combinedHeaders.ContainsKey(kvp.Key))
                    {
                        combinedHeaders.Add(kvp.Key, kvp.Value.FirstOrDefault());
                    }
                });

                return new DocuSignResponse(
                    response.StatusCode,
                    combinedHeaders,
                    await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false),
                    response.Content.Headers?.ContentType?.MediaType);
            }
            catch (Exception e)
            {
                return new DocuSignResponse(e);
            }
        }

        private async Task<HttpResponseMessage> SendHttpRequestAsync(
            DocuSignRequest request,
            CancellationToken cancellationToken)
        {
            Exception requestException = null;
            HttpResponseMessage response = null;

            var httpRequest = this.BuildRequestMessage(request);

            try
            {
                response = await this.httpClient.SendAsync(httpRequest, cancellationToken)
                    .ConfigureAwait(false);
            }
            catch (HttpRequestException exception)
            {
                requestException = exception;
            }
            catch (OperationCanceledException exception)
                when (!cancellationToken.IsCancellationRequested)
            {
                requestException = exception;
            }

            if (requestException != null)
            {
                throw requestException;
            }

            return response;
        }

        bool isPostOrPutHttpMethod(HttpMethod method) => method == HttpMethod.Post || method == HttpMethod.Put;

        bool isEmptyOrJsonContentType(string contentType, List<KeyValuePair<string, string>> headerParams)
        {
            if (contentType == "application/json")
            {
                return true;
            }
            else
            {
                KeyValuePair<string, string> contentTypeHeader = headerParams.FirstOrDefault(kvp => kvp.Key.ToLower() == "content-type");
                if (contentTypeHeader.Value == "application/json" || string.IsNullOrEmpty(contentTypeHeader.Value))
                {
                    return true;
                }
            }
            return false;
        }

        private HttpRequestMessage BuildRequestMessage(DocuSignRequest request)
        {
            var requestMessage = new HttpRequestMessage(request.Method, request.Url);

            if (request.BodyContent != null)
            {
                string contentType = string.IsNullOrEmpty(request.ContentType) ? "application/json" : request.ContentType;
                if (request.BodyContent is byte[])
                {
                    requestMessage.Content = new ByteArrayContent(request.BodyContent as byte[]);
                    if (!string.IsNullOrEmpty(request?.ContentDisposition)) { requestMessage.Content.Headers.Add("Content-Disposition", request.ContentDisposition); }
                }
                else
                {
                    requestMessage.Content = new StringContent(request.BodyContent.ToString(), System.Text.Encoding.UTF8, contentType);
                }
                if (!requestMessage.Content.Headers.Contains("Content-Type")) { requestMessage.Content.Headers.Add("Content-Type", contentType); }
            }
            else
            {
                if (request.PostParams?.Count > 0 && request.FileParams?.Count > 0)
                {
                    string boundary = $"---{Guid.NewGuid()}---";
                    var multipartFormContent = new MultipartFormDataContent(boundary);

                    multipartFormContent.Add(new StringContent(string.Join("&", request.PostParams.Select(kvp => $"{kvp.Key}={System.Web.HttpUtility.UrlEncode(kvp.Value)}")), System.Text.Encoding.UTF8, "application/x-www-form-urlencoded"));

                    foreach (var file in request.FileParams)
                    {
                        var content = new ByteArrayContent(file.Content);
                        if (!string.IsNullOrEmpty(request?.ContentDisposition)) { content.Headers.Add("Content-Disposition", request?.ContentDisposition); }
                        multipartFormContent.Add(content, file.Name, file.FileName);
                    }
                    requestMessage.Content = multipartFormContent;
                }
                else if (request.PostParams?.Count > 0)
                {
                    requestMessage.Content = new StringContent(string.Join("&", request.PostParams.Select(kvp => $"{kvp.Key}={System.Web.HttpUtility.UrlEncode(kvp.Value)}")), System.Text.Encoding.UTF8, "application/x-www-form-urlencoded");
                }
                else if (request.FileParams?.Count > 0)
                {
                    var multipartFormContent = new MultipartFormDataContent("boundary");

                    foreach (var file in request.FileParams)
                    {
                        var content = new ByteArrayContent(file.Content);
                        if (!string.IsNullOrEmpty(request?.ContentDisposition)) { content.Headers.Add("Content-Disposition", request?.ContentDisposition); }
                        multipartFormContent.Add(content, file.Name, file.FileName);
                    }
                    requestMessage.Content = multipartFormContent;
                }
                else
                {
                    if (isPostOrPutHttpMethod(request.Method) && isEmptyOrJsonContentType(request.ContentType, request.HeaderParams))
                    {
                        requestMessage.Content = new StringContent("{ }", System.Text.Encoding.UTF8, "application/json");
                    }
                }
            }

            string uri = request.Url.ToString();
            if (request.PathParams?.Count > 0)
            {
                foreach (var kvp in request.PathParams)
                {
                    uri = uri.Replace($"{{{kvp.Key}}}", kvp.Value);
                }
            }

            if (request.QueryParams?.Count > 0)
            {
                var qs = "?" + string.Join("&", request.QueryParams
                                .Select(kvp => $"{kvp.Key}={System.Web.HttpUtility.UrlEncode(kvp.Value)}"));
                uri += qs;
            }

            requestMessage.RequestUri = new Uri(uri);

            if (request.HeaderParams?.Count > 0)
            {
                foreach (var kvp in request.HeaderParams)
                {
                    try
                    {
                        if (!requestMessage.Headers?.Contains(kvp.Key) ?? false)
                        {
                            requestMessage.Headers.Add(kvp.Key, kvp.Value);
                        }
                    }
                    catch
                    {
                        if (!requestMessage.Content?.Headers?.Contains(kvp.Key) ?? false)
                        {
                            requestMessage.Content.Headers.Add(kvp.Key, kvp.Value);
                        }
                    }
                }
            }            

            return requestMessage;
        }
    }
} 