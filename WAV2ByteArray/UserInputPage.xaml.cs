using System;
using System.Collections.Generic;
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

        private AFindButtonsProperties buttonProperties;
        private AnAddressBarsProperties barProperties;

        private ByteFactory output = new ByteFactory();

        private struct ErrorMessages
        {
            public const string NO_CONTENT = "You Must Select at least one file to continue!";
            public const string WRONG_FILE_TYPE = "File is not a .WAV!";
            public const string UNKNOWN = "Something went wrong :( contact the developer!";
            public const string MAX_ITEMS = "Only 20 files are allowed at once!";
            public const string MIN_ITEMS = "You must have at least one Item!";
        }

        public UserInputPage()
        {
            InitializeComponent();
            buttonProperties = new AFindButtonsProperties (UserInputGrid);
            barProperties = new AnAddressBarsProperties (UserInputGrid);
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
            newAddressBar.BorderBrush = barProperties.BorderBrush;
            newAddressBar.BorderThickness = barProperties.BorderThickness;
            newAddressBar.Name = barProperties.GetLatestRankedName();
            newAddressBar.Width = AnAddressBarsProperties.WIDTH;
            newAddressBar.Height = AnAddressBarsProperties.HEIGHT;
            newAddressBar.Content = AnAddressBarsProperties.CONTENT;            
            FilesList.Items.Add (newAddressBar);
        }

        private void CreateFindButton()
        {
            Button newAddressButton = new Button();
            newAddressButton.VerticalAlignment = buttonProperties.verticalAlignment;
            newAddressButton.HorizontalAlignment = buttonProperties.horizontalAlignment;
            newAddressButton.Width = AFindButtonsProperties.WIDTH;
            newAddressButton.Height = AFindButtonsProperties.HEIGHT;
            newAddressButton.SetValue (Grid.RowProperty, AFindButtonsProperties.ROW);
            newAddressButton.SetValue (Grid.ColumnProperty, AFindButtonsProperties.COLUMN);

            Thickness marginConstruction = buttonProperties.GetCopyLastButtonsMargin();
            marginConstruction.Top += AFindButtonsProperties.MARGIN_INCREMENT;
            newAddressButton.Margin = marginConstruction;

            newAddressButton.Name = buttonProperties.GetLatestRankedName();
            newAddressButton.Content = AFindButtonsProperties.CONTENT;
            newAddressButton.Click += ClickFindAddress;       
            UserInputGrid.Children.Add (newAddressButton);
        }

        private void ClickRemoveBar (object sender, RoutedEventArgs e)
        {
            if (FilesList.Items.Count > MIN_ADDRESS_BARS)
            {
                int notNeeded;
                ListBoxItem lastAddressBar = barProperties.GetReferenceLastRankedItem <ListBoxItem> (out notNeeded);
                Button lastBarButton = barProperties.GetReferenceLastRankedItem <Button> (out notNeeded);
                UserInputGrid.Children.Remove (lastAddressBar);
                UserInputGrid.Children.Remove (lastBarButton);
            }

            else
            {
                MessageBox.Show (ErrorMessages.MIN_ITEMS);
            }
        }      

        private void ClickConvert (object sender, RoutedEventArgs e)
        {
            ListBoxItem firstBar = FilesList.Items.GetItemAt (0) as ListBoxItem;

            if (firstBar != null) //conversion check
            {
                if (firstBar.Content.ToString() != AnAddressBarsProperties.CONTENT)
                {

                }

                else
                {
                    MessageBox.Show (ErrorMessages.NO_CONTENT);
                }
            }

            else
            {
                MessageBox.Show (ErrorMessages.UNKNOWN);
            }
        }
    }
}
