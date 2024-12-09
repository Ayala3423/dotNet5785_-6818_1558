using DalApi;
using Dal;
using DO;
using System.Reflection.Metadata;
namespace DalTest
{
    internal class Program
    {
        static readonly IDal s_dal = new Dal.DalList(); //stage 2
        public static void DisplayMenu()
        {
            try
            {
                Console.WriteLine("בחר פעולה מתוך התפריט:");
                PrintMenuOptions<MainMenu>(); // הדפסת האפשרויות בתפריט הראשי

                MainMenu selectedOption = GetMenuChoice<MainMenu>("בחר פעולה:");

                while (selectedOption != MainMenu.Exit) // התנאי ללולאה
                {
                    switch (selectedOption)
                    {
                        case MainMenu.AssignmentSubMenu:
                            DisplayEntitySubMenu();
                            break;
                        case MainMenu.CallSubMenu:
                            // קוד לעבודה עם Call
                            break;
                        case MainMenu.VolunteerSubMenu:
                            // קוד לעבודה עם Volunteer
                            break;
                        case MainMenu.DataInitilization:
                            ResetDataBase();
                            break;
                        case MainMenu.DataPresentation:
                            DisplayDataBase();
                            break;
                        case MainMenu.ConfigSubMenu:
                            displayConfigSubMenu();
                            break;
                        case MainMenu.Reset:
                            ResetData();
                            break;
                        default:
                            Console.WriteLine("בחירה לא חוקית.");
                            break;
                    }

                    // מבקשים מהמשתמש לבחור שוב פעולה
                    Console.WriteLine("\nבחר פעולה נוספת או Exit לסיום:");
                    PrintMenuOptions<MainMenu>();
                    selectedOption = GetMenuChoice<MainMenu>("בחר פעולה:");
                }

                Console.WriteLine("יציאה מהתפריט...");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"שגיאה: {exception.Message}");
            }
        }

        // פונקציה להדפסת האפשרויות בתפריט
        private static void PrintMenuOptions<T>() where T : Enum
        {
            foreach (T option in Enum.GetValues(typeof(T)))
            {
                Console.WriteLine($"{(int)(object)option}. {option}");
            }
        }

        // פונקציה לקבלת בחירה מהמשתמש
        private static T GetMenuChoice<T>(string prompt) where T : Enum
        {
            T selectedOption = default; // ערך ברירת מחדל
            while (true)
            {
                Console.WriteLine(prompt);
                if (int.TryParse(Console.ReadLine(), out int userChoice) && Enum.IsDefined(typeof(T), userChoice))
                {
                    selectedOption = (T)(object)userChoice;
                    break; // יציאה מהלולאה כאשר הקלט חוקי
                }
                else
                {
                    Console.WriteLine("בחירה לא חוקית. נסה שוב.");
                }
            }
            return selectedOption;
        }

        public static void DisplayEntitySubMenu()
        {

            Console.WriteLine("בחר פעולה מתוך התפריט:");

            // הצגת הערכים של ה-enum למשתמש
            foreach (EntitySubMenu option in Enum.GetValues(typeof(EntitySubMenu)))
            {
                Console.WriteLine($"{(int)option}. {option}");
            }

            // קלט מהמשתמש
            int userChoice;
            if (int.TryParse(Console.ReadLine(), out userChoice) && Enum.IsDefined(typeof(EntitySubMenu), userChoice))
            {
                EntitySubMenu selectedOption = (EntitySubMenu)userChoice;
                Console.WriteLine($"בחרת את האפשרות: {selectedOption}");
                while (selectedOption != EntitySubMenu.Exit)
                {
                    try
                    {
                        switch (selectedOption)
                        {
                            case EntitySubMenu.Create:
                                AddEntity("Assignment");
                                break;
                            case EntitySubMenu.Read:
                                Console.WriteLine("הכנס מספר מזהה:");
                                string inputRead = Console.ReadLine();
                                int.TryParse(inputRead, out int IdNumberRead);
                                s_dal.Assignment.Read(IdNumberRead);
                                break;
                            case EntitySubMenu.ReadAll:
                                s_dal.Assignment.ReadAll();
                                break;
                            case EntitySubMenu.UpDate:
                                Console.WriteLine("הכנס מספר מזהה:");
                                string inputUpdate = Console.ReadLine();
                                int.TryParse(inputUpdate, out int IdNumberUpdate);
                                Console.WriteLine("בחר פרמטר לשינוי:");
                                string parameterToUpdate = Console.ReadLine();
                                Assignment assignment = s_dal.Assignment.Read(IdNumberUpdate);
                                switch (parameterToUpdate)
                                {
                                    case "Id":
                                        Console.WriteLine("Enter new Id:");
                                        int newId = GetIntFromUser();
                                        assignment = assignment with { Id = newId };
                                        break;
                                    case "CallId":
                                        Console.WriteLine("Enter new CallId:");
                                        int newCallId = GetIntFromUser();
                                        assignment = assignment with { CallId = newCallId };
                                        break;
                                    case "VolunteerId":
                                        Console.WriteLine("Enter new VolunteerId:");
                                        int newVolunteerId = GetIntFromUser();
                                        assignment = assignment with { VolunteerId = newVolunteerId };
                                        break;
                                    case "EntryTimeAssignment":
                                        Console.WriteLine("Enter new Entry Time (yyyy-MM-dd HH:mm):");
                                        DateTime newEntryTime = GetDateTimeFromUser();
                                        assignment = assignment with { EntryTimeAssignment = newEntryTime };
                                        break;
                                    case "EndTimeAssignment":
                                        Console.WriteLine("Enter new End Time (yyyy-MM-dd HH:mm) or leave empty:");
                                        DateTime? newEndTime = GetNullableDateTimeFromUser();
                                        assignment = assignment with { EndTimeAssignment = newEndTime };
                                        break;
                                    case "EndTypeAssignment":
                                        Console.WriteLine("Enter new End Type Assignment:");
                                        EndTypeAssignment? newEndType = GetNullableEnumFromUser<EndTypeAssignment>();
                                        assignment = assignment with { EndTypeAssignment = newEndType };
                                        break;
                                    default:
                                        Console.WriteLine("Invalid parameter name. No changes made.");
                                        break;
                                }
                                s_dal.Assignment.Update(assignment);
                                break;
                            case EntitySubMenu.Delete:
                                Console.WriteLine("הכנס מספר מזהה:");
                                string inputDelete = Console.ReadLine();
                                int.TryParse(inputDelete, out int IdNumberDelete);
                                s_dal.Assignment.Delete(IdNumberDelete);
                                break;
                            case EntitySubMenu.DeleteAll:
                                s_dal.Assignment.DeleteAll();
                                break;
                            default:
                                break;
                        }
                    }

                    catch (Exception exception)
                    {
                        Console.WriteLine(exception);
                    }

                }
            }
            else
            {
                Console.WriteLine("בחירה לא חוקית.");
            }
        }

        public static void AddEntity(string type)
        {
            switch (type)
            {
                case "Assignment":
                    Console.WriteLine("Enter Volunteer Id:");
                    int AssignmentVolunteerId = GetIntFromUser();
                    Console.WriteLine("Enter Entry Time (yyyy-MM-dd HH:mm):");
                    DateTime entryTime = GetDateTimeFromUser();
                    Console.WriteLine("Enter End Time (yyyy-MM-dd HH:mm) or leave empty for null:");
                    DateTime? endTime = GetNullableDateTimeFromUser();
                    Console.WriteLine("Enter End Type Assignment (Treated, SelfCancellation, AdministratorCancellation, ExpiredCancellation) or leave empty for null:");
                    EndTypeAssignment? endType = GetNullableEnumFromUser<EndTypeAssignment>();
                    Assignment newAssignment = new Assignment(0, 0, AssignmentVolunteerId, entryTime, endTime, endType);
                    s_dal.Assignment.Create(newAssignment);
                    break;
                case "Call":
                    Console.WriteLine("Enter Address:");
                    string callAddress = Console.ReadLine();
                    Console.WriteLine("Enter Latitude:");
                    double callLatitude = GetDoubleFromUser();
                    Console.WriteLine("Enter Longitude:");
                    double callLongitude = GetDoubleFromUser();
                    Console.WriteLine("Enter OpenCallTime:");
                    DateTime callOpenCallTime = GetDateTimeFromUser();
                    Console.WriteLine("Enter DescribeCall:");
                    string? callDescribeCall = Console.ReadLine();
                    Console.WriteLine("Enter EndCallTime:");
                    DateTime? callEndCallTime = GetNullableDateTimeFromUser();
                    Console.WriteLine("Enter TypeCall:");
                    TypeCall typeCall = GetEnumFromUser<TypeCall>();
                    Call newCall = new Call(0, callAddress, callLatitude, callLongitude, callOpenCallTime, callDescribeCall, callEndCallTime, typeCall);
                    s_dal.Call.Create(newCall);
                    break;

                case "Volunteer":
                    Console.WriteLine("Enter Volunteer Id:");
                    int volunteerId = GetIntFromUser();
                    Console.WriteLine("Enter First Name:");
                    string volunteerFirstName = Console.ReadLine();
                    Console.WriteLine("Enter Last Name:");
                    string volunteerLastName = Console.ReadLine();
                    Console.WriteLine("Enter Phone Number:");
                    string volunteerPhone = Console.ReadLine();
                    Console.WriteLine("Enter Email:");
                    string volunteerEmail = Console.ReadLine();
                    Console.WriteLine("Enter Password:");
                    string volunteerPassword = Console.ReadLine();
                    Console.WriteLine("Enter Address:");
                    string volunteerAddress = Console.ReadLine();
                    Console.WriteLine("Enter Latitude:");
                    double volunteerLatitude = GetDoubleFromUser();
                    Console.WriteLine("Enter Longitude:");
                    double volunteerLongitude = GetDoubleFromUser();
                    Console.WriteLine("Enter Distance:");
                    double volunteerDistance = GetDoubleFromUser();
                    Console.WriteLine("Enter If Active:");
                    bool volunteerActive = GetBoolFromUser();
                    Console.WriteLine("Enter Role:");
                    Role role = GetEnumFromUser<Role>();
                    Console.WriteLine("Enter DistanceType:");
                    DistanceType distanceType = GetEnumFromUser<DistanceType>();
                    Volunteer newVolunteer = new Volunteer(volunteerId,
                        volunteerFirstName,
                        volunteerLastName,
                        volunteerPhone, volunteerEmail,
                        volunteerPassword,
                        volunteerAddress, volunteerLatitude,
                        volunteerLongitude, volunteerDistance,
                        volunteerActive, role, distanceType);
                    s_dal.Volunteer.Create(newVolunteer);
                    break;
            }
        }

        public static void NewConfigValue()
        {

        }

        public static void DisplayConfigValue()
        {

        }

        public static void displayConfigSubMenu()
        {
            try
            {
                Console.WriteLine("Enter an option");

                // הצגת הערכים של ה-enum למשתמש
                foreach (ConfigSubMenu option in Enum.GetValues(typeof(ConfigSubMenu)))
                {
                    Console.WriteLine($"{(int)option}. {option}");
                }

                // קלט מהמשתמש
                int userChoice;
                if (int.TryParse(Console.ReadLine(), out userChoice) && Enum.IsDefined(typeof(ConfigSubMenu), userChoice))
                {
                    ConfigSubMenu selectedOption = (ConfigSubMenu)userChoice;
                    Console.WriteLine($"בחרת את האפשרות: {selectedOption}");
                    while (selectedOption != ConfigSubMenu.Exit)
                    {
                        switch (selectedOption)
                        {
                            case ConfigSubMenu.AdvanceSystemClockMinute:
                                s_dal.Config.Clock.AddMinutes(1);
                                break;
                            case ConfigSubMenu.AdvanceSystemClockHour:
                                s_dal.Config.Clock.AddHours(1);
                                break;
                            case ConfigSubMenu.AdvanceSystemClockSecond:
                                s_dal.Config.Clock.AddSeconds(1);
                                break;
                            case ConfigSubMenu.DisplaySystemClock:
                                Console.WriteLine(s_dal.Config.Clock);
                                break;
                            case ConfigSubMenu.InsertNewValue:
                                NewConfigValue();
                                break;
                            case ConfigSubMenu.DisplayConfigValue:
                                DisplayConfigValue();
                                break;
                            case ConfigSubMenu.Reset:
                                ResetData();
                                break;
                            default:
                                break;
                        }
                    }

                }
                else
                {
                    Console.WriteLine("בחירה לא חוקית.");
                }

            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public static void ResetDataBase()
        {
            Initialization.Do(s_dal);
        }

        public static void DisplayDataBase()
        {
            DisplayEntity(s_dal.Assignment.ReadAll(), "Assignment");
            DisplayEntity(s_dal.Volunteer.ReadAll(), "Volunteer");
            DisplayEntity(s_dal.Call.ReadAll(), "dalConfig");
        }

        public static void DisplayEntity<T>(IEnumerable<T> collection, string type)
        {
            Console.WriteLine($"Displaying entities of type: {type}");
            foreach (T item in collection)
            {
                Console.WriteLine(item);
            }
        }


        public static void ResetData()
        {
            s_dal.Config.Reset();
            s_dal.Assignment.DeleteAll();
            s_dal.Config.Reset();
            s_dal.Call.DeleteAll();
            s_dal.Config.Reset();
            s_dal.Volunteer.DeleteAll();
        }

        static int GetIntFromUser() =>
            int.TryParse(Console.ReadLine(), out int value) ? value : 0;

        static DateTime GetDateTimeFromUser() =>
            DateTime.TryParse(Console.ReadLine(), out DateTime value) ? value : DateTime.Now;

        static DateTime? GetNullableDateTimeFromUser() =>
            string.IsNullOrEmpty(Console.ReadLine()) ? (DateTime?)null : DateTime.Parse(Console.ReadLine());

        static T? GetNullableEnumFromUser<T>() where T : struct
        {
            string input = Console.ReadLine();
            return string.IsNullOrEmpty(input) ? (T?)null : Enum.TryParse(input, true, out T result) ? result : (T?)null;
        }
        static T GetEnumFromUser<T>() where T : struct, Enum
        {
            while (true)
            {
                Console.WriteLine($"Please enter a value of type {typeof(T).Name}:");
                string input = Console.ReadLine();

                if (Enum.TryParse(input, true, out T result))
                    return result;

                Console.WriteLine("Invalid input. Please try again.");
            }
        }


        static double GetDoubleFromUser() =>
            double.TryParse(Console.ReadLine(), out double value) ? value : 0;

        static bool GetBoolFromUser()
        {
            string input = Console.ReadLine();
            bool.TryParse(input, out bool result);
            return result; // מחזירים את התוצאה
        }

        static void Main(string[] args)
        {
            Initialization.Do(s_dal);
            DisplayMenu();
        }
    }
}
