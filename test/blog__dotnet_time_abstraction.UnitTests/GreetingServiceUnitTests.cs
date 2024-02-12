using Microsoft.Extensions.Time.Testing;

namespace test;

public class GreetingServiceUnitTests
{
    private readonly FakeTimeProvider _fakeTimeProvider;
    private readonly GreetingService _greetingService;

    public GreetingServiceUnitTests()
    {
        _fakeTimeProvider = new FakeTimeProvider();
        _greetingService = new GreetingService(_fakeTimeProvider);
    }

    [Theory]
    [MemberData(nameof(GreetingServiceUnitTestsCases))]
    public void GreetingService_ShouldReturnExpectedGreetingMessage(DateTimeOffset date, string expectedGreetingMessage)
    {
        // Arrange
        _fakeTimeProvider.SetUtcNow(date);

        // Act
        var result = _greetingService.GetGreetingMessage();

        // Assert
        Assert.Equal(expectedGreetingMessage, result);
    }

    public static readonly TheoryData<DateTimeOffset, string> GreetingServiceUnitTestsCases = new()
        {
            { new DateTimeOffset(year: DateTimeOffset.MaxValue.Year, month: 1, day: 1, hour: 6, minute: 0, second: 0, TimeSpan.Zero), "Good morning!" },
            { new DateTimeOffset(year: DateTimeOffset.MaxValue.Year, month: 1, day: 1, hour: 12, minute: 0, second: 0, TimeSpan.Zero), "Good morning!" },
            { new DateTimeOffset(year: DateTimeOffset.MaxValue.Year, month: 1, day: 1, hour: 13, minute: 0, second: 0, TimeSpan.Zero), "Good afternoon!" },
            { new DateTimeOffset(year: DateTimeOffset.MaxValue.Year, month: 1, day: 1, hour: 18, minute: 0, second: 0, TimeSpan.Zero), "Good afternoon!" },
            { new DateTimeOffset(year: DateTimeOffset.MaxValue.Year, month: 1, day: 1, hour: 19, minute: 0, second: 0, TimeSpan.Zero), "Good evening!" },
            { new DateTimeOffset(year: DateTimeOffset.MaxValue.Year, month: 1, day: 1, hour: 20, minute: 0, second: 0, TimeSpan.Zero), "Good evening!" },
            { new DateTimeOffset(year: DateTimeOffset.MaxValue.Year, month: 1, day: 1, hour: 21, minute: 0, second: 0, TimeSpan.Zero), "Good night!" },
            { new DateTimeOffset(year: DateTimeOffset.MaxValue.Year, month: 1, day: 1, hour: 5, minute: 0, second: 0, TimeSpan.Zero), "Good night!" },
        };
}
