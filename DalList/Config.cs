namespace Dal;
internal static class Config
{
    internal const int NextCalled = 1000;
    private static int NextAssignmentId = NextCalled;
    internal static int NextAssignmentId { get => NextAssignmentId++; }
    internal TimeSpan RiskRange { get; set; }

    internal static DateTime Clock { get; set; } = DateTime.Now;
    //...

    internal static void Reset()
    {
        NextAssignmentId = NextCalled;
        //...
        Clock = DateTime.Now;
        //...
    }
}
