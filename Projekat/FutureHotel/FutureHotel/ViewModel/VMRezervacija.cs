using CognitiveAPIWrapper.Audio;
using CognitiveAPIWrapper.SpeakerIdentification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Storage;
using Windows.UI.Popups;
using Windows.UI.Xaml;


namespace FutureHotel.ViewModel
{
    class VMRezervacija
    {
        String brojNocenja;
        String tipSobe;
        public ICommand Snimanje_ { get; set; }


        public VMRezervacija(List<String> lista)
        {
            tipSobe = lista[0];
            brojNocenja = lista[1];
            Snimanje_ = new RelayCommand<object>(OnEnrollAsync, moze);
            /*var dialog = new MessageDialog(lista[0]);
            dialog.ShowAsync();*/
            //potrebna komunikacija sa ekstermin uredjajem za dalje
        }

        public bool moze (object param) { return true; }

        async void OnEnrollAsync(object param)
        //object sender, RoutedEventArgs e
        {
            // IdentificationClient is my wrapper for the identification REST API.
            // It needs my Cognitive speaker recognition API key in order to work.cognitiveApiKey
            IdentificationClient idClient = new IdentificationClient("bcb602e3b3bc479a9a8bbe8cad9ecebe");

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
        }

        static async Task ConfirmMessageAsync(string text)
        {
            MessageDialog dialog = new MessageDialog(text);
            await dialog.ShowAsync();
        }
    }

}
