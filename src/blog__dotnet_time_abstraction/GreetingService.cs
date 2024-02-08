public class GreetingService
{
    private readonly TimeProvider _timeProvider;

    public GreetingService(TimeProvider timeProvider)
    {
        _timeProvider = timeProvider;
    }

    public string GetGreetingMessage()
    {
        var now = _timeProvider.GetUtcNow();
        return now.Hour switch
        {
            >= 6 and <= 12 => "Good morning!",
            > 12 and <= 18 => "Good afternoon!",
            > 18 and <= 20 => "Good evening!",
            _ => "Good night!"
        };
    }
}