using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public  class AudioListContainer
    {
        public List<string> listMusic { get; set; }

        public AudioListContainer()
        {
            listMusic = [];
        }
    }
}
