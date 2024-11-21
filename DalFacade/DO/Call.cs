namespace DO;
{
    public enum TypeCall { foodPreparation, foodDelivery }


public record Call
    (
        /// <summary>
        /// Volunteer attrubutes
        /// </summary>
        int Id,
        string? DescribeCall = null,
        string Address,
        double Latitude,
        double Longitude,
        TypeCall TypeCall = TypeCall.foodPreparation,
        DateTime OpenCallTime,
        DateTime? EndCalTime = null,
        /// <summary>
        ///  default ctor
        /// </summary>
    )
    {
        public Call() : this(0, null, "", 0, 0, new DateTime(), new DateTime(), null) { }
    }
}