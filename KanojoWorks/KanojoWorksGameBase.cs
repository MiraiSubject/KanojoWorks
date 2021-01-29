
using System.Collections.Generic;
using System.Drawing;
using osu.Framework;
using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.IO.Stores;
using osu.Framework.Platform;
using osu.Framework.Graphics.Shapes;
using osuTK;

namespace KanojoWorks
{
    public class KanojoWorksGameBase : Game
    {
        private Bindable<Size> windowedResolution;
        private Bindable<WindowMode> windowMode;
        private IEnumerable<Display> displays;
        private Bindable<Display> currentDisplay;
        private DependencyContainer dependencies;
        protected override Container<Drawable> Content { get; }
        protected Container<Drawable> nonScalingContent { get; private set; }

        protected override IReadOnlyDependencyContainer CreateChildDependencies(IReadOnlyDependencyContainer parent) =>
            dependencies = new DependencyContainer(base.CreateChildDependencies(parent));

        protected KanojoWorksGameBase()
        {
            base.Content.AddRange(new Drawable[]
            {
                // Non scaling content container for the visual novel in-game.
                nonScalingContent = new Container
                {
                    Size = new Vector2(1280, 720),
                },
                // Scaling content container that preserves drawsize for things like Menus, Overlays etc.
                Content = new DrawSizePreservingFillContainer
                {
                    TargetDrawSize = new Vector2(1280, 720)
                }
            });
        }

        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager frameworkConfig)
        {
            windowedResolution = frameworkConfig.GetBindable<Size>(FrameworkSetting.WindowedSize);
            windowedResolution.ValueChanged += _ => updateContainerSize();

            windowMode = frameworkConfig.GetBindable<WindowMode>(FrameworkSetting.WindowMode);
            windowMode.ValueChanged += _ => updateContainerSize();

            displays = Host.Window.Displays;
            currentDisplay = Host.Window.CurrentDisplayBindable;
        }

        private void updateContainerSize()
        {
            if (windowMode.Value == WindowMode.Windowed)
            {
                Schedule(() => nonScalingContent.ResizeTo(new Vector2(windowedResolution.Value.Width, windowedResolution.Value.Height)));
                return;
            }

            // Full screen or borderless apply the display's highest resolution. This is temporary for now to not fuck up resizing. 
            Schedule(() => nonScalingContent.ResizeTo(new Vector2(currentDisplay.Value.Bounds.Width, currentDisplay.Value.Bounds.Height)));
        }
    }
}
