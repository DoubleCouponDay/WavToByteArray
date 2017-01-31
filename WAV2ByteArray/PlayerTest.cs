using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.IO;
using System.Windows;
using System.Windows.Threading;

namespace WAV2ByteArray
{
    class PlayerTest
    {
        Stream testStream = new MemoryStream();
        SoundPlayer player;

        public PlayerTest()
        {
            testStream.Position = 0;
            testStream.Seek (0, SeekOrigin.Begin);
        }

        public void WriteStream (byte[] bytes)
        {
                testStream.Write (bytes, 0, bytes.Length); 
                
                if (testStream.CanSeek)
                {
                    testStream.Seek (0, SeekOrigin.Begin);
                }
                player = new SoundPlayer (testStream);                              
        }

        public void PlayStream()
        {
            player.Play();
        }

        public void StopPlaying()
        {
            player.Stop();
        }
    }
}
