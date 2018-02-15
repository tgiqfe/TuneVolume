using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TuneVolume
{
    class ArgsParam
    {
        //  クラスパラメータ
        public int Volume { get; set; }
        public bool IsMute { get; set; }
        public bool IsPrint { get; set; }

        //  コンストラクタ
        public ArgsParam() { }
        public ArgsParam(string[] args)
        {
            this.IsPrint = args.Length == 0;
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i].ToLower())
                {
                    case "/v":
                    case "-v":
                    case "/volume":
                    case "-volume":
                    case "--volume":
                        if (int.TryParse(args[++i], out int tempVolume))
                        {
                            this.Volume = tempVolume;
                        }
                        break;
                    case "/m":
                    case "-m":
                    case "/mute":
                    case "-mute":
                    case "--mute":
                        string tempMute = args[++i].ToLower();
                        if (new string[4] { "1", "true", "yes", "on" }.Any(x => x == tempMute))
                        {
                            this.IsMute = true;
                        }
                        break;
                    default:
                        if (int.TryParse(args[i], out int tempVolume2))
                        {
                            this.Volume = tempVolume2;
                            if(Volume == 0)
                            {
                                this.IsMute = true;
                            }
                        }
                        break;
                }
            }
        }
    }
}
