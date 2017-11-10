using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Flac;

namespace Genie_PC_player
{
    class AudioSystem
    {
        public static AudioSystem Playing=new AudioSystem();
        Stream ms;
       public WaveStream wavestream;
       public DirectSoundOut waveout;
       public VolumeWaveProvider16 volumeProvider;
        public string song_ID;

        public AudioSystem(string song_ID)
        {
            this.song_ID = song_ID;
        }
        public AudioSystem()
        {
            this.song_ID = "";
        }

        public void init(String url)
        {
            ms = new MemoryStream();

            using (Stream stream = WebRequest.Create(url).GetResponse().GetResponseStream())
            {
                byte[] buffer = new byte[32768];
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                stream.Dispose();
                stream.Close();
            }
            ms.Position = 0;
            WaveStream file = null;
            //file = new FlacReader(ms);
            file = new Mp3FileReader(ms);
            wavestream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(file));
            //is FLAC
            //wavestream = new BlockAlignReductionStream(WaveFormatConversionStream.CreatePcmStream(new FlacReader(ms)));

            waveout = new NAudio.Wave.DirectSoundOut();
            waveout.Init(wavestream);
            waveout.Play();
            /*volumeProvider = new VolumeWaveProvider16(wavestream);
            waveout.Init(volumeProvider);*/
        }

        public void Play()
        {
            waveout.Play();
        }
        public void Pause()
        {
            waveout.Pause();
        }
        public void Stop()
        {
            waveout.Stop();
        }
        public void Dispose()
        {
            try
            {
                if (waveout != null) waveout.Dispose();
                waveout = null;
                if (ms != null) { ms.Dispose(); ms.Close(); }
                ms = null;
                if (wavestream != null)
                {
                    wavestream.Dispose(); wavestream.Close();
                    wavestream = null;
                }
            }
            catch (Exception e) { }
        }
        public TimeSpan getCurrentTime()
        {
            if(wavestream != null)
            return wavestream.CurrentTime;
            return TimeSpan.Zero;
        }
        public TimeSpan getTotalTime()
        {
            if (wavestream != null)
                return wavestream.TotalTime;
            return TimeSpan.Zero;
        }

    }
                }
