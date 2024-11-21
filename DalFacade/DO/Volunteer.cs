namespace DO
{
    public enum Role{ Administrator, Volunteer }
    public enum DistanceType
    {
        AirDistance,
        WalkingDistance,
        DrivingDistance
    }

    public record Volunteer
    (
        /// <summary>
        /// Volunteer attributes
        /// </summary>
        int Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string Email,
        string? Password = null,
        string? Address = null,
        double? Latitude = null,
        double? Longitude = null,
        double? Distance = null,
        bool Active = false,
        Role Role = Role.Volunteer,
        DistanceType DistanceType = DistanceType.AirDistance
    )
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Volunteer() : this(
            0,
            "",
            "",
            "",
            "",
            null,
            null,
            null,
            null,
            null,
            false,
            Role.Volunteer,
            DistanceType.AirDistance
        )
        { }

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        
    }
}
