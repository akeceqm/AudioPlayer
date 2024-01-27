using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudioPlayer
{
    public class AudioPlayerCode : AudioListContainer
    {
        private WaveOutEvent outputDevice;
        private ChangeTrack cj;
        private SettingsAudioPlayer settings;

        public AudioPlayerCode()
        {
            outputDevice = new WaveOutEvent();
            cj = new ChangeTrack(listMusic, outputDevice);
            settings = new SettingsAudioPlayer();
        }

        public void Run()
        {
            Console.WriteLine("Введите путь к аудиофайлу или папке:");
            string filePath = Console.ReadLine().Trim(new char[] {' ','*','"'});

            
            if (File.Exists(filePath))
            {
                listMusic.Add(filePath);
            }
            else if (Directory.Exists(filePath))
            {
                string[] audioFiles = Directory.GetFiles(filePath, "*.mp3", SearchOption.AllDirectories);

                foreach (string audio in audioFiles)
                {
                    listMusic.Add(audio);
                }
            }

            if (listMusic.Count > 0)
            {
                Console.WriteLine("Найдены следующие аудиофайлы:");

                foreach (string musicFile in listMusic)
                {
                    Console.WriteLine(musicFile);
                }

                int currentSongIndex = 0;

                List<AudioFileReader> audioReaders = [];

                foreach (string musicFile in listMusic)
                {
                    audioReaders.Add(new AudioFileReader(musicFile));
                }


                int numberOfOutputChannels = 2;
                MultiplexingSampleProvider multiplexingProvider = new(audioReaders, numberOfOutputChannels);
                outputDevice.Init(multiplexingProvider);


                outputDevice.Init(multiplexingProvider);

                Console.WriteLine($"Играет: {filePath}");
                outputDevice.Play();
                settings.Text();


                while (true)
                {
                    var key = Console.ReadKey().KeyChar;
                    if (key == 'q')
                        break;
                    if (key == 'w')
                        outputDevice.Pause();
                    if (key == 'e')
                        outputDevice.Play();
                    if (key == 'z')
                        cj.NextTrack();
                    if (key == 'x')
                        cj.BackTrack();

                }
            }
            else
            {
                Console.WriteLine("Увы и ах, но неверно");
            }
        }
    }
}
