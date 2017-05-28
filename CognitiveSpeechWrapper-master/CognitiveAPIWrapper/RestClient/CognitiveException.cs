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
  using System;

  class CognitiveException : Exception
  {
    public CognitiveException()
    {
    }
    public CognitiveException(string message)
        : base(message)
    {
    }
    public CognitiveException(string message, Exception inner)
        : base(message, inner)
    {
    }
    public CognitiveError ErrorDetails { get; set; }
  }
}
