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
            Set(KanojoWorksSetting.TextDisplaySpeed, 0.8, 0, 1, 0.01);
            Set(KanojoWorksSetting.AutoPlaySpeed, 0.8, 0, 1, 0.01);

            Set(KanojoWorksSetting.SkipUnreadText, false).BindValueChanged((v) =>
            {
                if (v.NewValue) Set(KanojoWorksSetting.SkipUnreadText, true);
            });

            Set(KanojoWorksSetting.MarkReadText, true).BindValueChanged((v) =>
            {
                if (!v.NewValue) Set(KanojoWorksSetting.MarkReadText, false);
            });

            // Audio volume defaults
            Set(KanojoWorksSetting.MasterVolume, 0.8, 0, 1, 0.01);
            Set(KanojoWorksSetting.MenuVolume, 1.0, 0, 1, 0.01);
            Set(KanojoWorksSetting.NovelBGMVolume, 0.8, 0, 1, 0.01);
            Set(KanojoWorksSetting.VoiceMasterVolume, 1, 0, 1, 0.01);
            Set(KanojoWorksSetting.NovelSFXVolume, 0.95, 0, 1, 0.01);

            // Scaling defaults
            Set(KanojoWorksSetting.ScalingMode, ScalingMode.NoScaling);
            Set(KanojoWorksSetting.Scale, 0.8f, 0.2f, 1f);
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