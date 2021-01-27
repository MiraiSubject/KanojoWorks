using osu.Framework.Bindables;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;

namespace KanojoWorks.Graphics.UserInterface
{
    public abstract class ControllableButton : Button
    {
        public readonly BindableBool Selected = new BindableBool();

        // From: https://github.com/ppy/osu/blob/97879c3c98bcc19012c52e86287b2b8c8f0357ab/osu.Game/Screens/Play/GameplayMenuOverlay.cs#L298
        // required to ensure keyboard navigation always starts from an extremity (unless the cursor is moved)
        protected override bool OnMouseMove(MouseMoveEvent e)
        {
            Selected.Value = true;
            return base.OnMouseMove(e);
        }

        protected override bool OnHover(HoverEvent e)
        {
            // base.OnHover(e);
            // Selected.Value = true;

            return true;
        }

        protected override void OnHoverLost(HoverLostEvent e)
        {
            base.OnHoverLost(e);
            Selected.Value = false;
        }
    }
}
