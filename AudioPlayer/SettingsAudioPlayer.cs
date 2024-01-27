using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    class SettingsAudioPlayer
    {
       public void Text()
        {
            Console.WriteLine("Настройки аудиоплеера");

            Console.WriteLine(" * Нажмите 'q' для break.");
            Console.WriteLine(" * Нажмите 'w' для pause.");
            Console.WriteLine(" * Нажмите 'e' для continue.");
            Console.WriteLine(" * Нажмите 'z' для next.");
            Console.WriteLine(" * Нажмите 'x' для back.");
        }
    }
}
