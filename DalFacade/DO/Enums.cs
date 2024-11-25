namespace DO;

internal class Enums
{
}
public enum EndTypeAssignment 
{ 
    Treated, 
    SelfCancellation, 
    AdministratorCancellation, 
    ExpiredCancellation 
}

public enum TypeCall 
{ 
    FoodPreparation, 
    FoodDelivery 
}

public enum DistanceType
{
    AirDistance,
    WalkingDistance,
    DrivingDistance
}
public enum Role 
{ 
    Administrator, 
    Volunteer 
}
public enum MainMenu
{
    Exit,
    AssignmentSubMenu,
    CallSubMenu,
    VolunteerSubMenu,
    DataInitilization,
    DataPresentation,
    ConfigSubMenu,
    Reset,
}
public enum EntitySubMenu
{
    Exit,
    Creat,
    Read,
    ReadAll,
    UpDate,
    Delete,
    DeleteAll
}

public enum ConfigSubMenu
{
    Exit,
    AdvanceSystemClockMinute,
    AdvanceSystemClockHour,
    AdvanceSystemClockSecond,
    DisplaySystemClock,
    InsertNewValue,
    displayConfigValue,
    Reset
}
        