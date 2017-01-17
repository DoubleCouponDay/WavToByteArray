using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace WAV2ByteArray
{
    class AnAddressBarsProperties
    {
        public readonly Thickness BorderThickness = new Thickness (2);
        public readonly SolidColorBrush BorderBrush = Brushes.Beige;
        public const double WIDTH = double.NaN;
        public const double HEIGHT = 20;
        public const string CONTENT = "...";

        public AnAddressBarsProperties() { };
    }
}
