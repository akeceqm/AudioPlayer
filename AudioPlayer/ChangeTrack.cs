using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    partial class ChangeTrack:AudioListContainer
    {
        int currentSongIndex = 0;
        private List<string> listMusic;
        WaveOutEvent outputDevice = new WaveOutEvent();

        public ChangeTrack(List<string> listMusic, WaveOutEvent outputDevice)
        {
            this.listMusic = listMusic;
            this.outputDevice = outputDevice;
            this.currentSongIndex = 0;
        }



        public void NextTrack()
        {
            if (listMusic.Count > 0)
            {
                outputDevice.Stop();
                currentSongIndex = (currentSongIndex + 1) % listMusic.Count;

                Console.WriteLine($"Переключено на следующую песню: {listMusic[currentSongIndex]}");

                var newAudioReader = new AudioFileReader(listMusic[currentSongIndex]);

                outputDevice.Init(newAudioReader);
                outputDevice.Play();
            }
            else
            {
                Console.WriteLine("Отсутствуют аудиофайлы.");
            }
        }

        public void BackTrack()
        {
            if (listMusic.Count > 0)
            {
                outputDevice.Stop();
                currentSongIndex = (currentSongIndex - 1 + listMusic.Count) % listMusic.Count;

                Console.WriteLine($"Переключено на предыдущую песню: {listMusic[currentSongIndex]}");

                var newAudioReader = new AudioFileReader(listMusic[currentSongIndex]);

                outputDevice.Init(newAudioReader);
                outputDevice.Play();
            }
            else
            {
                Console.WriteLine("Отсутствуют аудиофайлы.");
            }
        }
    }
}
