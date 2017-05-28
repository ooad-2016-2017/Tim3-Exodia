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
namespace CognitiveAPIWrapper.Accounts
{
  using Newtonsoft.Json;
  using System;
  using System.Collections.Generic;
  using System.IO;
  using System.Threading.Tasks;
  using Windows.Storage;

  internal static class AccountMap
  {
    static AccountMap()
    {
      accountMap = new Dictionary<string, Guid>();
    }
    static async Task InitialiseAsync()
    {
      if (!loaded)
      {
        try
        {
          var file = await ApplicationData.Current.LocalFolder.GetFileAsync(
            FILENAME);

          var text = await FileIO.ReadTextAsync(file);

          var deserialized = JsonConvert.DeserializeObject<
            Dictionary<string, Guid>>(text);

          accountMap = deserialized;

          loaded = true;
        }
        catch (FileNotFoundException)
        {
        }
      }
    }
    public static async Task<Guid?> GetGuidForUserNameAsync(string userName)
    {
      Guid? guid = null;

      await InitialiseAsync();

      if (accountMap.ContainsKey(userName))
      {
        guid = accountMap[userName];
      }
      return (guid);
    }
    public static async Task SetGuidForUserNameAsync(string userName,
      Guid guid)
    {
      await InitialiseAsync();

      accountMap[userName] = guid;

      await SaveAsync();
    }
    static async Task SaveAsync()
    {
      var serialized = JsonConvert.SerializeObject(accountMap);

      var file = await ApplicationData.Current.LocalFolder.CreateFileAsync(
        FILENAME, CreationCollisionOption.ReplaceExisting);

      await FileIO.WriteTextAsync(file, serialized);
    }

    public static async Task RemoveGuidForUserNameAsync(string userName)
    {
      await InitialiseAsync();
      accountMap.Remove(userName);
      await SaveAsync();
    }
    static bool loaded;
    static readonly string FILENAME = "map.json";
    static Dictionary<string, Guid> accountMap;
  }
}