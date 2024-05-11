namespace DateTimeSharper
{
    public static class DateTimeSharper
    {
        public static DateTime getCurrentDateTime(TimeZone timeZone)
        {
            return DateTime.Now;
        }
    }

    public enum TimeZone
    {
        Local,
        Utc,
        Ist,
        Est,
        Pst
    }

}
