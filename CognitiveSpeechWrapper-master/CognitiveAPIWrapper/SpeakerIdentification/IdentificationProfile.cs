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
  using System;

  public class IdentificationProfile : IdentificationProfileBase
  {
    public string Locale { get; set; }
    public float EnrollmentSpeechTime { get; set; }
    public float RemainingEnrollmentSpeechTime { get; set; }
    public DateTimeOffset CreatedDateTime { get; set; }
    public DateTimeOffset LastActionDateTime { get; set; }
    public IdentificationEnrollmentStatus EnrollmentStatus { get; set; }
  }
}