using System.Collections.Generic;
using KanojoWorks.Graphics.UserInterface;
using KanojoWorks.Input;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Input.Bindings;
using osuTK;

namespace KanojoWorks.Graphics.Containers
{
    public class ChoiceContainer : VisibilityContainer, IKeyBindingHandler<InputAction>
    {
        private const int TRANSITION_DURATION = 200;
        protected ControllableFillFlowContainer<KanojoWorksButton> FillFlow;
        public IEnumerable<KanojoWorksButton> Choices;

        public bool FirstIsHighlighted
        {
            get => FillFlow.FirstIsHighlighted;
            set => FillFlow.FirstIsHighlighted = value;
        }

        public bool WrapsButtons
        {
            get => FillFlow.WrapsButtons;
            set => FillFlow.WrapsButtons = value;
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Child = FillFlow = new ControllableFillFlowContainer<KanojoWorksButton>
            {
                RelativeSizeAxes = Axes.Both,
                Direction = FillDirection.Vertical,
                Spacing = new Vector2(10),
                ChildrenEnumerable = Choices
            };

            foreach (var choice in Choices)
            {
                choice.Selected.ValueChanged += selected => FillFlow.ButtonSelectionChanged(choice, selected.NewValue);
            }

            State.ValueChanged += s => FillFlow.Deselect();
        }

        protected override void PopIn() => this.FadeIn(TRANSITION_DURATION, Easing.In);
        protected override void PopOut() => this.FadeOut(TRANSITION_DURATION, Easing.In);

        public bool OnPressed(InputAction action) => FillFlow.OnPressed(action);

        public void OnReleased(InputAction action)
        {
        }
    }
}
