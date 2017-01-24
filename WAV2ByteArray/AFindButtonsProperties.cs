using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace WAV2ByteArray
{
    /// <summary>
    /// A Grouping of properties for a FindAddress button.
    /// Must be passed reference of the UserInputGrid because im lazy and dont want to learn dynamic elements yet ;)
    /// </summary>
    public class AFindButtonsProperties : RankedNameModel <Button>
    {
        public readonly int ROW = 0;
        public readonly int COLUMN = 1;
        public readonly double WIDTH = 30;
        public readonly double HEIGHT = 20;
        public readonly double MARGIN_INCREMENT = 20;
        public readonly string CONTENT = "...";

        public readonly VerticalAlignment verticalAlignment = VerticalAlignment.Top;
        public readonly HorizontalAlignment horizontalAlignment = HorizontalAlignment.Left;

        public override string StringPartOfConventionalName { get { return "FindAddressButton"; } }

        public AFindButtonsProperties (Grid inputGrid) : base (inputGrid) { }

        public Thickness GetCopyLastButtonsMargin()
        {
            Button lastButton = GetReferenceLastRankedItem();
            return new Thickness (lastButton.Margin.Left,
                                  lastButton.Margin.Top,
                                  lastButton.Margin.Right,
                                  lastButton.Margin.Bottom
                                 );
        }    
    }
}
