using DalApi;

// ממשק עבור מחלקת ה-DAL (Data Access Layer), שנועד להגדיר את פעולתה של מערכת הגישה למידע
public interface IDal
{
    // מאפיין גישה (Property) שמחזיר את ה-interface של אובייקט Assignment. כל מי שמממש את ה-IDal ידרוש מימוש של IAssignment
    IAssignment Assignment { get; }

    // מאפיין גישה שמחזיר את ה-interface של אובייקט Call. כל מי שמממש את ה-IDal ידרוש מימוש של ICall
    ICall Call { get; }

    // מאפיין גישה שמחזיר את ה-interface של אובייקט Volunteer. כל מי שמממש את ה-IDal ידרוש מימוש של IVolunteer
    IVolunteer Volunteer { get; }

    // מאפיין גישה שמחזיר את ה-interface של אובייקט Config. כל מי שמממש את ה-IDal ידרוש מימוש של IConfig
    IConfig Config { get; }

    // מתודה שנועדה לאתחל את בסיס הנתונים (DB). כל מי שמממש את ה-IDal יצטרך להפעיל אותה כדי לבצע איפוס של כל הנתונים.
    void ResetDB();
}
