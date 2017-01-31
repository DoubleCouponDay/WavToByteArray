using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Media;

using WpfAnimatedGif;

namespace WAV2ByteArray
{
    /// <summary>
    /// Interaction logic for OutputPage.xaml
    /// </summary>
    public partial class OutputPage : Page
    {
private PlayerTest musicPlayer;

        private AnAddressBarsProperties m_barProperties;
        private StandardButtonProperties m_buttonProperties;

        public OutputPage (MainWindow.PageChangeDelegate pageChangeSubscriber)
        {
            InitializeComponent();
            m_barProperties = new AnAddressBarsProperties (OutputPageGrid);            
            m_buttonProperties = new StandardButtonProperties (OutputPageGrid, "ClipboardButton", "To Clipboard");
            ToSquareOne += pageChangeSubscriber;

musicPlayer = new PlayerTest();
        }

        /// <summary>
        /// Displays your WAV files bytes in OutputPage.ByteArrayList.
        /// If your files arent WAV files, nothing will happen!
        /// </summary>
        /// <param name="fileAddresses">windows addresses to audio files</param>
        public void ConvertWavToBytes (string[] fileAddresses)
        {
            if (fileAddresses != null)
            {
                Title.Content = "LOADING...";
                CatGif.Visibility = Visibility.Visible;
                ImageBehavior.SetAutoStart (CatGif, true);
                ImageBehavior.SetRepeatBehavior (CatGif, RepeatBehavior.Forever);
                Parallel.Invoke (() => DisplayFilesAsynchronously (fileAddresses));           
            }

            else
            {
                MessageBox.Show (ErrorMessages.UNKNOWN);
            }
        }

        /// <summary>
        /// This method is pretty slow so it it works better as an asynchronous task.
        /// </summary>
        /// <param name="fileAddresses"></param>
        private async void DisplayFilesAsynchronously (string[] fileAddresses)
        {
            await Task.Run (() => {
                for (int i = 0; i < fileAddresses.Length; i++)
                {
                    if (File.Exists (fileAddresses[i])) //niceway of checking if user placed an item in that box.
                    {
                        byte[] currentBytes = File.ReadAllBytes (fileAddresses[i]);
Dispatcher.Invoke (() => {
    musicPlayer.WriteStream (currentBytes);
});
                        StringBuilder serialBytes = new StringBuilder(); //Optimized for concatanating massive strings.

                        for (int x = 0; x < currentBytes.Length; x++)
                        {
                            serialBytes.Append (", ");
                            serialBytes.Append (currentBytes[x]);                            
                        }
                        string builderConverted = serialBytes.ToString();

                        Dispatcher.Invoke (() => { //needed in order to command the User Interface thread from the process thread.
                            if (i == default (int))
                            {
                                AddressBar_1.Content = builderConverted;
                            }

                            else
                            {   
                                NewMatchingPair (builderConverted, ToClipboardClick);                             
                            }                           
                        });                                                       
                    }

                    else if (i != default (int)) //assuming the default OutputPage's only address bar has no content.
                    {
                        Dispatcher.Invoke (() => {
                            NewMatchingPair (m_barProperties.Content, ToClipboardClick);
                        });
                    }
                }       

                Dispatcher.Invoke (() => {                                      
                    Title.Content = "Finished converting!";    
                    CatGif.Visibility = Visibility.Hidden;
                });
            });
        }

        private void NewMatchingPair (string barsContent, RoutedEventHandler buttonsEvent)
        {
            ListBoxItem newAddressBar = m_barProperties.CreateNewAddressBar (barsContent);
            ByteArrayList.Items.Add (newAddressBar);

            Button newClipboardButton = m_buttonProperties.CreateNewFindButton (buttonsEvent, ClipboardButton_1.Content.ToString());
            OutputPageGrid.Children.Add (newClipboardButton);
        }

        private void ToClipboardClick (object sender, RoutedEventArgs e)
        {
try
{
    musicPlayer.PlayStream();
}

catch (Exception failed)
{
    MessageBox.Show (failed.ToString());
    throw;
}
            Button trigger = e.Source as Button;

            if (trigger != null)
            {
                List <FrameworkElement> matchList = m_buttonProperties.GetAllWithMatchingRanks (trigger);

                if (matchList.Count != default (int))
                {
                    foreach (ListBoxItem triggersPair in matchList.OfType <ListBoxItem>())
                    {   
                        Clipboard.SetText (triggersPair.Content.ToString());                                                                                     
                        string[] dividedName = trigger.Name.Split (m_barProperties.NAME_RANKS_SEPARATOR); //dont do this to triggersPair.Content! You dont have enough memory :']       
                        string outcomeMessage = default (string);        

                        if (dividedName.Length >= m_barProperties.RANKS_SPLIT_INDEX + 1)
                        {
                            string boxesRank  = dividedName[m_barProperties.RANKS_SPLIT_INDEX];          
                            outcomeMessage = "Copied output " + boxesRank + " to clipboard.";
                        }

                        else
                        {
                            outcomeMessage = "Copied output to clipboard";
                        }
                        MessageBoxResult promptsReturn = MessageBox.Show (outcomeMessage);
musicPlayer.StopPlaying();                                                
                        break;
                    }
                }
                    
                else
                {
                    MessageBox.Show (ErrorMessages.UNKNOWN);
                }              
            }
        }

        private void PreviousPageClick (object sender, RoutedEventArgs e)
        {
            ToSquareOne.Invoke (PageOptions.INPUT_PAGE, null);
        }
        public event MainWindow.PageChangeDelegate ToSquareOne;
    }
}
