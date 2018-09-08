using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Screen_Capture_Recorder
{
    class Code
    {
        public List<string> getAllFile()
        {
            try
            {
                string[] arr = Directory.GetFiles(".\\ffmpeg code", "*.txt");
                List<string> list = new List<string>();
                foreach (string line in arr)
                {
                    list.Add(Path.GetFileName(line));
                }
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public string codeLive(int number, string output, string code)
        {
            string outCode = string.Format("-vcodec libx264 -pix_fmt yuv420p -b:v 2500k -profile:v main -level 3.1 -acodec libmp3lame -b:a 128k -ar 44100 -preset fast -f flv \"{0}\"", output);
            string raw = is64bit() + "ffmpeg -y -f dshow -framerate 30 -i video=\"screen-capture-recorder\":audio=\"virtual-audio-capturer\" ";
            string mainCode = "";
            if (number > 0)
            {
                mainCode = code.Replace("ffmpeg -y -i \"{input}.*\"", raw).Replace("{output}.mp4", output);
            }
            else
            {
                mainCode = raw + outCode;
            }

            return mainCode;
        }

        public string is64bit()
        {
            if (Environment.Is64BitOperatingSystem)
            {
                return ".\\bin\\x64\\";
            }
            else
            {
                return ".\\bin\\x86\\";
            }
        }


    }
}
