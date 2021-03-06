using System.ComponentModel;

namespace KanojoWorks.Configuration
{
    public enum ScalingMode
    {
        [Description("Scale content proportionally")]
        MaintainAspectRatio,

        [Description("Custom scaling")]
        Custom,

        [Description("Stretch to the window's aspect ratio")]
        Stretch,

        [Description("No scaling until minimum target resolution is hit")]
        NoScaling
    }
}
