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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WAV2ByteArray
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private UserInputPage inputPage;
        private OutputPage outputPage;

        public MainWindow()
        {
            InitializeComponent();       
            inputPage = new UserInputPage();       
            outputPage = new OutputPage();
            inputPage.ByteConversion += OnByteConversion;         
            Content = inputPage; //must extend Page class for this to work.
        }

        /// <summary>
        /// This method's header matches UserInputPage.InByteConversion so that it can subscribe to the UserInputPage.ByteConversion event.
        /// </summary>
        /// <param name="inputFilesAddresses"></param>
        public void OnByteConversion (string[] inputFilesAddresses)
        {            
            outputPage.ConvertWavToBytes (inputFilesAddresses);            
            Content = outputPage;
        }
    }

    public struct ErrorMessages
    {
        public const string MIN_ADDRESS_BARS = "1";
        public const string MAX_ADDRESS_BARS = "5";
        public const string MIN_ITEMS = "You must have a minimum item count of " + MIN_ADDRESS_BARS + "!";  
        public const string MAX_ITEMS = "Only " + MAX_ADDRESS_BARS + " files are allowed at once!";
          
        public const string NO_CONTENT = "You Must Select at least one file to continue!";
        public const string WRONG_FILE_TYPE = "File is not a .WAV!";
        public const string UNKNOWN = "Something went wrong :( contact the developer!";        
        public const string BAD_FILE = "The file you specified could not be opened!";
    }
}
