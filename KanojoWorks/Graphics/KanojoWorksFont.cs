using osu.Framework.Graphics.Sprites;

namespace KanojoWorks.Graphics
{
    public static class KanojoWorksFont
    {
        public const float DEFAULT_FONT_SIZE = 20;

        public static FontUsage GetFont(Typeface typeface = Typeface.OpenSans, float size = DEFAULT_FONT_SIZE, FontWeight weight = FontWeight.Regular, bool italics = false, bool fixedWidth = false)
        {
            var outputSize = size;

            // Light font is 2x resolution so the size needs to be halved
            if (weight == FontWeight.Light)
                outputSize = size / 2;

            return new FontUsage(GetFamilyString(typeface), outputSize, weight.ToString(), italics, fixedWidth);
        }

        public static string GetFamilyString(Typeface typeface)
        {
            switch (typeface)
            {
                case Typeface.OpenSans:
                    return "OpenSans";
            }

            return null;
        }
    }

    public enum Typeface
    {
        OpenSans
    }

    public enum FontWeight
    {
        /// <summary>
        /// Equivalent to weight 300.
        /// </summary>
        Light = 300,

        /// <summary>
        /// Equivalent to weight 400.
        /// </summary>
        Regular = 400,

        /// <summary>
        /// Equivalent to weight 500.
        /// </summary>
        Medium = 500,

        /// <summary>
        /// Equivalent to weight 600.
        /// </summary>
        SemiBold = 600,

        /// <summary>
        /// Equivalent to weight 700.
        /// </summary>
        Bold = 700,

        /// <summary>
        /// Equivalent to weight 900.
        /// </summary>
        Black = 900
    }
}
