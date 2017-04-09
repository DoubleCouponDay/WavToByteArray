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
using System.Threading;

using XamlAnimatedGif;

namespace WAV2ByteArray
{
    /// <summary>
    /// Interaction logic for OutputPage.xaml.
    /// Dispose() before deleting reference.
    /// </summary>
    public partial class OutputPage : Page, IDisposable
    {
        private PlayerTest musicPlayer;
        private TaskFactory taskFactory;
        private CancellationTokenSource cancelTokenSignaller;
        private CancellationToken taskCanceller;

        private AnAddressBarsProperties m_barProperties;
        private StandardButtonProperties m_buttonProperties;

        private MainWindow.PageChangeDelegate heldForUnsubscribing;

        public OutputPage (MainWindow.PageChangeDelegate pageChangeSubscriber)
        {
            InitializeComponent();
            m_barProperties = new AnAddressBarsProperties (OutputPageGrid);            
            m_buttonProperties = new StandardButtonProperties (OutputPageGrid, "ClipboardButton", "To Clipboard");
            ToSquareOne += pageChangeSubscriber; 
            heldForUnsubscribing = pageChangeSubscriber;
            musicPlayer = new PlayerTest();
            cancelTokenSignaller = new CancellationTokenSource();
            taskCanceller = cancelTokenSignaller.Token;
            taskFactory = new TaskFactory (taskCanceller);
            cancelTokenSignaller.Dispose();
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
                AnimationBehavior.SetAutoStart (CatGif, true);
                AnimationBehavior.SetRepeatBehavior (CatGif, RepeatBehavior.Forever);
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
                        StringBuilder timeWaster = new StringBuilder(); //just so i can see the animated cat =^.^=

                        for (int x = 0; x < currentBytes.Length; x++)
                        {
                            timeWaster.Append (currentBytes[x]);
                            timeWaster.Append (", ");
                        }
                        string fatty = timeWaster.ToString();
                        timeWaster.Clear();

                        Dispatcher.Invoke (() => { //needed in order to command the User Interface thread from the process thread.
                            if (i == default (int))
                            {
                                AddressBar_1.Content = currentBytes;
                            }

                            else
                            {   
                                NewMatchingPair (currentBytes, ToClipboardClick);                             
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

        private void NewMatchingPair (object barsContent, RoutedEventHandler buttonsEvent)
        {
            ListBoxItem newAddressBar = m_barProperties.CreateNewAddressBar (barsContent);
            ByteArrayList.Items.Add (newAddressBar);

            Button newClipboardButton = m_buttonProperties.CreateNewFindButton (buttonsEvent, ClipboardButton_1.Content);
            OutputPageGrid.Children.Add (newClipboardButton);
        }

        private void ToClipboardClick (object sender, RoutedEventArgs e)
        {
            Button trigger = e.Source as Button;

            if (trigger != null)
            {            
                List <FrameworkElement> matchList = m_buttonProperties.GetAllWithMatchingRanks (trigger);

                if (matchList.Count != default (int))
                {
                    foreach (ListBoxItem triggersPair in matchList.OfType <ListBoxItem>())
                    {                                                                                                              
                        string[] dividedName = trigger.Name.Split (m_barProperties.NAME_RANKS_SEPARATOR); //dont do this to triggersPair.Content! You dont have enough memory :']       
                        string outcomeMessage = default (string);        

                        if (triggersPair.Content != null &&
                            triggersPair.Content.ToString() != m_barProperties.Content)
                        {
                            Clipboard.Clear();
                            Clipboard.SetText (triggersPair.Content.ToString());  

                            if (dividedName.Length >= m_barProperties.RANKS_SPLIT_INDEX + 1)
                            {
                                string boxesRank  = dividedName[m_barProperties.RANKS_SPLIT_INDEX];          
                                outcomeMessage = "Copied output " + boxesRank + " to clipboard.";
                            }

                            else
                            {
                                outcomeMessage = "Copied output to clipboard";
                            }
                            byte[] possibleByteConversion = triggersPair.Content as byte[];

                            if (possibleByteConversion != null)
                            {
                                musicPlayer.WriteStream (possibleByteConversion);
                                musicPlayer.PlayStream();                                                           
                            }   
                            MessageBox.Show (outcomeMessage);  
                        
                            try
                            {                                                             
                                musicPlayer.StopPlaying();
                            }
                            catch { }
                        }
                        break; //Assuming there is only one same rank button as the listboxitem
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

        public void Dispose()
        {
            cancelTokenSignaller.Dispose();
            ToSquareOne -= heldForUnsubscribing;
        }

        public event MainWindow.PageChangeDelegate ToSquareOne;
    }
}
