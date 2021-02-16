using System;
using System.Drawing;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Configuration;
using osu.Framework.Graphics.Containers;
using osu.Framework.Platform;
using KanojoWorks.Configuration;

namespace KanojoWorks.Graphics.Containers
{
    public class FixedResContainer : Container
    {
        private osuTK.Vector2 originalResolution;
        private Bindable<Size> windowedResolution;
        private Bindable<WindowMode> windowMode;
        private readonly IBindable<Display> currentDisplay = new Bindable<Display>();
        private Bindable<ScalingMode> scalingMode = new Bindable<ScalingMode>(ScalingMode.MaintainAspectRatio);

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager frameworkConfig, GameHost host)
        {
            // Store the original resolution in the property so it can be referenced later for scaling purposes.
            originalResolution = Size;

            windowedResolution = frameworkConfig.GetBindable<Size>(FrameworkSetting.WindowedSize);
            //windowedResolution.ValueChanged += _ => updateContainerSize();

            windowMode = frameworkConfig.GetBindable<WindowMode>(FrameworkSetting.WindowMode);
            //windowMode.ValueChanged += _ => updateContainerSize();

            currentDisplay.BindTo(host.Window.CurrentDisplayBindable);
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            updateContainerSize();
        }

        private void updateContainerSize()
        {
            float resolutionWidth;
            float resolutionHeight;

            if (windowMode.Value == WindowMode.Windowed)
            {
                resolutionHeight = windowedResolution.Value.Height;
                resolutionWidth = windowedResolution.Value.Width;
            }
            else
            {
                resolutionHeight = currentDisplay.Value.Bounds.Height;
                resolutionWidth = currentDisplay.Value.Bounds.Width;
            }

            switch (scalingMode.Value)
            {
                case ScalingMode.MaintainAspectRatio:
                    var ratio = Math.Min(resolutionWidth / originalResolution.X, resolutionHeight / originalResolution.Y);
                    Schedule(() => this.ScaleTo(ratio));
                    break;

                case ScalingMode.Stretch:
                    var xRatio = resolutionWidth / originalResolution.X;
                    var yRatio = resolutionHeight / originalResolution.Y;
                    Schedule(() => this.ScaleTo(new osuTK.Vector2(xRatio, yRatio)));
                    break;

                case ScalingMode.NoScaling:
                default:
                    break;
            }
        }

        protected override void Update()
        {
            base.Update();
            updateContainerSize();
        }
    }
}
