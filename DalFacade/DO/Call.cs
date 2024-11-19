namespace DO;

public record Call
{
    /// <summary>
    /// Volunteer attrubutes
    /// </summary>
    int Id;
    enum TypeCall;
    string? DescribeCall = null;
    string Address;
    double Latitude;
    double Longitude;
    DateTime OpenCallTime;
    DateTime? EndCalTime = null;
    /// <summary>
    ///  default ctor
    /// </summary>
    public Call() { }
}