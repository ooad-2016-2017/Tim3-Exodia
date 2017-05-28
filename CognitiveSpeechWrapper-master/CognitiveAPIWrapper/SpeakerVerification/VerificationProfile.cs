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
  using System;

  public class VerificationProfile
  {
    public Guid VerificationProfileId { get; set; }
    public string Locale { get; set; }
    public int EnrollmentCount { get; set; }
    public int RemainingEnrollmentsCount { get; set; }

    public DateTimeOffset CreatedDateTime { get; set; }
    public DateTimeOffset LastActionDateTime { get; set; }

    public VerificationEnrollmentStatus EnrollmentStatus { get; set; }
  }
}
