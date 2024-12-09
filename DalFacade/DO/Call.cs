namespace DO;

public record Call
(
    /// <summary>
    /// Volunteer attributes
    /// </summary>
    int Id,
    string Address,
    double Latitude,
    double Longitude,
    DateTime OpenCallTime,
    string? DescribeCall = null,
    DateTime? EndCallTime = null,
    TypeCall TypeCall = TypeCall.FoodPreparation
)
{
    /// <summary>
    /// Default constructor
    /// </summary>
    public Call() : this(0, "", 0, 0, DateTime.MinValue, null, null, TypeCall.FoodPreparation) { }
}
