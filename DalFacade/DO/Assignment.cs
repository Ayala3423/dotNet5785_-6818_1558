namespace DO;

public record Assignment
{
    int Id;
    int CallId;
    int VolunteerId;
    DateTime EntryTimeAssignment;
    DateTime? EndTimeAssignment = null;
    enum? EndTypeAssignment=null;
    /// <summary>
    ///  default ctor
    /// </summary>
    public Assignment() { }
}