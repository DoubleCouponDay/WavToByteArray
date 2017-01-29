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
            inputPage = new UserInputPage (OnPageChange);       
            outputPage = new OutputPage (OnPageChange);                    
            Content = inputPage; //must extend Page class for this to work.
        }

        public void OnPageChange (PageOptions pageToView, string[] sendersMessage)
        {            
            switch (pageToView)
            {
                case PageOptions.INPUT_PAGE:
                    Content = inputPage;
                    break;

                case PageOptions.OUTPUT_PAGE:           
                    outputPage = new OutputPage (OnPageChange);                             
                    outputPage.ConvertWavToBytes (sendersMessage);
                    Content = outputPage;
                    break;
            }
        }

        /// <summary>
        /// Delegate is used by all events wishing to change the page. 
        /// Pages who wish to invoke this delegate should be expected to take a subscriber method as argument, then subscribe it to its own event.
        /// </summary>
        /// <param name="pageToView"></param>
        /// <param name="sendersMessage"></param>
        public delegate void PageChangeDelegate (PageOptions pageToView, string[] sendersMessage); 
    }
}
