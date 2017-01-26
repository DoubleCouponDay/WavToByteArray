using System;
using System.Collections.Generic;
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
using WpfAnimatedGif;

namespace WAV2ByteArray
{
    /// <summary>
    /// Interaction logic for OutputPage.xaml
    /// </summary>
    public partial class OutputPage : Page
    {
        private AnAddressBarsProperties m_barProperties;
        private StandardButtonProperties m_buttonProperties;

        public OutputPage()
        {
            InitializeComponent();
            m_barProperties = new AnAddressBarsProperties (OutputPageGrid);            
            m_buttonProperties = new StandardButtonProperties (OutputPageGrid, "ClipboardButton", "To Clipboard");
        }

        /// <summary>
        /// Displays your WAV files bytes in OutputPage.ByteArrayList.
        /// If your files arent WAV files, nothing will happen!
        /// </summary>
        /// <param name="fileAddresses">windows addresses to audio files</param>
        public void ConvertWavToBytes (string[] fileAddresses)
        {
            Title.Content = "LOADING...";
            CatGif.Visibility = Visibility.Visible;
            ImageBehavior.SetAutoStart (CatGif, true);
            ImageBehavior.SetRepeatBehavior (CatGif, RepeatBehavior.Forever);

            if (fileAddresses != null)
            {
                Parallel.Invoke (() => DisplayFilesAsynchronously (fileAddresses));           
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
                    if (File.Exists (fileAddresses[i]))
                    {
                        byte[] currentBytes = File.ReadAllBytes (fileAddresses[i]);
                        StringBuilder serialBytes = new StringBuilder();

                        for (int x = 0; x < currentBytes.Length; x++)
                        {
                            serialBytes.Append (currentBytes[x]);
                            serialBytes.Append (" ");
                        }
                        string builderConverted = serialBytes.ToString();

                        Dispatcher.Invoke (() => { //needed in order to command the User Interface thread from the process thread.
                            if (AddressBar_1.Content.ToString() == m_barProperties.Content)
                            {
                                AddressBar_1.Content = builderConverted;
                            }

                            else
                            {   
                                NewMatchingPair (builderConverted, ToClipboardClick);                             
                            }                           
                        });                                                       
                    }

                    else
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
            Button trigger = e.Source as Button;

            if (trigger != null)
            {
                List <FrameworkElement> matchList = m_buttonProperties.GetAllWithMatchingRanks (trigger);

                foreach (ListBoxItem triggersPair in matchList.OfType <ListBoxItem>())
                {
                    Clipboard.SetText (triggersPair.Content.ToString());
                    string boxesRank = triggersPair.Content.ToString().Split (m_barProperties.NAME_RANKS_SEPARATOR)[m_barProperties.RANKS_SPLIT_INDEX];
                    MessageBox.Show ("Copied output " + boxesRank + " to clipboard.");
                    break;
                }
            }
        }

        private void PreviousPageClick (object sender, RoutedEventArgs e)
        {

        }
    }
}
