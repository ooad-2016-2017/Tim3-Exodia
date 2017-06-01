﻿
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
    public class VMSnimanje
    {
        public ICommand Provjeri { get; set; }

        public VMSnimanje()
        {
            Provjeri = new RelayCommand<object>(OnIdentifyAsync, moze);
        }

        public bool moze(object param)
        {
            return true;
        }

        async void OnIdentifyAsync(object sender)
        {
            // IdentificationClient is my wrapper for the identification REST API.
            // It needs my Cognitive speaker recognition API key in order to work.
            IdentificationClient idClient = new IdentificationClient("bcb602e3b3bc479a9a8bbe8cad9ecebe");

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

        static async Task ConfirmMessageAsync(string text)
        {
            MessageDialog dialog = new MessageDialog(text);
            await dialog.ShowAsync();
        }
    }
}