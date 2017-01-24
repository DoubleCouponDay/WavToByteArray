using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WAV2ByteArray
{
    public partial class UserInputPage : Page
    {
        private const int MIN_ADDRESS_BARS = 1;
        private const int MAX_ADDRESS_BARS = 20;        

        private AFindButtonsProperties m_buttonProperties;
        private AnAddressBarsProperties m_barProperties;

        public UserInputPage()
        {
            InitializeComponent();
            m_buttonProperties = new AFindButtonsProperties (UserInputGrid);
            m_barProperties = new AnAddressBarsProperties (UserInputGrid);
        }

        private void ClickFindAddress (object sender, RoutedEventArgs e)
        {
            MessageBox.Show ("it worked!");
        }

        private void ClickNewBar (object sender, RoutedEventArgs e)
        {
            if (FilesList.Items.Count < MAX_ADDRESS_BARS)
            {                
                CreateNewAddressBar();
                CreateFindButton();
            }
                 
            else
            {
                MessageBox.Show (ErrorMessages.MAX_ITEMS);
            }
        }

        private void CreateNewAddressBar()
        {
            ListBoxItem newAddressBar = new ListBoxItem();
            newAddressBar.BorderBrush = m_barProperties.BorderBrush;
            newAddressBar.BorderThickness = m_barProperties.BorderThickness;
            newAddressBar.Name = m_barProperties.GetLatestRankedName();
            newAddressBar.Width = m_barProperties.WIDTH;
            newAddressBar.Height = m_barProperties.HEIGHT;
            newAddressBar.Content = m_barProperties.CONTENT;            
            FilesList.Items.Add (newAddressBar);
        }

        private void CreateFindButton()
        {
            Button newAddressButton = new Button();
            newAddressButton.VerticalAlignment = m_buttonProperties.verticalAlignment;
            newAddressButton.HorizontalAlignment = m_buttonProperties.horizontalAlignment;
            newAddressButton.Width = m_buttonProperties.WIDTH;
            newAddressButton.Height = m_buttonProperties.HEIGHT;
            newAddressButton.SetValue (Grid.RowProperty, m_buttonProperties.ROW);
            newAddressButton.SetValue (Grid.ColumnProperty, m_buttonProperties.COLUMN);

            Thickness marginConstruction = m_buttonProperties.GetCopyLastButtonsMargin();
            marginConstruction.Top += m_buttonProperties.MARGIN_INCREMENT;
            newAddressButton.Margin = marginConstruction;

            newAddressButton.Name = m_buttonProperties.GetLatestRankedName();
            newAddressButton.Content = m_buttonProperties.CONTENT;
            newAddressButton.Click += ClickFindAddress;       
            UserInputGrid.Children.Add (newAddressButton);
        }

        private void ClickRemoveBar (object sender, RoutedEventArgs e)
        {
            if (FilesList.Items.Count > MIN_ADDRESS_BARS)
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
                                             where itemsContent != m_barProperties.CONTENT
                                             select itemsContent;
            
            string[] allAddresses = barsQuery.ToArray();
            ByteConversion.Invoke (allAddresses);    
        }
        public event OnByteConversion ByteConversion;
        public delegate void OnByteConversion (string[] inputFilesAddresses);        
    }
}
