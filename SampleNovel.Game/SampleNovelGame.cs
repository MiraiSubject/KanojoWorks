using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Screens;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Shapes;
using osuTK;
using KanojoWorks.Screens;
using KanojoWorks.Themes.Basic;

namespace SampleNovel
{
    public class SampleNovelGame : SampleNovelGameBase
    {
        private ScreenStack screenStack;
        protected override Vector2 TargetResolution => new osuTK.Vector2(1280, 720);

        [BackgroundDependencyLoader]
        private void load()
        {
            //Child = screenStack = new ScreenStack { RelativeSizeAxes = Axes.Both };
            NovelContent.AddRange(new Drawable[]
            {
                new SpriteText
                {
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Text = "Hello World",
                    Font = new FontUsage(size: 72)
                },
                new Sprite
                {
                    Anchor = Anchor.CentreLeft,
                    Origin = Anchor.CentreLeft,
                    Size = new osuTK.Vector2(450, 600),
                    Texture = largeTextureStore.Get("example"),
                    Depth = float.MinValue,
                },
                new Box
                {
                    Colour = Colour4.DarkSlateBlue,
                    RelativeSizeAxes = Axes.Both,
                    Depth = float.MaxValue
                }
            });
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            //screenStack.Push(new EngineLoader(new BasicMainMenu()));
        }
    }
}