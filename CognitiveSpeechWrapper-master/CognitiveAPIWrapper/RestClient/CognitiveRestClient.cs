//********************************************************* 
// 
// Copyright (c) Microsoft. All rights reserved. 
// This code is licensed under the MIT License (MIT). 
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF 
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY 
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR 
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT. 
// 
//********************************************************* 
namespace CognitiveAPIWrapper.RestClient
{
  using Newtonsoft.Json;
  using Newtonsoft.Json.Linq;
  using RestClient;
  using System;
  using System.IO;
  using System.Net.Http;
  using System.Text;
  using System.Threading.Tasks;
  using Windows.Storage.Streams;
  using System.Linq;

  public class CognitiveRestClient
  {
    public CognitiveRestClient(string apiKey)
    {
      this.apiKey = apiKey;
    }
    protected async Task<T> PostPcmStreamAsync<T>(
      string pathAndQuery, 
      IInputStream inputStream)
    {
      StreamContent content = new StreamContent(
        inputStream.AsStreamForRead());

      var response = await this.HttpClient.PostAsync(MakeUri(pathAndQuery), content);

      var result = await this.HandleJsonResultAsync<T>(response);

      return (result);
    }
    protected async Task<string> PostPcmStreamForHeaderResultAsync(
      string pathAndQuery,
      IInputStream inputStream,
      string outputHeader)
    {
      StreamContent content = new StreamContent(
        inputStream.AsStreamForRead());

      var response = await this.HttpClient.PostAsync(MakeUri(pathAndQuery), content);

      var stringContent = await response.Content.ReadAsStringAsync();

      this.ThrowOnFailStatus(response, stringContent);

      return (response.Headers.GetValues(outputHeader).FirstOrDefault());
    }
    void ThrowOnFailStatus(HttpResponseMessage response, string content)
    {
      if (!response.IsSuccessStatusCode)
      {
        var error = JsonConvert.DeserializeObject<CognitiveError>(content);

        throw new CognitiveException(error.Error.Message)
        {
          ErrorDetails = error
        };
      }
    }
    protected async Task<T> PostForJsonResultAsync<T>(string pathAndQuery, JObject jsonObject)
    {
      var content = new StringContent(jsonObject.ToString(),
        Encoding.UTF8, "application/json");

      var response = await this.HttpClient.PostAsync(MakeUri(pathAndQuery), content);

      var result = await this.HandleJsonResultAsync<T>(response);

      return (result);
    }
    static Uri MakeUri(string pathAndQuery)
    {
      return (new Uri($"{COGNITIVE_BASE_URL}/{pathAndQuery}"));
    }
    protected async Task DeleteAsync(string pathAndQuery)
    {
      var response = await this.HttpClient.DeleteAsync(MakeUri(pathAndQuery));

      var stringContent = await response.Content.ReadAsStringAsync();

      this.ThrowOnFailStatus(response, stringContent);
    }
    internal async Task<T> GetForJsonResultAbsoluteUriAsync<T>(
      Uri absoluteUri)
    {
      var response = await this.HttpClient.GetAsync(absoluteUri);

      var result = await this.HandleJsonResultAsync<T>(response);

      return (result);
    }
    internal protected Task<T> GetForJsonResultAsync<T>(string pathAndQuery)
    {
      return (this.GetForJsonResultAbsoluteUriAsync<T>(MakeUri(pathAndQuery)));
    }
    async Task<T> HandleJsonResultAsync<T>(HttpResponseMessage response)
    {
      var stringContent = await response.Content.ReadAsStringAsync();

      this.ThrowOnFailStatus(response, stringContent);

      var jsonObject = JsonConvert.DeserializeObject<T>(stringContent);

      return (jsonObject);
    }
    HttpClient HttpClient
    {
      get
      {
        if (this.httpClient == null)
        {
          this.httpClient = new HttpClient();
          this.httpClient.DefaultRequestHeaders.Add(
            COGNITIVE_KEY_HEADER, this.apiKey);
        }
        return (this.httpClient);
      }
    }
    static readonly string COGNITIVE_BASE_URL = "https://api.projectoxford.ai/spid/v1.0/";
    static readonly string COGNITIVE_KEY_HEADER = "Ocp-Apim-Subscription-Key";
    HttpClient httpClient;
    string apiKey;
  }
}
