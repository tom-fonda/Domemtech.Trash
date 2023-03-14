﻿namespace Trash
{
    public enum OSTarget
    {
        Unix,
        Windows,
        Mac,
    }

    public static class Extensions
    {
        public static string ToString(this OSTarget osTarget)
        {
            var s = osTarget switch
            {
                OSTarget.Unix => "Linux",
                OSTarget.Windows => "Windows",
                OSTarget.Mac => "MacOS",
            };
            return s;
        }

        public static OSTarget ToOSTarget(this string osTarget)
        {
            var s = osTarget switch
            {
                "Unix" => OSTarget.Unix,
                "Linux" => OSTarget.Unix,
                "Windows" => OSTarget.Windows,
                "MacOS" => OSTarget.Mac,
                "Mac" => OSTarget.Mac,
            };
            return s;
        }
    }

}
