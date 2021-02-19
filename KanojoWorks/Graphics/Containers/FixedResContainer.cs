using System;
using System.Drawing;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Platform;
using KanojoWorks.Configuration;
using osuTK;

namespace KanojoWorks.Graphics.Containers
{
    public class FixedResContainer : Container
    {
        private Bindable<ScalingMode> scalingMode;
        private GameHost gameHost;
        private Size previousResolution;
        public readonly BindableBool CanDisplayBackgroundDrawable = new BindableBool();
        public Easing scaleEasing = Easing.OutQuart;
        public double scaleDuration = 300;

        [BackgroundDependencyLoader]
        private void load(GameHost host, KanojoWorksConfigManager configManager)
        {
            gameHost = host;
            scalingMode = configManager.GetBindable<ScalingMode>(KanojoWorksSetting.ScalingMode);
            scalingMode.ValueChanged += _ => updateContainerSize(true);
        }

        private void updateContainerSize(bool scalingModeChanged = false)
        {
            if (gameHost.Window == null)
                return;

            int resolutionHeight = gameHost.Window.ClientSize.Height;
            int resolutionWidth = gameHost.Window.ClientSize.Width;

            if ((resolutionWidth == previousResolution.Width && resolutionHeight == previousResolution.Height))
                if (!scalingModeChanged)
                    return;

            var xRatio = resolutionWidth / Size.X;
            var yRatio = resolutionHeight / Size.Y;

            switch (scalingMode.Value)
            {
                case ScalingMode.MaintainAspectRatio:
                    previousResolution = new Size(resolutionWidth, resolutionHeight);
                    rescaleMaintain(xRatio, yRatio, scalingModeChanged);
                    break;

                case ScalingMode.Stretch:
                    previousResolution = new Size(resolutionWidth, resolutionHeight);

                    if (scalingModeChanged)
                        Schedule(() => this.ScaleTo(new Vector2(xRatio, yRatio), scaleDuration, scaleEasing));
                    else
                        Schedule(() => this.ScaleTo(new Vector2(xRatio, yRatio)));
                    break;

                case ScalingMode.NoScaling:
                    previousResolution = new Size(resolutionWidth, resolutionHeight);

                    if (resolutionWidth < Size.X || resolutionHeight < Size.Y)
                    {
                        rescaleMaintain(xRatio, yRatio, scalingModeChanged);
                        return;
                    }
                        
                    if (resolutionWidth != Size.X || resolutionHeight != Size.Y)
                        CanDisplayBackgroundDrawable.Value = true;
                    else
                        CanDisplayBackgroundDrawable.Value = false;

                    if (scalingModeChanged)
                        Schedule(() => this.ScaleTo(1, scaleDuration, scaleEasing));
                    else
                        Schedule(() => this.ScaleTo(1));
                    break;
            }
        }

        private void rescaleMaintain(float xRatio, float yRatio, bool scalingModeChanged)
        {
            var ratio = Math.Min(xRatio, yRatio);

            // Can display the background container if there's pillar/letterboxing
            if (xRatio != yRatio)
                CanDisplayBackgroundDrawable.Value = true;
            else
                CanDisplayBackgroundDrawable.Value = false;

            if (scalingModeChanged)
                Schedule(() => this.ScaleTo(ratio, scaleDuration, scaleEasing));
            else
                Schedule(() => this.ScaleTo(ratio));
        }

        // Ensure Container size is updated every frame for smooth resizing. 
        protected override void Update()
        {
            base.Update();
            updateContainerSize();
        }
    }
}
