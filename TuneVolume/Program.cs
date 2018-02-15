using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*  音量とミュートを設定
 *      TuneVolume /v <音量>      指定した音量に設定
 *      TuneVolume /m <ON/OFF>    ミュートをON/OFF
 *      TuneVolume <音量>         指定した音量に設定
 *      TUneVolume 0              音量を「0」に設定してミュートをON
 *      TuneVolume                音量/ミュート状態を表示
 */

namespace TuneVolume
{
    class Program
    {
        static void Main(string[] args)
        {
            ArgsParam ap = new ArgsParam(args);
            if (ap.IsPrint)
            {
                Console.WriteLine(
                    "音量     : {0}\r\n" +
                    "ミュート : {1}",
                    Sound.GetVolume() * 100, Sound.GetMute() ? "ON" : "OFF");
            }
            else
            {
                Sound.SetVolume((float)(ap.Volume / 100.0));
                Sound.SetMute(ap.IsMute);
            }
        }
    }
}
