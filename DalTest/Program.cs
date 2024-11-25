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

        }
        public DisplayEntitySubMenu()
        {

        }
        public AddEntity( string type)
        {
            int id = GetIntFromUser("Enter Assignment Id:");
            int callId = GetIntFromUser("Enter CallId:");
            int volunteerId = GetIntFromUser("Enter VolunteerId:");
            DateTime entryTime = GetDateTimeFromUser("Enter Entry Time (yyyy-MM-dd HH:mm):");
            DateTime? endTime = GetNullableDateTimeFromUser("Enter End Time (yyyy-MM-dd HH:mm) or leave empty for null:");
            EndTypeAssignment? endType = GetNullableEnumFromUser<EndTypeAssignment>("Enter End Type Assignment (Treated, SelfCancellation, AdministratorCancellation, ExpiredCancellation) or leave empty for null:");
            Assignment newAssignment = new Assignment(id, callId, volunteerId, entryTime, endTime, endType);
            s_Assignment.Create(newAssignment);
        }
        public DisplayEntityObject()
        {

        }
        public displayConfigSubMenu()
        {

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
            try
            {

                Console.WriteLine("Enter your choice");

            }
            catch (string exception)
            {
                Console.WriteLine(exception);
            }
        }

    }
}
