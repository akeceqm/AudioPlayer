using AudioPlayer;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

class Program : AudioListContainer
{
    static void Main()
    {
        WaveOutEvent outputDevice = new WaveOutEvent();
        AudioListContainer audioListContainer = new AudioListContainer();
        ChangeTrack cj = new ChangeTrack(audioListContainer.listMusic, outputDevice);

        Console.WriteLine("Введите путь к аудиофайлу или папке:");
        string filePath = Console.ReadLine();
        if (File.Exists(filePath))
        {
            audioListContainer.listMusic.Add(filePath);
        }
        else if (Directory.Exists(filePath))
        {
            string[] audioFiles = Directory.GetFiles(filePath, "*.mp3", SearchOption.AllDirectories);

            foreach (string audio in audioFiles)
            {
                audioListContainer.listMusic.Add(audio);
            }
        }

        if (audioListContainer.listMusic.Count > 0)
        {
            Console.WriteLine("Найдены следующие аудиофайлы:");

            foreach (string musicFile in audioListContainer.listMusic)
            {
                Console.WriteLine(musicFile);
            }

            int currentSongIndex = 0;

            List<AudioFileReader> audioReaders = [];

            foreach (string musicFile in audioListContainer.listMusic)
            {
                audioReaders.Add(new AudioFileReader(musicFile));
            }


            int numberOfOutputChannels = 2;
            MultiplexingSampleProvider multiplexingProvider = new MultiplexingSampleProvider(audioReaders, numberOfOutputChannels);
            outputDevice.Init(multiplexingProvider);


                outputDevice.Init(multiplexingProvider);

            Console.WriteLine($"Играет: {filePath}");
            outputDevice.Play();


            Console.WriteLine("Нажмите 'q' для выхода.");
            Console.WriteLine("Нажмите 'r' для pause.");
            Console.WriteLine("Нажмите 'e' для continue.");
            while (true)
            {
                var key = Console.ReadKey().KeyChar;

                if (key == 'q')
                    break;
                if (key == 'r')
                    outputDevice.Pause();
                if (key == 'e')
                    outputDevice.Play();
                if (key == 'x')
                    cj.NextTrack();
                if (key == 'z')
                    cj.BackTrack();

            }
        }

        else
        {
            Console.WriteLine("Увы и ах, но неверно");
        }
    }
}

