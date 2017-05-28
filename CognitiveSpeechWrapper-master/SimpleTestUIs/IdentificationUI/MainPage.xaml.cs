namespace IdentificationUI
{
  using CognitiveAPIWrapper.Audio;
  using CognitiveAPIWrapper.SpeakerIdentification;
  using System;
  using System.Linq;
  using System.Runtime.InteropServices.WindowsRuntime;
  using System.Threading.Tasks;
  using Windows.Storage;
  using Windows.UI.Popups;
  using Windows.UI.Xaml;
  using Windows.UI.Xaml.Controls;

  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }
    async void OnEnrolAsync(object sender, RoutedEventArgs e)
    {
      // IdentificationClient is my wrapper for the identification REST API.
      // It needs my Cognitive speaker recognition API key in order to work.
      IdentificationClient idClient = new IdentificationClient(cognitiveApiKey);

      // Make a call to the 'Create Profile' REST API and get back a new profile ID.
      Guid profileId = await idClient.AddIdentificationProfileAsync();

      float remainingTalkTime = 60.0f;

      // Loop until we have fully enrolled - this check is perhaps simplistic as
      // we may get errors etc.
      while (remainingTalkTime > 0)
      {
        // The service wants a minimum of 20 seconds of recorded file.
        remainingTalkTime = Math.Max(remainingTalkTime, 20.0f);

        // Ask the user to begin speaking.
        await ConfirmMessageAsync(
          $"dismiss the dialog then speak for {remainingTalkTime} seconds");

        // Wrapper class which uses AudioGraph to record audio to a file over a specified
        // period of time.
        StorageFile recordedFile = await CognitiveAudioGraphRecorder.RecordToTemporaryFileAsync(
          TimeSpan.FromSeconds(remainingTalkTime));

        // Make a call to the 'Create Enrollment' API to process the speech for the
        // profile. 
        PendingOperationResult serviceOperationResult = await
          idClient.EnrollRecordedSpeechForProfileIdAsync(profileId, recordedFile);

        // Make polling calls to the 'Get Operation Status' REST API waiting for the
        // service side operation to complete
        IdentificationOperationResult result =
          await serviceOperationResult.PollForProcessingResultAsync(TimeSpan.FromSeconds(5));

        // Get rid of the speech file.
        await recordedFile.DeleteAsync();

        // How much more speech does the service need to hear from the user?
        remainingTalkTime = result.ProcessingResult.RemainingEnrollmentSpeechTime;
      }
      await ConfirmMessageAsync("enrolled, thanks");
    }
    async void OnIdentifyAsync(object sender, RoutedEventArgs e)
    {
      // IdentificationClient is my wrapper for the identification REST API.
      // It needs my Cognitive speaker recognition API key in order to work.
      IdentificationClient idClient = new IdentificationClient(cognitiveApiKey);

      // In this example, we are only going to use the first 10 profile IDs that the
      // service knows in order to keep the code shorter.
      IdentificationProfile[] profiles = await idClient.GetIdentificationProfilesAsync();

      Guid[] profileIds = profiles.Take(10).Select(p => p.IdentificationProfileId).ToArray();

      // Ask the user to begin speaking.
      await ConfirmMessageAsync(
        $"dismiss the dialog then speak for 60 seconds");

      // Wrapper class which uses AudioGraph to record audio to a file over a specified
      // period of time.
      StorageFile recordingFile = await CognitiveAudioGraphRecorder.RecordToTemporaryFileAsync(
        TimeSpan.FromSeconds(60));

      // Make a call to the 'Create Enrollment' API to process the speech for the
      // profile. 
      PendingOperationResult serviceOperationResult = await
        idClient.IdentifyRecordedSpeechForProfileIdsAsync(recordingFile, profileIds);

      // Make polling calls to the 'Get Operation Status' REST API waiting for the
      // service side operation to complete
      IdentificationOperationResult result =
        await serviceOperationResult.PollForProcessingResultAsync(TimeSpan.FromSeconds(5));

      // Get rid of the speech file.
      await recordingFile.DeleteAsync();

      // Assume that things failed.
      string message = "not recognised";

      // But if they worked...
      if (result?.ProcessingResult.IdentifiedProfileId != default(Guid))
      {
        // Build up a message containing the recognised profile ID and the confidence applied.
        message = $"recognised profile {result.ProcessingResult.IdentifiedProfileId.ToString()}" +
          $" with {result.ProcessingResult.Confidence} confidence";
      }
      await ConfirmMessageAsync(message);
    }
    async void OnClearAllProfilesAsync(object sender, RoutedEventArgs e)
    {
      var client = new IdentificationClient(cognitiveApiKey);

      var profiles = await client.GetIdentificationProfilesAsync();

      foreach (var profile in profiles)
      {
        await client.RemoveIdentificationProfileAsync(profile.IdentificationProfileId);
      }
    }
    static async Task ConfirmMessageAsync(string text)
    {
      MessageDialog dialog = new MessageDialog(text);
      await dialog.ShowAsync();
    }
#error NEED AN API KEY HERE
    static readonly string cognitiveApiKey = "";
  }
}
