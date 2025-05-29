    using NAudio.Wave;
    using System;

    namespace SpotDifferenceGame.Managers
    {
        public class SoundManager
        {
            private IWavePlayer waveOutDevice;
            private AudioFileReader audioFileReader;

            public void PlaySoundEffect(string filePath, float volume = 0.5f)
            {
                try
                {
                    var audioFile = new AudioFileReader(filePath)
                    {
                        Volume = volume
                    };

                    var player = new WaveOutEvent();
                    player.Init(audioFile);
                    player.Play();

                    player.PlaybackStopped += (s, e) =>
                    {
                        audioFile.Dispose();
                        player.Dispose();
                    };

                }
                catch (Exception ex)
                {
                    Console.WriteLine("خطأ أثناء تشغيل مؤثر صوتي: " + ex.Message);
                }
            }


     

            public void Stop()
            {
           

                waveOutDevice?.Stop();
                audioFileReader?.Dispose();
                waveOutDevice?.Dispose();

                audioFileReader = null;
                waveOutDevice = null;
            }
        }
    }
