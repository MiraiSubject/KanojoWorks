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
        private Bindable<ScalingMode> scalingMode = new Bindable<ScalingMode>(ScalingMode.MaintainAspectRatio);
        private GameHost gameHost;
        private Size previousResolution;

        [BackgroundDependencyLoader]
        private void load(GameHost host)
        {
            gameHost = host;
        }

        private void updateContainerSize()
        {
            int resolutionHeight = gameHost.Window.ClientSize.Height;
            int resolutionWidth = gameHost.Window.ClientSize.Width;

            if (resolutionWidth == previousResolution.Width
                && resolutionHeight == previousResolution.Height)
                return;

            switch (scalingMode.Value)
            {
                case ScalingMode.MaintainAspectRatio:
                    var ratio = Math.Min((float)resolutionWidth / Size.X, (float)resolutionHeight / Size.Y);
                    previousResolution = new Size(resolutionWidth, resolutionHeight);
                    Schedule(() => this.ScaleTo(ratio));
                    break;

                case ScalingMode.Stretch:
                    var xRatio = resolutionWidth / Size.X;
                    var yRatio = resolutionHeight / Size.Y;
                    previousResolution = new Size(resolutionWidth, resolutionHeight);
                    Schedule(() => this.ScaleTo(new osuTK.Vector2(xRatio, yRatio)));
                    break;

                case ScalingMode.NoScaling:
                default:
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
