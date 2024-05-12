using System;
using System.Collections.Generic;
using System.Linq;
using DateTimeSharper;
using Moq;
using Xunit;

public class TimeZoneConverterTests
{
    [Fact]
    public void ConvertTime_Should_ConvertDateTime_FromSourceToTargetTimeZone()
    {
        // Arrange
        DateTime inputTime = new DateTime(2024, 5, 12, 10, 0, 0); // 10:00 AM on 2024-05-12
        TimeZoneEnum sourceTimeZone = TimeZoneEnum.EasternStandardTime;
        TimeZoneEnum targetTimeZone = TimeZoneEnum.PacificStandardTime;

        // Mock TimeZoneInfo
        var sourceTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        var targetTimeZoneInfo = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");

        // Act
        DateTime convertedTime = TimeZoneConverter.ConvertTime(inputTime, sourceTimeZone, targetTimeZone);

        // Assert
        Assert.Equal(new DateTime(2024, 5, 12, 7, 0, 0), convertedTime); // 7:00 AM in Pacific Standard Time
    }

    [Fact]
    public void GetAllTimeZones_Should_ReturnNonEmptyList()
    {
        // Arrange
        var allTimeZones = TimeZoneInfo.GetSystemTimeZones().Select(tz => tz.Id);

        // Act
        var result = TimeZoneConverter.GetAllTimeZones();

        // Assert
        Assert.NotNull(result);
        Assert.NotEmpty(result);
        Assert.True(allTimeZones.SequenceEqual(result)); // Ensure all time zones are returned
    }
}
