
using CognitiveAPIWrapper.Audio;
using CognitiveAPIWrapper.SpeakerIdentification;
using FutureHotel.Model;
using Microsoft.WindowsAzure.MobileServices;
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
        public int broj_sobe { get; set; }
        public List<Soba> sobe { get; set; }
        IMobileServiceTable<Soba> userTableObj = App.MobileService.GetTable<Soba>();

        public VMSnimanje(int redni_br_sobe)
        {
            broj_sobe = redni_br_sobe;
            Provjeri = new RelayCommand<object>(OnIdentifyAsync, moze);
        }

        public bool moze(object param)
        {
            return true;
        }

        async void OnIdentifyAsync(object sender)
        {
            //"bcb602e3b3bc479a9a8bbe8cad9ecebe"
            await ucitaj();
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
            if (result.ProcessingResult != null && result?.ProcessingResult.IdentifiedProfileId != default(Guid))
            {
                for (int i = 0; i < sobe.Count; i++)
                {
                    if(broj_sobe == sobe[i].redni_br && result.ProcessingResult.IdentifiedProfileId.ToString() == sobe[i].gost_guid) 
                    // Build up a message containing the recognised profile ID and the confidence applied.
                    message = $"Prepoznat profil {result.ProcessingResult.IdentifiedProfileId.ToString()}" +
                      $" sa {result.ProcessingResult.Confidence} postotnom preciznoscu. Otvorena soba {broj_sobe}";
                }
            }
            await ConfirmMessageAsync(message);
        }

        public async Task ucitaj()
        {
            IEnumerable<Soba> sob = await userTableObj.ReadAsync();
            sobe = new List<Soba>(sob);
        }

        static async Task ConfirmMessageAsync(string text)
        {
            MessageDialog dialog = new MessageDialog(text);
            await dialog.ShowAsync();
        }
    }
}
