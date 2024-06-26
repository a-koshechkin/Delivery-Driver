using System.Collections.Generic;

public static class Constants
{
    public enum Tag
    {
        Player,
        SpeedUp,
        SlowDown
    }

    public static readonly Dictionary<Tag, string> Tags = new()
    {
        {Tag.Player, "Player"},
        {Tag.SpeedUp, "SpeedUp"},
        {Tag.SlowDown, "SlowDown"}
    };
}