using System;
using System.Reflection;
using KanojoWorks;
using osu.Framework.Development;

namespace KanojoWorksEditor
{
    public class KanojoWorksEditorBase : KanojoWorksGameBase
    {
        public virtual Version AssemblyVersion => Assembly.GetEntryAssembly()?.GetName().Version ?? new Version();
        public bool IsDeployedBuild => AssemblyVersion.Major > 0;

        public virtual string Version
        {
            get
            {
                if (!IsDeployedBuild)
                    return @"Mode: " + (DebugUtils.IsDebugBuild ? @"debug" : @"release");

                var version = AssemblyVersion;
                return $@"{version.Major}.{version.Minor}.{version.Build}";
            }
        }

        public KanojoWorksEditorBase()
        {
            GameName = $"KanojoWorks Editor ({Version})";
        }
    }
}
