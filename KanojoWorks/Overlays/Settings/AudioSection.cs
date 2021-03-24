using System;
using KanojoWorks.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Bindables;
using osu.Framework.Configuration;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;

namespace KanojoWorks.Overlays.Settings
{
    public class AudioSection : SettingsSection
    {
        [BackgroundDependencyLoader]
        private void load(FrameworkConfigManager config, AudioManager audio)
        {
            const int max_width = 300;
            const int spacing = 5;
            Width = max_width + spacing;
            SectionName = "AUDIO";
            Header.Add(new SpriteText
            {
                Text = "SELECT AUDIO DEVICE",
                X = 100,
                Anchor = Anchor.CentreLeft,
                Font = KanojoWorksFont.GetFont(size: 16, weight: FontWeight.Bold)
            });

            Children = new Drawable[]
            {
                new FillFlowContainer
                {
                    AutoSizeAxes = Axes.Both,
                    Direction = FillDirection.Vertical,
                    Spacing = new osuTK.Vector2(20),
                    Children = new Drawable[]
                    {
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Direction = FillDirection.Vertical,
                            Spacing = new osuTK.Vector2(25),
                            Children = new Drawable[]
                            {
                                new SettingsName
                                {
                                    Text = "Master Volume",
                                    Width = max_width
                                },
                                new Container
                                {
                                    AutoSizeAxes = Axes.Both,
                                    Child = new BasicSliderBar<double>
                                    {
                                        Anchor = Anchor.CentreLeft,
                                        Origin = Anchor.CentreLeft,
                                        X = 20,
                                        Height = 10,
                                        Width = max_width,
                                        Current = audio.Volume
                                    }
                                }
                            }
                        },
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Direction = FillDirection.Vertical,
                            Spacing = new osuTK.Vector2(25),
                            Children = new Drawable[]
                            {
                                new SettingsName
                                {
                                    Text = "Music Volume",
                                    Width = max_width
                                },
                                new Container
                                {
                                    AutoSizeAxes = Axes.Both,
                                    Child = new BasicSliderBar<double>
                                    {
                                        Anchor = Anchor.CentreLeft,
                                        Origin = Anchor.CentreLeft,
                                        X = 20,
                                        Height = 10,
                                        Width = max_width,
                                        Current = audio.VolumeTrack
                                    }
                                }
                            }
                        },
                        new FillFlowContainer
                        {
                            AutoSizeAxes = Axes.Both,
                            Direction = FillDirection.Vertical,
                            Spacing = new osuTK.Vector2(25),
                            Children = new Drawable[]
                            {
                                new SettingsName
                                {
                                    Text = "SFX Volume",
                                    Width = max_width
                                },
                                new Container
                                {
                                    AutoSizeAxes = Axes.Both,
                                    Child = new BasicSliderBar<double>
                                    {
                                        Anchor = Anchor.CentreLeft,
                                        Origin = Anchor.CentreLeft,
                                        X = 20,
                                        Height = 10,
                                        Width = max_width,
                                        Current = audio.VolumeSample
                                    }
                                }
                            }
                        }
                    }
                }

                // new SettingsName
                // {
                //     Text = "Music Volume",
                //     Width = max_width
                // },
                // new SettingsName
                // {
                //     Text = "SFX Volume",
                //     Width = max_width
                // }
            };
        }
    }
}
