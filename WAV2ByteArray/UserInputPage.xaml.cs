using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace WAV2ByteArray
{
    public partial class UserInputPage : Page
    {
        private const string FILE_FORMAT = "WAV";

        private StandardButtonProperties m_buttonProperties;
        private AnAddressBarsProperties m_barProperties;

        public UserInputPage()
        {
            InitializeComponent();
            m_buttonProperties = new StandardButtonProperties (UserInputGrid, "FindAddressButton", "...");
            m_barProperties = new AnAddressBarsProperties (UserInputGrid);
        }

        private void ClickFindAddress (object sender, RoutedEventArgs e)
        {
            Button culprit = e.Source as Button;

            if (culprit != null)
            {
                string filesAddress = default (string);
                bool? dialogOutcome = NewFindWavFileDialog (ref filesAddress);

                if (dialogOutcome.HasValue && //I can value check and compare in the same clause if the check comes first, fails first.
                    dialogOutcome == true)
                {
                    List <FrameworkElement> matchingRanks = m_buttonProperties.GetAllWithMatchingRanks (culprit);

                    foreach (ListBoxItem pairedBox in matchingRanks.OfType <ListBoxItem>())
                    {
                        pairedBox.Content = filesAddress;
                        break; //paranoia
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filesName">The Address of file selected by the user. Empty if they clicked CANCEL.</param>
        /// <returns>A nullable bool which is true when the user clicks OK. false if they click CANCEL.</returns>
        private bool? NewFindWavFileDialog (ref string filesName)
        {
            OpenFileDialog finderBox = new OpenFileDialog();
            finderBox.DefaultExt = FILE_FORMAT;
            finderBox.CheckFileExists = true;
            finderBox.CheckPathExists = true;
            finderBox.AddExtension = true;
            finderBox.Title = "Find your WAV file";
            finderBox.Filter = "WAV files (*.wav)|*.wav"; //prevents any other file type from being passed.
            bool? dialogOutcome = finderBox.ShowDialog();
            filesName = finderBox.FileName;
            return dialogOutcome;
        }

        private void ClickNewBar (object sender, RoutedEventArgs e)
        {
            int result;

            if (int.TryParse (ErrorMessages.MAX_ADDRESS_BARS, out result) &&
                FilesList.Items.Count < result)
            {   
                ListBoxItem newAddressBar = m_barProperties.CreateNewAddressBar (m_barProperties.Content);            
                FilesList.Items.Add (newAddressBar);

                Button newFindButton = m_buttonProperties.CreateNewFindButton (ClickFindAddress, m_buttonProperties.Content);
                UserInputGrid.Children.Add (newFindButton);
            }
                 
            else
            {
                MessageBox.Show (ErrorMessages.MAX_ITEMS);
            }
        }

        private void ClickRemoveBar (object sender, RoutedEventArgs e)
        {
            int result;

            if (int.TryParse (ErrorMessages.MIN_ADDRESS_BARS, out result) &&
                FilesList.Items.Count > result)
            {
                ListBoxItem lastAddressBar = m_barProperties.GetReferenceLastRankedItem();
                Button lastBarButton = m_buttonProperties.GetReferenceLastRankedItem();
                FilesList.Items.Remove (lastAddressBar);
                UserInputGrid.Children.Remove (lastBarButton);
            }

            else
            {
                MessageBox.Show (ErrorMessages.MIN_ITEMS);
            }
        }      

        private void ClickConvert (object sender, RoutedEventArgs e)
        {
            IEnumerable <string> barsQuery = from item in FilesList.Items.OfType <ListBoxItem>()
                                             let itemsContent = item.Content.ToString()
                                             select itemsContent;
            
            string[] allAddresses = barsQuery.ToArray();
            ByteConversion.Invoke (allAddresses);           
        }
        public event OnByteConversion ByteConversion;
        public delegate void OnByteConversion (string[] inputFilesAddresses);        
    }
}
