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
namespace CognitiveAPIWrapper.SpeakerIdentification
{
  using CognitiveAPIWrapper.RestClient;
  using Newtonsoft.Json.Linq;
  using System;
  using System.Linq;
  using System.Threading.Tasks;
  using Windows.Storage;
  using Windows.Storage.Streams;

  public class IdentificationClient : CognitiveRestClient
  {
    public IdentificationClient(string apiKey) : base(apiKey)
    {

    }
    public async Task<IdentificationProfile[]> GetIdentificationProfilesAsync()
    {
      var results = await base.GetForJsonResultAsync<IdentificationProfile[]>(
        COGNITIVE_IDENTIFY_PROFILES);

      return (results);
    }
    public async Task RemoveIdentificationProfileAsync(Guid profileId)
    {
      await base.DeleteAsync(
        $"{COGNITIVE_IDENTIFY_PROFILES}/{Uri.EscapeDataString(profileId.ToString())}");
    }

    public async Task<Guid> AddIdentificationProfileAsync()
    {
      var jObject = new JObject();

      jObject[LOCALE_PROPERTY] = US_LOCALE;

      var result = await base.PostForJsonResultAsync<IdentificationProfileBase>(
        COGNITIVE_IDENTIFY_PROFILES, jObject);

      return (result.IdentificationProfileId);
    }
    public async Task<PendingOperationResult> EnrollRecordedSpeechForProfileIdAsync(
      Guid profileId,
      StorageFile recordingFile)
    {
      PendingOperationResult result = null;

      using (var inputStream = await recordingFile.OpenReadAsync())
      {
        var operationLocation = await this.EnrollAsync(profileId, inputStream);

        if (!string.IsNullOrEmpty(operationLocation))
        {
          result = new PendingOperationResult(this, operationLocation);
        }
      }
      return (result);
    }
    public async Task<PendingOperationResult> IdentifyRecordedSpeechForProfileIdsAsync(
      StorageFile recordingFile,
      params Guid[] profileIds)
    {
      PendingOperationResult result = null;

      using (var inputStream = await recordingFile.OpenReadAsync())
      {
        var operationLocation = await this.IdentifyAsync(profileIds, inputStream);

        if (!string.IsNullOrEmpty(operationLocation))
        {
          result = new PendingOperationResult(this, operationLocation);
        }
      }
      return (result);
    }
    async Task<string> EnrollAsync(Guid profileId,
      IInputStream inputStream)
    {
      var endpoint =
          $"{COGNITIVE_IDENTIFY_PROFILES}/" +
          Uri.EscapeDataString(profileId.ToString()) +
          $"/{COGNITIVE_ENROLL}";

      var result =
        await base.PostPcmStreamForHeaderResultAsync(
          endpoint, inputStream, OPERATION_LOCATION_HEADER);

      return (result);
    }
    async Task<string> IdentifyAsync(
      Guid[] profileIds,
     IInputStream inputStream)
    {
      var guidStrings = profileIds.Select(g => g.ToString());

      var joined = string.Join(",", guidStrings);

      var pathAndQuery = $"{COGNITIVE_IDENTIFY}{Uri.EscapeDataString(joined)}";

      var result =
        await base.PostPcmStreamForHeaderResultAsync(
          pathAndQuery, inputStream, OPERATION_LOCATION_HEADER);

      return (result);
    }
    const string LOCALE_PROPERTY = "locale";
    const string US_LOCALE = "en-us";
    static readonly string COGNITIVE_ENROLL = "enroll";
    static readonly string COGNITIVE_IDENTIFY = "identify?identificationProfileIds=";
    static readonly string COGNITIVE_IDENTIFY_PROFILES = "identificationProfiles";
    static readonly string OPERATION_LOCATION_HEADER = "Operation-Location";
  }
}
