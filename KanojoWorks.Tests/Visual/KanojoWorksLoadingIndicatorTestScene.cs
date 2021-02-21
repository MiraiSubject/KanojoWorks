using KanojoWorks.Graphics.UserInterface;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;

namespace KanojoWorks.Tests.Visual
{
    public class KanojoWorksLoadingIndicatorTestScene : KanojoWorksTestScene
    {
        public KanojoWorksLoadingIndicatorTestScene()
        {
            LoadingIndicator loading;
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
