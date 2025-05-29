using NAudio.Wave;
using System;

namespace SpotDifferenceGame.Managers
{
    public class SoundPlayerManager
    {
        private IWavePlayer waveOutDevice;
        private AudioFileReader audioFileReader;

        public void PlayBackgroundMusic(string filePath, float volume = 0.5f)
        {
            try
            {
                Stop(); // ???? ?? ??? ???? ????? ????

                waveOutDevice = new WaveOutEvent();
                audioFileReader = new AudioFileReader(filePath)
                {
                    Volume = volume
                };

                waveOutDevice.Init(audioFileReader);
                waveOutDevice.PlaybackStopped += LoopPlayback;

                waveOutDevice.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("??? ????? ????? ?????: " + ex.Message);
            }
        }

        private void LoopPlayback(object sender, StoppedEventArgs e)
        {
            try
            {
                if (audioFileReader != null && waveOutDevice != null)
                {
                    audioFileReader.Position = 0;
                    waveOutDevice.Play();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("??? ????? ????? ????? ?????: " + ex.Message);
            }
        }

        public void Stop()
        {
            if (waveOutDevice != null)
                waveOutDevice.PlaybackStopped -= LoopPlayback;

            waveOutDevice?.Stop();
            audioFileReader?.Dispose();
            waveOutDevice?.Dispose();

            audioFileReader = null;
            waveOutDevice = null;
        }
    }
}
