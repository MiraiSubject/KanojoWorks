using JetBrains.Annotations;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Screens;
using KanojoWorks.Configuration;
using KanojoWorks.Screens;
using osuTK;

namespace KanojoWorks.Graphics.Containers
{
    public class ScalingContainer : Container
    {
        private Bindable<float> scaleBindable;
        private Bindable<float> sizeY;

        // The mode that the container will transform on
        private readonly ScalingMode? targetMode;
        private Bindable<ScalingMode> scalingMode;
        private readonly Container content;
        protected override Container<Drawable> Content => content;
        private readonly DrawSizePreservingFillContainer sizableContainer;

        [CanBeNull]
        private ScreenStack backgroundStack;

        public ScalingContainer(ScalingMode? targetMode = null)
        {
            this.targetMode = targetMode;
            RelativeSizeAxes = Axes.Both;

            InternalChild = sizableContainer = new AlwaysInputContainer
            {
                RelativeSizeAxes = Axes.Both,
                RelativePositionAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Child = content = new DrawSizePreservingFillContainer()
            };
        }

        [BackgroundDependencyLoader]
        private void load(KanojoWorksConfigManager config)
        {
            scalingMode = config.GetBindable<ScalingMode>(KanojoWorksSetting.ScalingMode);
            scalingMode.ValueChanged += _ => updateSize();

            scaleBindable = config.GetBindable<float>(KanojoWorksSetting.Scale);
            scaleBindable.ValueChanged += _ => updateSize();
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            sizableContainer.FinishTransforms();
        }

        private bool requiresBackgroundVisible => (scalingMode.Value == ScalingMode.MaintainAspectRatio || scalingMode.Value == ScalingMode.NoScaling) && (scaleBindable.Value != 1);

        private void updateSize()
        {
            if (targetMode == ScalingMode.NoScaling)
            {
                if (requiresBackgroundVisible)
                {
                    if (backgroundStack == null)
                    {
                        AddInternal(backgroundStack = new ScreenStack
                        {
                            Alpha = 0,
                            Depth = float.MaxValue
                        });

                        backgroundStack.Push(new SimpleBackgroundScreen());
                    }

                    backgroundStack.FadeIn(200);
                }
                else
                    backgroundStack.FadeOut(200);
            }

            sizableContainer.ScaleTo(scaleBindable.Value, 200, Easing.OutElastic);
        }

        private class AlwaysInputContainer : DrawSizePreservingFillContainer
        {
            public override bool ReceivePositionalInputAt(Vector2 screenSpacePos) => true;

            public AlwaysInputContainer()
            {
                RelativeSizeAxes = Axes.Both;
            }
        }
    }
}