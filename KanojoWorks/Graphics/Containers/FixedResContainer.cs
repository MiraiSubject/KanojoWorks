using System;
using System.Drawing;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Platform;
using KanojoWorks.Configuration;

namespace KanojoWorks.Graphics.Containers
{
    public class FixedResContainer : Container
    {
        private Bindable<ScalingMode> scalingMode = new Bindable<ScalingMode>();
        private GameHost gameHost;
        private Size previousResolution;
        public readonly BindableBool CanDisplayBackgroundScreen = new BindableBool();

        [BackgroundDependencyLoader]
        private void load(GameHost host, KanojoWorksConfigManager configManager)
        {
            gameHost = host;
            scalingMode.BindTo(configManager.GetBindable<ScalingMode>(KanojoWorksSetting.ScalingMode));
        }

        private void updateContainerSize()
        {
            int resolutionHeight = gameHost.Window.ClientSize.Height;
            int resolutionWidth = gameHost.Window.ClientSize.Width;

            if (resolutionWidth == previousResolution.Width
                && resolutionHeight == previousResolution.Height)
                return;

            var xRatio = resolutionWidth / Size.X;
            var yRatio = resolutionHeight / Size.Y;

            switch (scalingMode.Value)
            {
                case ScalingMode.MaintainAspectRatio:
                    var ratio = Math.Min(xRatio, yRatio);

                    // Can display the background container if there's pillar/letterboxing
                    if (xRatio != yRatio)
                        CanDisplayBackgroundScreen.Value = true;
                    else
                        CanDisplayBackgroundScreen.Value = false;

                    previousResolution = new Size(resolutionWidth, resolutionHeight);
                    Schedule(() => this.ScaleTo(ratio));
                    break;

                case ScalingMode.Stretch:
                    previousResolution = new Size(resolutionWidth, resolutionHeight);
                    Schedule(() => this.ScaleTo(new osuTK.Vector2(xRatio, yRatio)));
                    break;

                case ScalingMode.NoScaling:
                    if (resolutionWidth != Size.X || resolutionHeight != Size.Y)
                        CanDisplayBackgroundScreen.Value = true;
                    else
                        CanDisplayBackgroundScreen.Value = false;
                    break;
            }
        }

        // Ensure Container size is updated every frame for smooth resizing. 
        protected override void Update()
        {
            base.Update();
            updateContainerSize();
        }
    }
}
