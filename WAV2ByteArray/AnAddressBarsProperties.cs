using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WAV2ByteArray
{
    public class AnAddressBarsProperties : RankedNameModel <ListBoxItem>
    {
        public readonly Thickness BorderThickness = new Thickness (2);
        public readonly SolidColorBrush BorderBrush = Brushes.Beige;
        public readonly double WIDTH = double.NaN;
        public readonly double HEIGHT = 20;
        public readonly string CONTENT = "...";

        public override string StringPartOfConventionalName { get { return "AddressBar"; } }

        public AnAddressBarsProperties (Grid inputGrid) : base (inputGrid) { }
    }
}
