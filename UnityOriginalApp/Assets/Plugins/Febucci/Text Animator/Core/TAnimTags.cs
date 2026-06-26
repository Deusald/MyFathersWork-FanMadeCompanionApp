namespace Febucci.UI
{
    /// <summary>
    /// Contains all the tags for built-in effects.<br/>
    /// - Manual: <seealso href="https://www.textanimator.febucci.com/docs/built-in-effects-list/">Built-in Effects</seealso>
    /// </summary>
    public static class TAnimTags
    {

        #region Tags
        public const string bh_Shake = "shake";
        public const string bh_Rot = "rot";
        public const string bh_Wiggle = "wiggle";
        public const string bh_Wave = "wave";
        public const string bh_Swing = "swing";
        public const string bh_Incr = "incr";
        public const string bh_Slide = "slide";
        public const string bh_Bounce = "bounce";
        public const string bh_Fade = "fade";
        public const string bh_Rainb = "rainb";
        public const string bh_Dangle = "dangle";
        public const string bh_Pendulum = "pend";

        public const string ap_Size = "size";
        public const string ap_Fade = "fade";
        public const string ap_Offset = "offset";
        public const string ap_VertExp = "vertexp";
        public const string ap_HoriExp = "horiexp";
        public const string ap_DiagExp = "diagexp";
        public const string ap_Rot = "rot";
        #endregion

        /// <summary>
        /// Contains all default behavior effects tags
        /// </summary>
        public static readonly string[] defaultBehaviors = new string[]
        {
            bh_Shake,
            bh_Rot,
            bh_Wiggle,
            bh_Wave,
            bh_Swing,
            bh_Incr,
            bh_Slide,
            bh_Bounce,
            bh_Fade,
            bh_Rainb,
            bh_Dangle,
            bh_Pendulum
        };

        /// <summary>
        /// Contains all default appearance effects tags
        /// </summary>
        public static readonly string[] defaultAppearances = new string[]{
            ap_Size,
            ap_Fade,
            ap_Offset,
            ap_VertExp,
            ap_HoriExp,
            ap_DiagExp,
            ap_Rot,
        };


    }

}
