using System;
using System.Linq;
using osu.Framework;
using osu.Framework.Platform;

namespace SampleNovel.Desktop
{
    public static class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            bool useOsuTK = args.Contains(@"--tk");
            using (GameHost host = Host.GetSuitableHost(@"SampleNovel", useOsuTK: useOsuTK))
            using (osu.Framework.Game game = new SampleGameDesktop())
                host.Run(game);
        }
    }
}
