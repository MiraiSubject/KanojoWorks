using System.ComponentModel;

namespace KanojoWorks.Configuration
{
    public enum ScalingMode
    {
        [Description("Scale proportionally")]
        MaintainAspectRatio,

        [Description("Custom")]
        Custom,

        [Description("Stretch")]
        Stretch,

        [Description("None")]
        NoScaling
    }
}
