namespace DO;

public record Assignment
(
    int Id,
    int CallId,
    int VolunteerId,
    DateTime EntryTimeAssignment,
    DateTime? EndTimeAssignment = null,
    EndTypeAssignment? EndTypeAssignment = null
)
{
    // Default constructor
    public Assignment() : this(0, 0, 0, new DateTime(), null, null) { }
}
