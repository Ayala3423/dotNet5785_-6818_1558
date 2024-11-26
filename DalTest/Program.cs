using DalApi;
using Dal;
using DO;
using DalList;
using System.Reflection.Metadata;
namespace DalTest
{
    internal class Program
    {
        private static IAssignment? s_Assignment = new AssignmentImplementation();
        private static ICall? s_Call = new CallImplementation();
        private static IVolunteer? s_Volunteer = new VolunteerImplementation();
        private static IConfig? s_dalConfig = new ConfigImplementation();
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
                                s_Assignment.Read(IdNumberRead);
                                break;
                            case EntitySubMenu.ReadAll:
                                s_Assignment.ReadAll();
                                break;
                            case EntitySubMenu.UpDate:
                                Console.WriteLine("הכנס מספר מזהה:");
                                string inputUpdate = Console.ReadLine();
                                int.TryParse(inputUpdate, out int IdNumberUpdate);
                                Console.WriteLine("בחר פרמטר לשינוי:");
                                string parameterToUpdate = Console.ReadLine();
                                Assignment assignment = s_Assignment.Read(IdNumberUpdate);
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
                                        DateTime ? newEndTime = GetNullableDateTimeFromUser();
                                        assignment = assignment with { EndTimeAssignment = newEndTime };
                                        break;
                                    case "EndTypeAssignment":
                                        Console.WriteLine("Enter new End Type Assignment:");
                                        EndTypeAssignment ? newEndType = GetNullableEnumFromUser<EndTypeAssignment>();
                                        assignment = assignment with { EndTypeAssignment = newEndType };
                                        break;
                                    default:
                                        Console.WriteLine("Invalid parameter name. No changes made.");
                                        break;
                                }
                                s_Assignment.Update(assignment);
                                break;
                            case EntitySubMenu.Delete:
                                Console.WriteLine("הכנס מספר מזהה:");
                                string inputDelete = Console.ReadLine();
                                int.TryParse(inputDelete, out int IdNumberDelete);
                                s_Assignment.Delete(IdNumberDelete);
                                break;
                            case EntitySubMenu.DeleteAll:
                                s_Assignment.DeleteAll();
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
            Console.WriteLine("Enter Volunteer Id:");
            int volunteerId = GetIntFromUser();
            Console.WriteLine("Enter Entry Time (yyyy-MM-dd HH:mm):");
            DateTime entryTime = GetDateTimeFromUser();
            Console.WriteLine("Enter End Time (yyyy-MM-dd HH:mm) or leave empty for null:");
            DateTime? endTime = GetNullableDateTimeFromUser();
            Console.WriteLine("Enter End Type Assignment (Treated, SelfCancellation, AdministratorCancellation, ExpiredCancellation) or leave empty for null:");
            EndTypeAssignment? endType = GetNullableEnumFromUser<EndTypeAssignment>();
            Assignment newAssignment = new Assignment(0, 0, volunteerId, entryTime, endTime, endType);
            s_Assignment.Create(newAssignment);
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
                                s_dalConfig.Clock.AddMinutes(1);
                                break;
                            case ConfigSubMenu.AdvanceSystemClockHour:
                                s_dalConfig.Clock.AddHours(1);
                                break;
                            case ConfigSubMenu.AdvanceSystemClockSecond:
                                s_dalConfig.Clock.AddSeconds(1);
                                break;
                            case ConfigSubMenu.DisplaySystemClock:
                                Console.WriteLine(s_dalConfig.Clock);
                                break;
                            case ConfigSubMenu.InsertNewValue:
                                NewConfigValue();
                                break;
                            case ConfigSubMenu.DisplayConfigValue:
                                DisplayConfigValue();
                                break;
                            case ConfigSubMenu.Reset:
                                s_dalConfig.Reset();
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
            Initialization.Do(s_Assignment, s_Call, s_Volunteer, s_dalConfig);
        }

        public static void DisplayDataBase()
        {
            DisplayEntity(s_Assignment.ReadAll(), "Assignment");
            DisplayEntity(s_Volunteer.ReadAll(), "Volunteer");
            DisplayEntity(s_Call.ReadAll(), "dalConfig");
        }

        public static void DisplayEntity<T>(List<T> list, string type)
        {
            Console.WriteLine($"Displaying entities of type: {type}");
            foreach (T item in list)
            {
                Console.WriteLine(item);
            }
        }

        public static void ResetData()
        {
            s_dalConfig.Reset();
            s_Assignment.DeleteAll();
            s_dalConfig.Reset();
            s_Call.DeleteAll();
            s_dalConfig.Reset();
            s_Volunteer.DeleteAll();
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

        static void Main(string[] args)
        {
            DisplayMenu();
        }
    }
}
