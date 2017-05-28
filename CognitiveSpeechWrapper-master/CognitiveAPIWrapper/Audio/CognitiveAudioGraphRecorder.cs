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
namespace CognitiveAPIWrapper.Audio
{
  using System;
  using System.Threading.Tasks;
  using Windows.Devices.Enumeration;
  using Windows.Media.Audio;
  using Windows.Media.Capture;
  using Windows.Media.Devices;
  using Windows.Media.MediaProperties;
  using Windows.Media.Render;
  using Windows.Storage;

  public class CognitiveAudioGraphRecorder
  {
    public StorageFile RecordingFile { get; set; }
    public CognitiveAudioGraphRecorder(StorageFile file)
    {
      this.RecordingFile = file;
    }
    public static async Task<StorageFile> RecordToTemporaryFileAsync(
      TimeSpan duration)
    {
      var fileName = $"{Guid.NewGuid().ToString()}.bin";

      var temporaryFile = await ApplicationData.Current.TemporaryFolder.CreateFileAsync(
        fileName, CreationCollisionOption.GenerateUniqueName);

      var recorder = new CognitiveAudioGraphRecorder(temporaryFile);

      await recorder.StartRecordAsync();

      await Task.Delay(duration);

      await recorder.StopRecordAsync();

      return (temporaryFile);
    }
    public async Task StartRecordAsync()
    {
      var result = await AudioGraph.CreateAsync(
        new AudioGraphSettings(AudioRenderCategory.Media));

      if (result.Status == AudioGraphCreationStatus.Success)
      {
        this.graph = result.Graph;

        var microphone = await DeviceInformation.CreateFromIdAsync(
          MediaDevice.GetDefaultAudioCaptureId(AudioDeviceRole.Default));

        // Low gives us 1 channel, 16-bits per sample, 16K sample rate.
        var outProfile = MediaEncodingProfile.CreateWav(AudioEncodingQuality.Low);

        outProfile.Audio = AudioEncodingProperties.CreatePcm(16000, 1, 16);

        var inProfile = MediaEncodingProfile.CreateWav(AudioEncodingQuality.High);

        var outputResult = await this.graph.CreateFileOutputNodeAsync(
          this.RecordingFile,
          outProfile);

        if (outputResult.Status == AudioFileNodeCreationStatus.Success)
        {
          this.outputNode = outputResult.FileOutputNode;

          var inputResult = await this.graph.CreateDeviceInputNodeAsync(
            MediaCategory.Media,
            inProfile.Audio,
            microphone);

          if (inputResult.Status == AudioDeviceNodeCreationStatus.Success)
          {
            inputResult.DeviceInputNode.AddOutgoingConnection(
              this.outputNode);

            this.graph.Start();
          }
        }
      }
    }
    public async Task StopRecordAsync()
    {
      if (this.graph != null)
      {
        this.graph?.Stop();

        await this.outputNode.FinalizeAsync();

        // assuming that disposing the graph gets rid of the input/output nodes?
        this.graph?.Dispose();

        this.graph = null;
      }
    }
    AudioGraph graph;
    AudioFileOutputNode outputNode;
  }
}
