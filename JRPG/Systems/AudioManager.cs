using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JRPG.Systems
{
    internal class AudioManager
    {
        private IWavePlayer outputDevice;
        private AudioFileReader audioFile;

        /// <summary>
        /// Plays the given audio file as looping background music.
        /// Stops any currently playing track.
        /// </summary>
        /// <param name="filePath">Path to the audio file (MP3, WAV, etc.)</param>
        public void PlayBGM(string filePath)
        {
            StopBGM(); // Stop any previous music

            audioFile = new AudioFileReader(filePath);
            var loopStream = new LoopStream(audioFile);

            outputDevice = new WaveOutEvent();
            outputDevice.Init(loopStream);
            outputDevice.Play();
        }
        public void StopBGM()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }

            if (audioFile != null)
            {
                audioFile.Dispose();
                audioFile = null;
            }
        }

        public void Dispose()
        {
            StopBGM();
        }
    }

    /// <summary>
    /// Simple wrapper to loop an audio stream
    /// </summary>
    public class LoopStream : WaveStream
    {
        private readonly WaveStream sourceStream;

        public LoopStream(WaveStream source)
        {
            sourceStream = source;
        }

        public override WaveFormat WaveFormat => sourceStream.WaveFormat;

        public override long Length => long.MaxValue; // infinite loop

        public override long Position
        {
            get => sourceStream.Position;
            set => sourceStream.Position = value;
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int totalBytesRead = 0;

            while (totalBytesRead < count)
            {
                int bytesRead = sourceStream.Read(buffer, offset + totalBytesRead, count - totalBytesRead);
                if (bytesRead == 0)
                {
                    sourceStream.Position = 0; // restart loop
                    continue;
                }

                totalBytesRead += bytesRead;
            }

            return totalBytesRead;
        }
    }
}
