using System.Collections.Generic;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using KanojoWorks.Input;
using KanojoWorks.Novel.UserInterface;
using KanojoWorks.Graphics.UserInterface.Containers;

namespace KanojoWorks.Novel.Containers
{
    public class ChoiceContainer : VisibilityContainer, IKeyBindingHandler<InputAction>
    {
        protected const int transition_duration = 200;
        protected ControllableFillFlowContainer<KanojoWorksButton> FillFlow;
        public IEnumerable<KanojoWorksButton> Choices;

        [BackgroundDependencyLoader]
        private void load()
        {
            Child = FillFlow = new ControllableFillFlowContainer<KanojoWorksButton>
            {
                RelativeSizeAxes = Axes.Both,
                Direction = FillDirection.Vertical,
                Spacing = new osuTK.Vector2(10),
                ChildrenEnumerable = Choices
            };

            foreach (var choice in Choices)
            {
                choice.Selected.ValueChanged += selected => FillFlow.buttonSelectionChanged(choice, selected.NewValue);
            }

            State.ValueChanged += s => FillFlow.Deselect();
        }

        protected override void PopIn() => this.FadeIn(transition_duration, Easing.In);
        protected override void PopOut() => this.FadeOut(transition_duration, Easing.In);

        public bool OnPressed(InputAction action) => FillFlow.OnPressed(action);

        public void OnReleased(InputAction action)
        {
        }

        private class ChoiceButton : KanojoWorksButton
        {
            // From: https://github.com/ppy/osu/blob/97879c3c98bcc19012c52e86287b2b8c8f0357ab/osu.Game/Screens/Play/GameplayMenuOverlay.cs#L298
            // required to ensure keyboard navigation always starts from an extremity (unless the cursor is moved)
            protected override bool OnHover(HoverEvent e) => true;

            protected override bool OnMouseMove(MouseMoveEvent e)
            {
                Selected.Value = true;
                return base.OnMouseMove(e);
            }
        }
    }
}
