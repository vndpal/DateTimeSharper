using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DateTimeSharper
{
    public enum TimeZoneEnum
    {
        EasternStandardTime,
        PacificStandardTime,
        // Add more enum values as needed
    }

    public class TimeZoneConverter
    {
        private static Dictionary<TimeZoneEnum, string> TimeZoneIdMappings = new Dictionary<TimeZoneEnum, string>
    {
        { TimeZoneEnum.EasternStandardTime, "Eastern Standard Time" },
        { TimeZoneEnum.PacificStandardTime, "Pacific Standard Time" },
        // Add more enum-to-timezone mappings here
    };

        public static DateTime ConvertTime(DateTime dateTime, TimeZoneEnum sourceTimeZone, TimeZoneEnum targetTimeZone)
        {
            try
            {
                // Get source and target TimeZoneInfo objects based on the enum value
                TimeZoneInfo sourceTimeZoneInfo = GetTimeZoneInfo(sourceTimeZone);
                TimeZoneInfo targetTimeZoneInfo = GetTimeZoneInfo(targetTimeZone);

                // Convert time from source timezone to target timezone
                DateTime convertedTime = TimeZoneInfo.ConvertTime(dateTime, sourceTimeZoneInfo, targetTimeZoneInfo);

                return convertedTime;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return dateTime; // Return original datetime in case of any error
            }
        }

        public static TimeZoneInfo GetTimeZoneInfo(TimeZoneEnum timeZoneEnum)
        {
            if (TimeZoneIdMappings.TryGetValue(timeZoneEnum, out string timeZoneId))
            {
                return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
            }
            else
            {
                throw new ArgumentException("Unsupported timezone enum value", nameof(timeZoneEnum));
            }
        }

        public static IEnumerable<string> GetAllTimeZones()
        {
            return TimeZoneInfo.GetSystemTimeZones().Select(tz => tz.Id);
        }
    }
}
