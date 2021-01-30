using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.Sprites;

namespace KanojoWorks.Graphics.UserInterface
{
    public class LoadingIndicator : VisibilityContainer
    {
        private const float TRANSITION_DURATION = 1000;
        private Sprite kanoSprite;
        private Sprite joSprite;

        [BackgroundDependencyLoader]
        private void load(TextureStore textures)
        {
            Size = new osuTK.Vector2(50);
            Child = new Container
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Children = new Drawable[]
                {
                    kanoSprite = new Sprite
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Texture = textures.Get("load-1")
                    },
                    joSprite = new Sprite
                    {
                        RelativeSizeAxes = Axes.Both,
                        Anchor = Anchor.Centre,
                        Origin = Anchor.Centre,
                        Texture = textures.Get("load-2")
                    }
                }
            };

            kanoSprite.Hide();
            joSprite.Hide();
        }

        protected override void LoadComplete()
        {
            base.LoadComplete();
            animate();
        }

        protected override void PopIn() => this.FadeIn(TRANSITION_DURATION * 2, Easing.OutQuint);
    
        protected override void PopOut() => this.FadeOut(TRANSITION_DURATION, Easing.OutQuint);
    
        private void animate()
        {
            kanoSprite.FadeIn(TRANSITION_DURATION).Then().Delay(TRANSITION_DURATION).Then().FadeOut(TRANSITION_DURATION).Then().Delay(TRANSITION_DURATION * 3).Loop();
            joSprite.Delay(TRANSITION_DURATION * 3).Then().FadeIn(TRANSITION_DURATION).Then().Delay(TRANSITION_DURATION).Then().FadeOut(TRANSITION_DURATION).Loop();
        }
    }
}