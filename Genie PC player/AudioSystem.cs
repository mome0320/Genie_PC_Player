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
       public WaveOutEvent waveout;
       public VolumeWaveProvider16 volumeProvider;
        public string url;
       private WaveStream file;
        public string song_ID;

        public AudioSystem(string song_ID)
        {
            this.song_ID = song_ID;
            Playing = null;
        }
        public AudioSystem()
        {
            this.song_ID = "";
        }
        public void init(String url,float volume,bool isflac)
        {
            ms = new MemoryStream();
            using (Stream stream = WebRequest.Create(url).GetResponse().GetResponseStream())
            {
                byte[] buffer = new byte[32768];
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (ms != null)
                    {
                        ms.Write(buffer, 0, read);
                    }
                    else
                    {
                        ms = new MemoryStream();
                    }
                }
                stream.Dispose();
                stream.Close();
            }
            ms.Position = 0;
            if(isflac)
            file = new FlacReader(ms);else
            file = WaveFormatConversionStream.CreatePcmStream(new Mp3FileReader(ms));
            wavestream = new BlockAlignReductionStream(file);

            //waveout = new NAudio.Wave.DirectSoundOut();
            waveout = new WaveOutEvent();
            //waveout = new WasapiOut();
            waveout.Init(wavestream);
            volumeProvider = new VolumeWaveProvider16(wavestream);
            volumeProvider.Volume = volume;
            waveout.DeviceNumber = -1;
            waveout.Init(volumeProvider);
            waveout.Play();
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
                if (ms != null) { ms.Close(); ms.Dispose();}
                ms = null;
                if (wavestream != null)
                {
                    wavestream.Close(); wavestream.Dispose();
                }
                wavestream = null;
                if (file != null)
                {
                    file.Close(); file.Dispose();
                }
                file = null;
                volumeProvider = null;
                Playing = null;
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
