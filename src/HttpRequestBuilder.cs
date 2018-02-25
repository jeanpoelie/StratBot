﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using System.Linq;

namespace StratBot
{
    public class HttpRequestBuilder
    {
        private HttpMethod method = null;
        private string requestUri = "";
        private HttpContent content = null;
        private string bearerToken = "";
        private string xAppId = "";
        private string acceptHeader = "application/json";
        private TimeSpan timeout = new TimeSpan(0, 0, 15);
        private bool allowAutoRedirect = false;

        public HttpRequestBuilder()
        {
        }

        public HttpRequestBuilder AddMethod(HttpMethod method)
        {
            this.method = method;
            return this;
        }
        
        public HttpRequestBuilder AddRequestUri(string requestUri)
        {
            this.requestUri = requestUri;
            return this;
        }

        public HttpRequestBuilder AddContent(HttpContent content)
        {
            this.content = content;
            return this;
        }

        public HttpRequestBuilder AddBearerToken(string bearerToken)
        {
            this.bearerToken = bearerToken;
            return this;
        }

        public HttpRequestBuilder AddXAppId(string xAppId)
        {
            this.xAppId = xAppId;
            return this;
        }

        public HttpRequestBuilder AddAcceptHeader(string acceptHeader)
        {
            this.acceptHeader = acceptHeader;
            return this;
        }

        public HttpRequestBuilder AddTimeout(TimeSpan timeout)
        {
            this.timeout = timeout;
            return this;
        }

        public HttpRequestBuilder AddAllowAutoRedirect(bool allowAutoRedirect)
        {
            this.allowAutoRedirect = allowAutoRedirect;
            return this;
        }

        public async Task<HttpResponseMessage> SendAsync(List<KeyValuePair<string, string>> query = null, List<KeyValuePair<string, string>> headers = null)
        {
            // Check required arguments
            EnsureArguments();

            IDictionary<string, string> dictionary = query.ToDictionary(pair => pair.Key, pair => pair.Value);
            var requestUri = QueryHelpers.AddQueryString(this.requestUri, dictionary);

            // Set up request
            var request = new HttpRequestMessage
            {
                Method = this.method,
                RequestUri = new Uri(requestUri)
            };

            if (this.content != null)
                request.Content = this.content;

            if (!string.IsNullOrEmpty(this.xAppId))
                request.Headers.Add("x-app-id", this.xAppId);

            if (!string.IsNullOrEmpty(this.bearerToken))
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", this.bearerToken);
            
            request.Headers.Accept.Clear();
            if (!string.IsNullOrEmpty(this.acceptHeader))
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(this.acceptHeader));

            // Setup client
            var handler = new HttpClientHandler
            {
                AllowAutoRedirect = this.allowAutoRedirect
            };

            var client = new HttpClient(handler)
            {
                Timeout = this.timeout
            };

            return await client.SendAsync(request);
        }

        #region " Private "

        private void EnsureArguments()
        {
            if (this.method == null)
                throw new ArgumentNullException("Method");
            
            if (string.IsNullOrEmpty(this.requestUri))
                throw new ArgumentNullException("Request Uri");
        }

        #endregion
    }
}
