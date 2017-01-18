using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WAV2ByteArray
{
    abstract class ButtonNamingIndex
    {


        protected abstract string Name { get; }    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="inputGrid"></param>
        /// <param name="tempName"></param>
        protected ButtonNamingIndex (Grid inputGrid)
        {
            gridReference = inputGrid;
            int notNeeded;
            buttonReference = GetReferenceLastRankedButton (out notNeeded);
        }

        
    }
}
