using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WAV2ByteArray
{
    internal static class InternalFacts
    {    
        public const int MIN_ADDRESS_BARS = 1;
        public const int MAX_ADDRESS_BARS = 5;
    }

    public static class ErrorMessages
    {
        public static readonly string MIN_ITEMS = "You must have a minimum item count of " + InternalFacts.MIN_ADDRESS_BARS.ToString() + "!";  
        public static readonly string MAX_ITEMS = "Only " + InternalFacts.MAX_ADDRESS_BARS.ToString() + " files are allowed at once!";          
        public const string NO_CONTENT = "You Must Select at least one file to continue!";
        public const string WRONG_FILE_TYPE = "File is not a .WAV!";
        public const string UNKNOWN = "Something went wrong :( contact the developer!";        
        public const string BAD_FILE = "The file you specified could not be opened!";
    }

    public enum PageOptions //enum is a type, not a variable. therefore, they are static by definition.
    {
        INPUT_PAGE,
        OUTPUT_PAGE,
    }
}
