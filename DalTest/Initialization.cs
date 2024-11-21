
namespace DalTest;

using DalApi;
using DO;
using DalList;
using System.Data;

public static class Initialization
{
    private static IAssignment? s_dalIAssignment; //stage 1
    private static ICall? s_dalCall; //stage 1
    private static IVolunteer? s_dalVolunteer; //stage 1
    private static IConfig? s_dalConfig; //stage 1
    private static readonly Random s_rand = new();

    private static void createAssignment()
    {
    }
    private static void createCall()
    {

    }
    private static void createVolunteer()
    {
        Random random = new Random();
        string[] firstNames = new string[]
        {
            "John", "Jane", "Michael", "Emily", "William",
            "Sophia", "James", "Isabella", "Liam", "Olivia",
            "Ethan", "Ava", "Mason", "Mia", "Alexander",
            "Charlotte", "Lucas", "Amelia", "Henry", "Ella"
        };
        string[] lastNames = new string[]
        {
            "Smith", "Johnson", "Brown", "Taylor", "Anderson",
            "Thomas", "Jackson", "White", "Harris", "Martin",
            "Thompson", "Garcia", "Martinez", "Robinson", "Clark",
            "Rodriguez", "Lewis", "Walker", "Young", "Allen"
        };
        string[] emails = new string[] {
          "daniel@gmail.com",
          "michal123@gmail.com",
          "avi.levi@gmail.com",
          "sara.cohen@outlook.com",
          "noam.benDavid@walla.co.il",
          "yael.mizrahi@hotmail.com",
          "david.rosenberg@example.org",
          "shira.shapira@gmail.com",
          "ron.abramovich@mail.com",
          "tal.katz@icloud.com",
          "yoni.goldman@gmail.com",
          "maya.fischer@outlook.com",
          "omer.shalom@yahoo.com",
          "hila.azoulay@hotmail.com",
          "nadav.barak@walla.co.il",
          "tamar.erez@mail.com",
          "ilan.sharon@example.com",
          "gila.zohar@icloud.com",
          "ben.tzur@gmail.com",
          "efrat.harel@yahoo.com"
        };
        string[] phoneNumbers = new string[]
         {
            "0501234567", "0522345678", "0533456789", "0544567890", "0555678901",
            "0586789012", "0509876543", "0528765432", "0537654321", "0546543210",
            "0555432109", "0584321098", "0503210987", "0522109876", "0531098765",
            "0540987654", "0559876501", "0588765402", "0507654303", "0526543204"
         };

        string[] passwords = new string[]
        {
            "A1b!cD2@eF3g",
            "Xy9$Zx8@Uv7^",
            "Qw4#Er5$Ty6%",
            "Pl2!Ok3@Ij4^",
            "Mn5$Bh6#Vg7@",
            "Tg8&Yh9*Ui1!",
            "Lo2%Ki3^Ju4@",
            "Re5#Wd6$Ft7%",
            "Zx9&Cv8*Bn7@",
            "Gh3!Jk2@Lm4$",
            "Ab7$Cd9@Ef8%",
            "Yz2#Xx4@Wu5^",
            "Pa6$Sm8@Ln7%",
            "Nt9&Jm3*Hi2!",
            "Vl4%Pk6^Mj5@",
            "Fc7$Dt8#Er9%",
            "Wx2#Qz5@Rt6$",
            "Lm8@Po9%Na7^",
            "Tj6*Ui4#Yh3&",
            "Ba5^Cb6$Dc7@"
        };
        string[] addresses = new string[]
        {
            "רחוב דיזנגוף 100, תל אביב",
            "רחוב הרצל 25, ראשון לציון",
            "רחוב בן גוריון 50, חולון",
            "רחוב חיפה 15, נתניה",
            "רחוב ירושלים 88, באר שבע",
            "רחוב הנשיא 2, פתח תקווה",
            "שדרות רוטשילד 18, תל אביב",
            "רחוב העצמאות 30, אשדוד",
            "רחוב הגפן 12, רחובות",
            "רחוב דרך הים 45, חיפה",
            "רחוב הכרמל 5, רמת גן",
            "רחוב השקד 9, כפר סבא",
            "רחוב אבן גבירול 75, תל אביב",
            "רחוב הזיתים 22, רעננה",
            "רחוב השושנים 14, גבעתיים",
            "שדרות בן צבי 20, אשקלון",
            "רחוב ויצמן 33, הרצליה",
            "רחוב עמק רפאים 10, ירושלים",
            "רחוב נעמי שמר 8, מודיעין",
            "רחוב אלנבי 60, תל אביב"
        };

        Volunteer administarator = new Volunteer(random.Next(200000000, 400000001), "ayala", "meruven", "0501234567", "ayalaMeruven@gmail.com", "A1b!c89&eF3g", "רחוב דיזנגוף 10, תל אביב", null, null, null, true, Role.Administrator, DistanceType.AirDistance)
            Volunteer? checkAdministarator = s_dalVolunteer.Read(administarator.Id);
        if (checkAdministarator != null)
        {
            s_dalVolunteer.Create(checkAdministarator);
        }

        for (int i = 0; i < 20; i++)
        {
            Volunteer volunteer = new Volunteer(random.Next(200000000, 400000001), firstNames[i], lastNames[i], phoneNumbers[i], emails[i], passwords[i], addresses[i], null, null, null, true, Role.Volunteer, DistanceType.AirDistance)
            Volunteer? checkVolunteer = s_dalVolunteer.Read(volunteer.Id);
            if(checkVolunteer != null)
            {
                s_dalVolunteer.Create(volunteer);
            }
        }
    }
}
