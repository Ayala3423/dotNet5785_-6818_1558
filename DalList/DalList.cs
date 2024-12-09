namespace Dal;
using DalApi;

// DalList class implements IDal and provides access to different entities in the DAL (Data Access Layer)
sealed public class DalList : IDal
{
    // Properties to access instances of Assignment, Call, Volunteer, and Config implementations
    public IAssignment Assignment { get; } = new AssignmentImplementation();  // Provides access to Assignment operations
    public ICall Call { get; } = new CallImplementation();                    // Provides access to Call operations
    public IVolunteer Volunteer { get; } = new VolunteerImplementation();      // Provides access to Volunteer operations
    public IConfig Config { get; } = new ConfigImplementation();              // Provides access to Config operations

    // Method to reset the database by deleting all data from the entities and resetting the configuration
    public void ResetDB()
    {
        Assignment.DeleteAll();   // Deletes all assignments from the data source
        Call.DeleteAll();         // Deletes all calls from the data source
        Volunteer.DeleteAll();    // Deletes all volunteers from the data source
        Config.Reset();           // Resets the configuration to default values
    }
}
