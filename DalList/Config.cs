namespace Dal;

internal static class Config
{
    internal const int startCallID = 0;
    private static int _nextCallId = startCallID;
    internal static int nextCallId { get => _nextCallId++; }
    internal const int startAssignmentID = 0;
    private static int _nextAssignmentID = startAssignmentID;
    internal static int nextAssignmentId { get => _nextAssignmentID++; }

    internal static DateTime Clock = DateTime.Now;
    internal static TimeSpan RiskRange;

    internal static void Reset()
    {
        _nextCallId = startCallID;
        _nextAssignmentID = startAssignmentID;
    }
}