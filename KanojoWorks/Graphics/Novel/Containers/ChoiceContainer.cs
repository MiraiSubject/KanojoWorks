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
    }
}
