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
namespace CognitiveAPIWrapper.SpeakerVerification
{
  using Accounts;
  using Newtonsoft.Json.Linq;
  using RestClient;
  using SpeakerVerification;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Threading.Tasks;
  using Windows.Storage;
  using Windows.Storage.Streams;

  public class VerificationClient : CognitiveRestClient
  {
    public VerificationClient(string apiKey) : base(apiKey)
    {
    }
    public async Task<Guid> AddVerificationProfileAsync()
    {
      var jObject = new JObject();

      jObject[LOCALE_PROPERTY] = US_LOCALE;

      var result = await base.PostForJsonResultAsync<VerificationProfile>(
        COGNITIVE_VERIFY_PROFILES, jObject);

      return (result.VerificationProfileId);
    }
    public async Task<VerificationEnrollmentResult> EnrollRecordedSpeechForProfileIdAsync(
      Guid profileId,
      StorageFile recordingFile)
    {
      VerificationEnrollmentResult result = null;

      using (var inputStream = await recordingFile.OpenReadAsync())
      {
        result = await this.EnrollAsync(profileId, inputStream);
      }
      return (result);
    }
    public async Task<VerificationResult> VerifyRecordedSpeechForProfileIdAsync(
      Guid profileId, 
      StorageFile file)
    {
      VerificationResult result = null;

      using (var inputStream = await file.OpenReadAsync())
      {
        result = await this.VerifyAsync(profileId, inputStream);
      }
      return (result);
    }
    public async Task<string> GetRandomVerificationPhraseAsync()
    {
      var results = await this.GetForJsonResultAsync<VerificationPhrase[]>(
        COGNITIVE_VERIFY_PHRASES);

      var phrases = results.Select(result => result.Phrase).ToList();

      var random = new Random();

      return (phrases[random.Next(0, phrases.Count)]);
    }
    public async Task<IEnumerable<VerificationProfile>> GetVerificationProfilesAsync()
    {
      var results = await this.GetForJsonResultAsync<VerificationProfile[]>(
        COGNITIVE_VERIFY_PROFILES);

      return (results);
    }
    public async Task RemoveVerificationProfileAsync(Guid profileId)
    {
      await base.DeleteAsync(
        $"{COGNITIVE_VERIFY_PROFILES}/{Uri.EscapeDataString(profileId.ToString())}");
    }
    async Task<VerificationResult> VerifyAsync(Guid profileId,
      IInputStream inputStream)
    {
      var endpoint =
        $"{COGNITIVE_VERIFY}{Uri.EscapeDataString(profileId.ToString())}";

      var result = await base.PostPcmStreamAsync<VerificationResult>(
        endpoint, inputStream);

      return (result);
    }
    async Task<VerificationEnrollmentResult> EnrollAsync(Guid profileId,
      IInputStream inputStream)
    {
      var endpoint =
          $"{COGNITIVE_VERIFY_PROFILES}/" +
          Uri.EscapeDataString(profileId.ToString()) +
          $"/{COGNITIVE_ENROLL}";

      var result = 
        await base.PostPcmStreamAsync<VerificationEnrollmentResult>(
          endpoint, inputStream);

      return (result);
    }
    const string COGNITIVE_ENROLL = "enroll";
    const string COGNITIVE_VERIFY = "verify?verificationProfileId=";
    const string COGNITIVE_VERIFY_PROFILES = "verificationProfiles";
    const string LOCALE_PROPERTY = "locale";
    const string US_LOCALE = "en-us";
    static readonly string COGNITIVE_VERIFY_PHRASES = $"verificationPhrases?{LOCALE_PROPERTY}={US_LOCALE}";
  }
}