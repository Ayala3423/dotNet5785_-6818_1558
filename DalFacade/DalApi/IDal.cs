using DalApi;

public interface IDal
{
    IAssignment Assignment { get; }
    ICall Call { get; }
    IVolunteer Volunteer { get; }
    IConfig Config { get; }
    IEnums Enums { get; }
    ICrud Crud { get; }
    void ResetDB();
}
