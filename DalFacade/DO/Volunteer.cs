namespace DO;

public record Volunteer
{
    /// <summary>
    /// Volunteer attrubutes
    /// </summary>
    int Id;
    string FirstName;
    string LastName;
    string PhoneNumber;
    string Email;
    string? Password = null;
    string? Address = null;
    double? Latitude = null;
    double? Longitude = null;
    enum Role;
    bool Active;
    double? distance = null;
    enum distanceType;
    /// <summary>
    /// default ctor
    /// </summary>
    public Volunteer() { }
}