using System;
using System.Windows.Forms;


namespace DalTest


{
    internal class Program
    {
        private static IAssignment? s_Assignment = new AssignmentImplementation();
        private static ICall? s_Call = new Calllementation();
        private static IVolunteer? s_Volunteer = new VolunteerImplementation();
        private static IConfig? s_dalConfig = new ConfigImplementation();
        public DisplayMenu()
        {
            try
            {
                Console.WriteLine("בחר פעולה מתוך התפריט:");

                // הצגת הערכים של ה-enum למשתמש
                foreach (MainMenu option in Enum.GetValues(typeof(MainMenu)))
                {
                    Console.WriteLine($"{(int)option}. {option}");
                }

                // קלט מהמשתמש
                int userChoice;
                if (int.TryParse(Console.ReadLine(), out userChoice) && Enum.IsDefined(typeof(MainMenu), userChoice))
                {
                    MainMenu selectedOption = (MainMenu)userChoice;
                    Console.WriteLine($"בחרת את האפשרות: {selectedOption}");
                    while (selectedOption)
                    {
                        switch (selectedOption)
                        {
                            case 1:
                                DisplayEntitySubMenu(s_Assignment);
                                break;
                            case 2:
                                DisplayEntitySubMenu(s_Call);
                                break;
                            case 3:
                                DisplayEntitySubMenu(s_Volunteer);
                                break;
                            case 4:
                                ResetDataBase();
                                break;
                            case 5:
                                DisplayDataBase();
                                break;
                            case 6:
                                displayConfigSubMenu();
                                break;
                            case 7:
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
            catch (string exception)
            {
                Console.WriteLine(exception);
            }
        }
        public DisplayEntitySubMenu(object type)
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
                while (selectedOption)
                {
                    try
                    {
                        switch (selectedOption)
                        {
                            case 1:
                                AddEntity();
                                break;
                            case 2:
                                Console.WriteLine("בחר פעולה מתוך התפריט:");
                                int IdNumber = Console.ReadLine();
                                type.Read(IdNumber);
                                break;
                            case 3:
                                type.ReadAll();
                                break;
                            case 4:
                                type.Update();
                                break;
                            case 5:
                                type.Delete();
                                break;
                            case 6:
                                type.DeleteAll();
                                break;
                            default:
                                break;
                        }
                    }

                    catch (string exception)
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
        public AddEntity(Entities type)
        {
            switch (type){
                case 0:
                    int id = GetIntFromUser("Enter Assignment Id:");
                    int callId = GetIntFromUser("Enter CallId:");
                    int volunteerId = GetIntFromUser("Enter VolunteerId:");
                    DateTime entryTime = GetDateTimeFromUser("Enter Entry Time (yyyy-MM-dd HH:mm):");
                    DateTime? endTime = GetNullableDateTimeFromUser("Enter End Time (yyyy-MM-dd HH:mm) or leave empty for null:");
                    EndTypeAssignment? endType = GetNullableEnumFromUser<EndTypeAssignment>("Enter End Type Assignment (Treated, SelfCancellation, AdministratorCancellation, ExpiredCancellation) or leave empty for null:");
                    Assignment newAssignment = new Assignment(id, callId, volunteerId, entryTime, endTime, endType);
                    s_Assignment.Create(newAssignment);
                    break;

                case 1:
                    int id = GetIntFromUser("Enter Assignment Id:");
                    int callId = GetIntFromUser("Enter Address:");
                    int volunteerId = GetIntFromUser("Enter Latitude:");
                    DateTime entryTime = GetDateTimeFromUser("Enter Entry Time (yyyy-MM-dd HH:mm):");
                    DateTime? endTime = GetNullableDateTimeFromUser("Enter End Time (yyyy-MM-dd HH:mm) or leave empty for null:");
                    EndTypeAssignment? endType = GetNullableEnumFromUser<EndTypeAssignment>("Enter End Type Assignment (Treated, SelfCancellation, AdministratorCancellation, ExpiredCancellation) or leave empty for null:");
                    Assignment newAssignment = new Assignment(id, callId, volunteerId, entryTime, endTime, endType);
                    s_Assignment.Create(newAssignment);
                    break;

                case 2:
                    int id = GetIntFromUser("Enter Assignment Id:");
                    int callId = GetIntFromUser("Enter CallId:");
                    int volunteerId = GetIntFromUser("Enter VolunteerId:");
                    DateTime entryTime = GetDateTimeFromUser("Enter Entry Time (yyyy-MM-dd HH:mm):");
                    DateTime? endTime = GetNullableDateTimeFromUser("Enter End Time (yyyy-MM-dd HH:mm) or leave empty for null:");
                    EndTypeAssignment? endType = GetNullableEnumFromUser<EndTypeAssignment>("Enter End Type Assignment (Treated, SelfCancellation, AdministratorCancellation, ExpiredCancellation) or leave empty for null:");
                    Assignment newAssignment = new Assignment(id, callId, volunteerId, entryTime, endTime, endType);
                    s_Assignment.Create(newAssignment);
                    break;
            }
            
        }
       
        public NewConfigValue()
        {

        }
        public DisplayConfigValue()
        {

        }
        public displayConfigSubMenu()
        {
            try
            {
                Console.WriteLine("בחר פעולה מתוך התפריט:");

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
                    while (selectedOption)
                    {
                        switch (selectedOption)
                        {
                            case 1:
                                s_dalConfig.Clock.AddMinutes(1);
                                break;
                            case 2:
                                s_dalConfig.Clock.AddHours(1);
                                break;
                            case 3:
                                s_dalConfig.Clock.AddSeconds(1);
                                break;
                            case 4:
                                Console.WriteLine(s_dalConfig.Clock);
                                break;
                            case 5:
                                NewConfigValue();
                                break;
                            case 6:
                                DisplayConfigValue();
                                break;
                            case 7:
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
            catch (string exception)
            {
                Console.WriteLine(exception);
            }
        }

        public ResetDataBase()
        {
            Initialization.Do(s_Assignment, s_Call, s_Volunteer, s_dalConfig);
        }

        public DisplayDataBase()
        {
            DisplayEntity(s_Assignment.ReadAll(), "Assignment");
            DisplayEntity(s_Volunteer.ReadAll(), "Volunteer");
            DisplayEntity(s_dalConfigt.ReadAll(), "dalConfig");
        }

        public DisplayEntity(List list, string type)
        {
            foreach (type item in list)
            {
                Console.WriteLine(item);
            }
        }

        public ResetData()
        {
            s_dalConfig.Reset();
            s_dalIAssignment.DeleteAll();
            s_dalConfig.Reset();
            s_dalCall.DeleteAll();
            s_dalConfig.Reset();
            s_dalVolunteer.DeleteAll();
        }
        static int GetIntFromUser(string prompt) =>
            int.TryParse(Console.ReadLine(), out int value) ? value : 0;

        static DateTime GetDateTimeFromUser(string prompt) =>
            DateTime.TryParse(Console.ReadLine(), out DateTime value) ? value : DateTime.Now;

        static DateTime? GetNullableDateTimeFromUser(string prompt) =>
            string.IsNullOrEmpty(Console.ReadLine()) ? (DateTime?)null : DateTime.Parse(Console.ReadLine());

        static T? GetNullableEnumFromUser<T>(string prompt) where T : struct
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
