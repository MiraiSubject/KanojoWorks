using System.Linq;
using NUnit.Framework;
using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Logging;
using KanojoWorks.Input;
using KanojoWorks.Novel.Components;
using KanojoWorks.Novel.Containers;
using osuTK;

namespace KanojoWorks.Tests.Visual
{
    [Description("Container for novel dialogue options")]
    public class TestSceneChoiceContainer : KanojoWorksManualInputManagerTestScene
    {
        private ChoiceContainer choiceContainer;
        private GlobalInputContainer globalInputContainer;

        private TestChoice choice1;
        private TestChoice choice2;
        private TestChoice choice3;

        public TestSceneChoiceContainer()
        {
        }

        [BackgroundDependencyLoader]
        private void load()
        {
            Child = globalInputContainer = new GlobalInputContainer();
        }

        [SetUp]
        public void SetUp() => Schedule(() =>
        {
            globalInputContainer.Child = choiceContainer = new ChoiceContainer
            {
                RelativeSizeAxes = Axes.Both,
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Choices = new[]
                {
                    choice1 = new TestChoice(1),
                    choice2 = new TestChoice(2),
                    choice3 = new TestChoice(3)
                }
            };

            InputManager.MoveMouseTo(Vector2.Zero);
        });

        private void showContainer() => AddStep("Show choice container", () => choiceContainer.Show());

        private void hideContainer() => AddStep("Hide choice container", () => choiceContainer.Hide());

        [Test]
        public void TestSelectWithoutSelection()
        {
            showContainer();

            AddStep("Press select", () => press(InputAction.Select));
            AddAssert("Test selected", () => !choiceContainer.Choices?.First().Selected.Value ?? true);
        }

        [Test]
        public void TestUpButtonFromInitial()
        {
            showContainer();

            AddStep("Press up", () => press(InputAction.Up));
            AddAssert("Last button is selected", () => choiceContainer.Choices?.Last().Selected.Value ?? false);
        }

        [Test]
        public void TestDownButtonFromInitial()
        {
            showContainer();

            AddStep("Press up", () => press(InputAction.Down));
            AddAssert("Last button is selected", () => choiceContainer.Choices?.First().Selected.Value ?? false);
        }

        private void press(InputAction action)
        {
            globalInputContainer.TriggerPressed(action);
            globalInputContainer.TriggerReleased(action);
        }

        private class TestChoice : Choice
        {
            public bool testSelected;
            public TestChoice(int number)
            {
                Text = $"Example Choice {number}";
                RelativeSizeAxes = Axes.X;
                Anchor = Anchor.Centre;
                Origin = Anchor.Centre;
                BackgroundColour = Colour4.Brown;
                Action = () =>
                {
                    Logger.Log($"Choice ${number} was selected");
                    testSelected = true;
                };
            }
        }
    }
}
