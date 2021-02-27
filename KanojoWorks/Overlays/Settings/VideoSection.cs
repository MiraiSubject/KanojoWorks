using System;
using System.Drawing;
using System.Linq;
using KanojoWorks.Configuration;
using KanojoWorks.Graphics;
using KanojoWorks.Graphics.UserInterface;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Localisation;
using osu.Framework.Platform;
using osuTK;

namespace KanojoWorks.Overlays.Settings
{
    public class VideoSection : SettingsSection
    {
        private Bindable<ScalingMode> scalingMode;
        private Bindable<Size> sizeFullscreen;
        private Bindable<WindowMode> currentWindowMode = new Bindable<WindowMode>();
        private readonly IBindable<Display> currentDisplay = new Bindable<Display>();
        private readonly IBindableList<WindowMode> windowModes = new BindableList<WindowMode>();
        private readonly BindableList<Size> resolutions = new BindableList<Size>(new[] { new Size(9999, 9999) });

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager config, KanojoWorksConfigManager kwConfig, GameHost host)
        {
            scalingMode = kwConfig.GetBindable<ScalingMode>(KanojoWorksSetting.ScalingMode);
            currentWindowMode = config.GetBindable<WindowMode>(FrameworkSetting.WindowMode);
            sizeFullscreen = config.GetBindable<Size>(FrameworkSetting.SizeFullscreen);

            if (host.Window != null)
            {
                currentDisplay.BindTo(host.Window.CurrentDisplayBindable);
                windowModes.BindTo(host.Window.SupportedWindowModes);
            }

            const int max_width = 180;

            SectionName = "VIDEO";
            Children = new Drawable[]
            {
                new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(5),
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Width = max_width,
                            Text = "Resolution",
                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                        },
                        new ResolutionDropdown
                        {
                            Width = 200,
                            ItemSource = resolutions,
                            Current = sizeFullscreen
                        }
                    }
                },
                new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(5),
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Width = max_width,
                            Text = "Window Mode",
                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                        },
                        new KanojoWorksEnumDropdown<WindowMode>
                        {
                            Width = 200,
                            Current = currentWindowMode
                        }
                    }
                },
                new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(5),
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Width = max_width,
                            Text = "Scaling Mode",
                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                        },
                        new KanojoWorksEnumDropdown<ScalingMode>
                        {
                            Width = 200,
                            Current = scalingMode
                        }
                    }
                },
                new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(5),
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Width = max_width,
                            Text = "Frame Limiter",
                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                        },
                        new KanojoWorksEnumDropdown<FrameSync>
                        {
                            Width = 200,
                            Current = config.GetBindable<FrameSync>(FrameworkSetting.FrameSync)
                        }
                    }
                },
                new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Horizontal,
                    Spacing = new Vector2(5),
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Width = max_width,
                            Text = "Threading Mode",
                            Font = KanojoWorksFont.GetFont(size: 30, weight: FontWeight.Light)
                        },
                        new KanojoWorksEnumDropdown<ExecutionMode>
                        {
                            Width = 200,
                            Current = config.GetBindable<ExecutionMode>(FrameworkSetting.ExecutionMode)
                        }
                    }
                }
            };
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();

            currentDisplay.BindValueChanged(display => Schedule(() =>
            {
                resolutions.RemoveRange(0, resolutions.Count);

                if (display.NewValue != null)
                {
                    resolutions.AddRange(display.NewValue.DisplayModes
                                                .Where(m => m.Size.Width >= 800 && m.Size.Height >= 600)
                                                .OrderByDescending(m => Math.Max(m.Size.Height, m.Size.Width))
                                                .Select(m => m.Size)
                                                .Distinct());
                }
            }), true);
        }

        public class ResolutionDropdown : KanojoWorksDropdown<Size>
        {
            protected override LocalisableString GenerateItemText(Size item)
            {
                if (item == new Size(9999, 9999))
                    return "";

                return $"{item.Width}x{item.Height}";
            }
        }
    }
}
