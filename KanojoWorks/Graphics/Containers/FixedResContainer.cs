using System;
using System.Drawing;
using KanojoWorks.Configuration;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Platform;
using osuTK;

namespace KanojoWorks.Graphics.Containers
{
    public class FixedResContainer : Container
    {
        private Bindable<ScalingMode> scalingMode;
        private GameHost gameHost;
        private Size previousResolution;

        /// <summary>
        /// Whether a drawable can be displayed behind the Novel Content Container.
        /// This would be used in scenario's where there is a <see cref="osu.Framework.Graphics.Containers.DrawSizePreservingFillContainer"/>
        /// in the background to fill the blank space.
        /// </summary>
        public readonly BindableBool CanDisplayBackgroundDrawable = new BindableBool();

        /// <summary>
        /// Type of <see cref="osu.Framework.Graphics.Easing"/> to be applied on rescaling when
        /// <see cref="KanojoWorks.Configuration.ScalingMode"/> gets changed.
        /// </summary>
        public Easing RescaleEasing = Easing.OutQuart;

        /// <summary>
        /// The duration of the rescale animation when
        /// <see cref="KanojoWorks.Configuration.ScalingMode"/> gets changed.
        /// </summary>
        public double RescaleTransformDuration = 300;

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

            if (resolutionWidth == previousResolution.Width && resolutionHeight == previousResolution.Height)
            {
                if (!scalingModeChanged)
                    return;
            }

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
                        Schedule(() => this.ScaleTo(new Vector2(xRatio, yRatio), RescaleTransformDuration, RescaleEasing));
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
                        Schedule(() => this.ScaleTo(1, RescaleTransformDuration, RescaleEasing));
                    else
                        Schedule(() => this.ScaleTo(1));
                    break;
            }
        }

        private void rescaleMaintain(float xRatio, float yRatio, bool scalingModeChanged)
        {
            var ratio = Math.Min(xRatio, yRatio);

            // Can display the background container if there's pillar/letterboxing
            CanDisplayBackgroundDrawable.Value = xRatio != yRatio;

            if (scalingModeChanged)
                Schedule(() => this.ScaleTo(ratio, RescaleTransformDuration, RescaleEasing));
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
