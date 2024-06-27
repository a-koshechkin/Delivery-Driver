using System.Collections.Generic;

public static class Constants
{
    public enum Tag
    {
        Driver,
        SpeedUp,
        SlowDown
    }

    public static readonly Dictionary<Tag, string> Tags = new()
    {
        {Tag.Driver, "Driver"},
        {Tag.SpeedUp, "SpeedUp"},
        {Tag.SlowDown, "SlowDown"}
    };
}