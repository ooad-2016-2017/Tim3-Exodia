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
  using System;
  using System.Threading.Tasks;

  public class PendingOperationResult
  {
    internal PendingOperationResult(CognitiveRestClient restClient, string operationLocation)
    {
      this.restClient = restClient;
      this.operationLocation = new Uri(operationLocation);
    }
    public async Task<IdentificationOperationResult> PollForProcessingResultAsync(TimeSpan pollDelay)
    {
      IdentificationOperationResult result = new IdentificationOperationResult();

      while ((result.Status != IdentificationOperationStatus.Failed) &&
        (result.Status != IdentificationOperationStatus.Succeeded))
      {
        result = await this.restClient.GetForJsonResultAbsoluteUriAsync<IdentificationOperationResult>(
          this.operationLocation);

        await Task.Delay(pollDelay);
      }
      return (result);
    }
    CognitiveRestClient restClient;
    Uri operationLocation;
  }
}
