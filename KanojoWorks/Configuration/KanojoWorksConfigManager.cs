using osu.Framework.Configuration;
using osu.Framework.Platform;
using osu.Framework.Testing;

namespace KanojoWorks.Configuration
{
    [ExcludeFromDynamicCompile]
    public class KanojoWorksConfigManager : IniConfigManager<KanojoWorksSetting>
    {
        public KanojoWorksConfigManager(Storage storage)
            : base(storage)
        {
        }

        protected override void InitialiseDefaults()
        {
            base.InitialiseDefaults();

            // Text / Reading defaults
            SetDefault(KanojoWorksSetting.TextDisplaySpeed, 0.8, 0, 1, 0.01);
            SetDefault(KanojoWorksSetting.AutoPlaySpeed, 0.8, 0, 1, 0.01);

            // Novel Defaults
            SetDefault(KanojoWorksSetting.SkipUnreadText, false);
            SetDefault(KanojoWorksSetting.MarkReadText, true);

            // Audio volume defaults
            SetDefault(KanojoWorksSetting.MasterVolume, 0.8, 0, 1, 0.01);
            SetDefault(KanojoWorksSetting.MenuVolume, 1.0, 0, 1, 0.01);
            SetDefault(KanojoWorksSetting.NovelBGMVolume, 0.8, 0, 1, 0.01);
            SetDefault(KanojoWorksSetting.VoiceMasterVolume, 1, 0, 1, 0.01);
            SetDefault(KanojoWorksSetting.NovelSFXVolume, 0.95, 0, 1, 0.01);

            // Scaling defaults
            SetDefault(KanojoWorksSetting.ScalingMode, ScalingMode.NoScaling);
            SetDefault(KanojoWorksSetting.Scale, 0.8f, 0.2f, 1f);
        }
    }

    public enum KanojoWorksSetting
    {
        ScalingMode,
        Scale,
        TextDisplaySpeed,
        AutoPlaySpeed,
        SkipUnreadText,
        MarkReadText,
        MasterVolume,
        MenuVolume,
        NovelBGMVolume,
        VoiceMasterVolume,
        NovelSFXVolume
    }
}
