using System.ComponentModel;

namespace KanojoWorks.Configuration
{
    public enum ScalingMode
    {
        [Description("Scale proportionally")]
        MaintainAspectRatio,
        [Description("Stretch to the monitor's aspect ratio")]
        Stretch,
        [Description("No scaling")]
        NoScaling
    }
}
