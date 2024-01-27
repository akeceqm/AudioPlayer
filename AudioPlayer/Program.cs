using AudioPlayer;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

class Program : AudioListContainer
{
    static void Main()
    {
        AudioPlayerCode audioPlayer = new();
        audioPlayer.Run();
    }
}


