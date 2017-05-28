namespace VerificationUI
{
  using CognitiveAPIWrapper.Audio;
  using CognitiveAPIWrapper.SpeakerVerification;
  using System;
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
    async void OnClearAllAsync(object sender, RoutedEventArgs e)
    {
      VerificationClient client = new VerificationClient(cognitiveApiKey);

      var profiles = await client.GetVerificationProfilesAsync();

      foreach (var profile in profiles)
      {
        await client.RemoveVerificationProfileAsync(profile.VerificationProfileId);
      }
    }
    async void OnGetRandomPhraseAsync(object sender, RoutedEventArgs e)
    {
      // VerificationClient is my wrapper for the verification REST API.
      // It needs my Cognitive speaker recognition API key in order to work.
      VerificationClient verificationClient = new VerificationClient(cognitiveApiKey);

      // This calls the 'list all supported verification phrases' REST API
      // and then simply chooses one of the return phrases at random
      string randomlySelectedVerificationPhrase =
        await verificationClient.GetRandomVerificationPhraseAsync();

      // Display that phrase back in the UI.
      this.txtPhrase.Text = randomlySelectedVerificationPhrase;
    }
    async void OnEnrollAsync(object sender, RoutedEventArgs e)
    {
      // VerificationClient is my wrapper for the verification REST API.
      // It needs my Cognitive speaker recognition API key in order to work.
      VerificationClient verificationClient = new VerificationClient(cognitiveApiKey);

      // This calls the 'create profile' REST API and returns the GUID of the
      // new profile.
      Guid profileId = await verificationClient.AddVerificationProfileAsync();

      // Display the profile ID in the UI.
      this.txtProfileId.Text = profileId.ToString();

      bool enrolled = false;

      do
      {
        await ConfirmMessageAsync("Dismiss this dialog then say your phrase");

        // Wrapper class which uses AudioGraph to record audio to a file over a specified
        // period of time.
        StorageFile recordedAudioFile =
          await CognitiveAudioGraphRecorder.RecordToTemporaryFileAsync(TimeSpan.FromSeconds(10));

        // This calls the 'create enrollment' API with the speech stream and 
        // decodes the returned JSON.
        VerificationEnrollmentResult result =
          await verificationClient.EnrollRecordedSpeechForProfileIdAsync(
            profileId, recordedAudioFile);

        // Get rid of the recorded speech.
        await recordedAudioFile.DeleteAsync();

        // Do we need to do more enrollments? Note - this check is probably
        // over-simplistic.
        enrolled = (result.RemainingEnrollments == 0);

      } while (!enrolled);
    }
    async void OnVerifyAsync(object sender, RoutedEventArgs e)
    {
      // Take the user's profile ID back from the UI as we haven't stored
      // it anywhere.
      Guid profileId = Guid.Parse(this.txtProfileId.Text);

      // Prompt the user to speak.
      await ConfirmMessageAsync("Dismiss the dialog then speak your phrase");

      // Wrapper class which uses AudioGraph to record audio to a file over a specified
      // period of time.
      StorageFile recordedFile =
        await CognitiveAudioGraphRecorder.RecordToTemporaryFileAsync(
          TimeSpan.FromSeconds(10));

      // VerificationClient is my wrapper for the verification REST API.
      // It needs my Cognitive speaker recognition API key in order to work.
      VerificationClient verificationClient = new VerificationClient(
        cognitiveApiKey);

      VerificationResult result =
        await verificationClient.VerifyRecordedSpeechForProfileIdAsync(
          profileId, recordedFile);

      // Get rid of the recorded audio file.
      await recordedFile.DeleteAsync();

      await ConfirmMessageAsync(
        $"Your speech was {result.Result}ed with {result.Confidence} confidence");
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
