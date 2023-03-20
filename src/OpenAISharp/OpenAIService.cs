using Microsoft.Extensions.Options;
using OpenAISharp.Exceptions;
using OpenAISharp.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace OpenAISharp
{
    public abstract class OpenAIService
    {
        protected readonly HttpClient _client;

        protected readonly OpenAIOptions _options;
        protected readonly Uri _baseUri;

        public OpenAIService(IOptions<OpenAIOptions> options)
        {
            _client = new HttpClient();

            _options = options.Value;
            _baseUri = new Uri(_options.BaseUrl);
        }

        protected async Task<TResult> ExecuteRequest<TSource, TResult>(HttpMethod method, string resource, TSource body)
        {
            var url = new Uri(_baseUri, resource);
            var request = new HttpRequestMessage(method, url);
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.ApiKey);

            if (body is not null)
            {
                request.Content = JsonContent.Create(body, options: new JsonSerializerOptions
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                });
            }

            var response = await _client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var contentString = await response.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<TResult>(contentString);
                return result;
            }
            else
            {
                throw new OpenAIApiException(response.StatusCode, await response.Content.ReadAsStringAsync());
            }
        }
    }
}