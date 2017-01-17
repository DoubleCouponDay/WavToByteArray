using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAV2ByteArray
{
    class ViewElementNotFoundException : Exception
    {
        public ViewElementNotFoundException (string mansplaining) : base (mansplaining) { }
    }
}
