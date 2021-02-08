
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;

using KanojoWorks.Graphics.UserInterface;

namespace KanojoWorks.Tests.Visual
{
    public class KanojoWorksLoadingIndicatorTestScene : KanojoWorksTestScene
    {
        private LoadingIndicator loading;
        public KanojoWorksLoadingIndicatorTestScene()
        {
            Child = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Padding = new MarginPadding(20),
                Children = new Drawable[]
                {
                    loading = new LoadingIndicator
                    {
                        Anchor = Anchor.BottomRight,
                        Origin = Anchor.BottomRight
                    }
                }
            };

            loading.Show();
        }
    }
}
