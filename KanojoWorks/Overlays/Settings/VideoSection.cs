using System.Drawing;
using osu.Framework.Allocation;
using osu.Framework.Configuration;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Platform;
using KanojoWorks.Configuration;
using KanojoWorks.Graphics;

namespace KanojoWorks.Overlays.Settings
{
    public class VideoSection : SettingsSection
    {
        private Bindable<ScalingMode> scalingMode;
        private Bindable<Size> sizeFullscreen;
        private readonly IBindable<Display> currentDisplay = new Bindable<Display>();
        private readonly IBindableList<WindowMode> windowModes = new BindableList<WindowMode>();
        private readonly BindableList<Size> resolutions = new BindableList<Size>(new[] { new Size(9999, 9999) });

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager config, KanojoWorksConfigManager kwConfig, GameHost host)
        {
            scalingMode = kwConfig.GetBindable<ScalingMode>(KanojoWorksSetting.ScalingMode);
            sizeFullscreen = config.GetBindable<Size>(FrameworkSetting.SizeFullscreen);

            if (host.Window != null)
            {
                currentDisplay.BindTo(host.Window.CurrentDisplayBindable);
                windowModes.BindTo(host.Window.SupportedWindowModes);
            }

            SectionName = "VIDEO";
            Children = new Drawable[]
            {
                new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    Spacing = new osuTK.Vector2(5),
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Text = "Resolution",
                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                        },
                        new ResolutionDropdown
                        {
                            Width = 200,
                            ItemSource = resolutions,
                            Current = sizeFullscreen
                        },
                    }
                },
                new SpriteText
                {
                    Text = "Window Mode",
                    Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                },
                new SpriteText
                {
                    Text = "Scaling Mode",
                    Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                },
                new SpriteText
                {
                    Text = "Frame Limiter",
                    Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                },
                new SpriteText
                {
                    Text = "Threading Mode",
                    Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                },
            };
        }

        public class ResolutionDropdown : BasicDropdown<Size>
        {
            protected override string GenerateItemText(Size item)
            {
                if (item == new Size(9999, 9999))
                    return "";

                return $"{item.Width}x{item.Height}";
            }
        }
    }
}
