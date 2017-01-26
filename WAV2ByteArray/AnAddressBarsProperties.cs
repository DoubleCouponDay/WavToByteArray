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

        public override string NamesStringPart { get; protected set; }
        public override string Content { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputGrid">The grid to source the first ranked address bar as a template.</param>
        public AnAddressBarsProperties (Grid inputGrid) : base (inputGrid)
        {
            this.NamesStringPart = "AddressBar";
            this.Content = "...";
        }

        /// <summary>
        ///  Returns a ListBoxItem designed for my app's standard ListBox.
        /// </summary>
        /// <param name="barsContent">The content which the bar will display</param>
        /// <returns></returns>
        public ListBoxItem CreateNewAddressBar (string barsContent)
        {
            ListBoxItem newAddressBar = new ListBoxItem();
            newAddressBar.BorderBrush = BorderBrush;
            newAddressBar.BorderThickness = BorderThickness;
            newAddressBar.Name = GetLatestRankedName();
            newAddressBar.Width = WIDTH;
            newAddressBar.Height = HEIGHT;
            newAddressBar.Content = barsContent;            
            return newAddressBar;
        }
    }
}
