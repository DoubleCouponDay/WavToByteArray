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
    /// Interaction logic for OutputPage.xaml
    /// </summary>
    public partial class OutputPage : Page
    {
        private ByteFactory m_byteFactory;
        private AnAddressBarsProperties m_barProperties;

        public OutputPage()
        {
            InitializeComponent();
            m_byteFactory = new ByteFactory();
            m_barProperties = new AnAddressBarsProperties (OutputPageGrid);            
        }

        /// <summary>
        /// Displays your WAV files bytes in OutputPage.ByteArrayList.
        /// If your files arent WAV files, nothing will happen!
        /// </summary>
        /// <param name="fileAddresses">windows addresses to audio files</param>
        public void ConvertWavToBytes (string[] fileAddresses)
        {

        }

        private void ToClipboardClick (object sender, RoutedEventArgs e)
        {

        }
    }
}
