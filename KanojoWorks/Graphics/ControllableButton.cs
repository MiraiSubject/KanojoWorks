using osu.Framework.Bindables;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Events;

namespace KanojoWorks.Graphics
{
    public abstract class ControllableButton : Button
    {
        public readonly BindableBool Selected = new BindableBool();

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
