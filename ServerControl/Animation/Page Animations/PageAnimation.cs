namespace ServerControl
{

    /// <summary>
    /// Styles of apge animation for appearing/disappearing
    /// </summary>
    public enum PageAnimation
    {
        /// <summary>
        /// No animation to the page
        /// </summary>
        None = 0,

        /// <summary>
        /// Page slide in and fades in from the right
        /// </summary>
        SlideAndFadeInFromRight= 1,

        /// <summary>
        /// Page slides out and fades out to the left
        /// </summary>
        SlideAndFadeToLeft =2,

        /// <summary>
        /// Fade the page in
        /// </summary>
        FadeIn = 3,

        /// <summary>
        /// Fade the page out
        /// </summary>
        FadeOut = 4,

        /// <summary>
        /// Page slide in and fades in from the right
        /// </summary>
        SlideAndFadeInFromTop = 5,

        /// <summary>
        /// Page slides out and fades out to the left
        /// </summary>
        SlideAndFadeToBottom = 6,
    }
}
