namespace DO;

// Empty class, could be used to group enums or constants in the future
internal class Enums
{
}

// Enum representing possible end types for an assignment
public enum EndTypeAssignment
{
    Treated,              // Assignment has been handled
    SelfCancellation,     // Assignment was canceled by the volunteer
    AdministratorCancellation,  // Assignment was canceled by the administrator
    ExpiredCancellation   // Assignment was canceled due to expiration
}

// Enum representing different types of calls
public enum TypeCall
{
    FoodPreparation,      // Call for food preparation
    FoodDelivery          // Call for food delivery
}

// Enum representing different distance types
public enum DistanceType
{
    AirDistance,          // Direct distance (as the crow flies)
    WalkingDistance,      // Distance by walking
    DrivingDistance       // Distance by car
}

// Enum representing roles of users in the system
public enum Role
{
    Administrator,        // User is an administrator
    Volunteer             // User is a volunteer
}

// Enum representing the main menu options
public enum MainMenu
{
    Exit,                 // Exit the application
    AssignmentSubMenu,    // Access the assignment sub-menu
    CallSubMenu,          // Access the call sub-menu
    VolunteerSubMenu,     // Access the volunteer sub-menu
    DataInitilization,    // Initialize data
    DataPresentation,     // Present data
    ConfigSubMenu,        // Access the configuration sub-menu
    Reset,                // Reset the system
}

// Enum representing the possible actions in the entity sub-menu
public enum EntitySubMenu
{
    Exit,                 // Exit the entity sub-menu
    Create,               // Create a new entity
    Read,                 // Read a specific entity
    ReadAll,              // Read all entities
    UpDate,               // Update an existing entity
    Delete,               // Delete an entity
    DeleteAll             // Delete all entities
}

// Enum representing the possible actions in the config sub-menu
public enum ConfigSubMenu
{
    Exit,                         // Exit the configuration sub-menu
    AdvanceSystemClockMinute,     // Advance the system clock by one minute
    AdvanceSystemClockHour,       // Advance the system clock by one hour
    AdvanceSystemClockSecond,     // Advance the system clock by one second
    DisplaySystemClock,           // Display the current system clock value
    InsertNewValue,               // Insert a new value into the system
    DisplayConfigValue,           // Display a configuration value
    Reset                         // Reset the system configuration
}
