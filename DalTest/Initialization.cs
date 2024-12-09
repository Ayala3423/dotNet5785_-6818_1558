namespace DalTest;

using DalApi;
using DO;
using System.Data;
using System;

public static class Initialization
{
    private static IDal? s_dal; //stage 2
    private static readonly Random s_rand = new();

    private static void createAssignments()
    {
        // טווח לפני ואחרי זמן הסיום
        TimeSpan rangeBefore = TimeSpan.FromHours(5); // עד 5 שעות לפני
        TimeSpan rangeAfter = TimeSpan.FromHours(3);  // עד 3 שעות אחרי

        int timesGreater = 0; // מונה למקרים ש-randomTime יהיה גדול מ-EndCallTime

        for (int i = 0; i < 50; i++)
        {
            int randomIndexCall = s_rand.Next(0, s_dal.Call.ReadAll().Count() - 15);
            int randomIndexVolunteer = s_rand.Next(0, s_dal.Volunteer.ReadAll().Count() - 5);

            int selectedIdCall = s_dal.Call.ReadAll().ElementAt(randomIndexCall).Id;
            TimeSpan timeSpan = (TimeSpan)(s_dal.Call.Read(selectedIdCall).EndCallTime - s_dal.Call.Read(selectedIdCall).OpenCallTime);
            double randomSeconds = s_rand.NextDouble() * timeSpan.TotalSeconds;

            DateTime endCallTime = (DateTime)s_dal.Call.Read(selectedIdCall).EndCallTime;
            DateTime randomTime;
            EndTypeAssignment endTypeAssignment;
            // שליטה בערך של randomTime
            if (timesGreater < 25 && i >= 30) // 20 פעמים ש-randomTime יהיה אחרי EndCallTime
            {
                double randomOffsetInSeconds = s_rand.NextDouble() * rangeAfter.TotalSeconds;
                randomTime = endCallTime.AddSeconds(randomOffsetInSeconds); // זמן אחרי EndCallTime
                timesGreater++;
                endTypeAssignment = (EndTypeAssignment)s_rand.Next(0, 4);
            }
            else // 30 פעמים ש-randomTime יהיה קטן או שווה ל-EndCallTime
            {
                double randomOffsetInSeconds = -(s_rand.NextDouble() * rangeBefore.TotalSeconds);
                randomTime = endCallTime.AddSeconds(randomOffsetInSeconds); // זמן לפני EndCallTime
                endTypeAssignment = EndTypeAssignment.ExpiredCancellation;
            }

            // יצירת אובייקט Assignment
            Assignment assignment = new Assignment(
                0,
                selectedIdCall,
                s_dal.Volunteer.ReadAll().ElementAt(randomIndexVolunteer).Id,
                s_dal.Call.Read(selectedIdCall).OpenCallTime,
                s_dal.Call.Read(selectedIdCall).OpenCallTime.AddSeconds(randomSeconds),
                //randomTime,
                endTypeAssignment
            );

            // בדיקת קיום והוספת Assignment
            Assignment? checkAssignment = s_dal.Assignment.Read(assignment.Id);
            if (checkAssignment == null)
            {
                s_dal.Assignment.Create(assignment);
            }
        }
    }

    private static void createCalls()
    {
        string[] CallAddresses = new string[]
        {
            "123 Main St, Springfield, IL 62701",
            "456 Oak Ave, Los Angeles, CA 90001",
            "789 Pine Rd, Miami, FL 33101",
            "101 Maple Dr, Chicago, IL 60601",
            "202 Birch Ln, Dallas, TX 75201",
            "303 Elm St, New York, NY 10001",
            "404 Cedar Blvd, Phoenix, AZ 85001",
            "505 Redwood Way, Austin, TX 73301",
            "606 Willow Ct, Seattle, WA 98101",
            "707 Chestnut Ave, Denver, CO 80201",
            "808 Aspen Blvd, San Francisco, CA 94101",
            "909 Fir St, Boston, MA 02101",
            "1010 Maple Ave, Portland, OR 97201",
            "1111 Pine St, San Diego, CA 92101",
            "1212 Oak Dr, Salt Lake City, UT 84101",
            "1313 Cedar St, Detroit, MI 48201",
            "1414 Birch Ave, Atlanta, GA 30301",
            "1515 Elm Rd, Houston, TX 77001",
            "1616 Willow Dr, Minneapolis, MN 55101",
            "1717 Chestnut Rd, Philadelphia, PA 19101",
            "1818 Redwood Ln, Orlando, FL 32801",
            "1919 Aspen St, Indianapolis, IN 46201",
            "2020 Cedar Dr, Dallas, TX 75202",
            "2121 Fir Ave, Tampa, FL 33601",
            "2222 Maple Ct, Nashville, TN 37201",
            "2323 Oak St, Kansas City, MO 64101",
            "2424 Pine Blvd, Charlotte, NC 28201",
            "2525 Chestnut Ln, St. Louis, MO 63101",
            "2626 Birch Rd, New Orleans, LA 70112",
            "2727 Elm Blvd, San Antonio, TX 78201",
            "2828 Cedar Ave, Raleigh, NC 27601",
            "2929 Willow Rd, Cleveland, OH 44101",
            "3030 Redwood Blvd, Memphis, TN 38101",
            "3131 Fir Ct, Chicago, IL 60602",
            "3232 Pine Ln, Washington, DC 20001",
            "3333 Oak Rd, Richmond, VA 23220",
            "3434 Maple St, Miami, FL 33102",
            "3535 Birch Blvd, Houston, TX 77002",
            "3636 Elm Ct, Los Angeles, CA 90002",
            "3737 Willow St, Seattle, WA 98102",
            "3838 Redwood Ave, Phoenix, AZ 85002",
            "3939 Fir Blvd, Boston, MA 02102",
            "4040 Chestnut Rd, Denver, CO 80202",
            "4141 Aspen Dr, San Francisco, CA 94102",
            "4242 Cedar Ct, Portland, OR 97202",
            "4343 Birch Rd, Salt Lake City, UT 84102",
            "4444 Elm Ln, Atlanta, GA 30302",
            "4545 Willow Blvd, New York, NY 10002",
            "4646 Redwood St, St. Louis, MO 63102",
            "4747 Fir Rd, Orlando, FL 32802",
            "4848 Chestnut Ln, Tampa, FL 33602",
            "4949 Pine Ave, Charlotte, NC 28202"
        };
        double[] Latitudes = new double[]
        {
            39.7817, 34.0522, 25.7617, 41.8781, 32.7767,
            40.7128, 33.4484, 30.2672, 47.6062, 39.7392,
            37.7749, 42.3601, 45.5051, 32.7157, 40.7608,
            42.3314, 33.7490, 29.7604, 44.9778, 39.9526,
            28.5383, 39.7684, 32.7767, 27.9506, 36.1627,
            39.0997, 35.2271, 38.6270, 29.9511, 29.4241,
            35.7796, 41.4993, 35.1495, 41.8781, 38.9072,
            37.5407, 25.7617, 29.7604, 34.0522, 47.6062,
            33.4484, 42.3601, 39.7392, 37.7749, 45.5051,
            40.7608, 33.7490, 40.7128, 38.6270, 28.5383,
            27.9506, 35.2271
        };
        double[] Longitudes = new double[]
        {
            -89.6501, -118.2437, -80.1918, -87.6298, -96.7970,
            -74.0060, -112.0740, -97.7431, -122.3321, -104.9903,
            -122.4194, -71.0589, -122.6750, -117.1611, -111.8910,
            -83.0458, -84.3880, -95.3698, -93.2650, -75.1652,
            -81.3792, -86.1581, -96.7970, -82.4572, -86.7816,
            -94.5786, -80.8431, -90.1994, -90.0715, -98.4936,
            -78.6382, -81.6944, -90.0489, -87.6298, -77.0369,
            -77.4360, -80.1918, -95.3698, -118.2437, -122.3321,
            -112.0740, -71.0589, -104.9903, -122.4194, -122.6750,
            -111.8910, -84.3880, -74.0060, -90.1994, -81.3792,
            -82.4572, -80.8431
        };
        string[] foodPreparation = {
            "הכנת בייגלים למשפחה נצרכת",
            "הכנת מרק חם למקלט לנזקקים",
            "אפיית עוגיות לילדים חולים",
            "בישול מנות חמות לחיילים בודדים",
            "הכנת פסטה למרכז קהילתי",
            "בישול תבשילים לשבת למשפחות רווחה",
            "הכנת סלטים לכנס התנדבות",
            "אריזת מנות אוכל לתושבים ותיקים",
            "הכנת כריכים לתלמידים במצוקה",
            "בישול מנות חג למשפחות במצוקה",
            "הכנת מאפים לחג לילדים יתומים",
            "הכנת קציצות לאנשים עם מוגבלות",
            "הכנת לחמים ליום התנדבות קהילתי",
            "בישול ממולאים לאנשים בודדים",
            "הכנת פשטידות לחג עבור משפחות נזקקות",
            "אריזת מזון מוכן לבית אבות",
            "בישול מרקים לחורף למשפחות בסיכון",
            "הכנת קינוחים ליום הולדת במקלט נשים",
            "אפיית פיתות לפעילות קהילתית",
            "בישול ירקות ממולאים לקשישים",
            "אריזת סלטים לסטודנטים מעוטי יכולת",
            "בישול אורז עם ירקות לחיילים בודדים",
            "הכנת עוגות לתושבים ותיקים",
            "הכנת טוסטים לכנס התרמה",
            "הכנת רטבים לפסטה למרכז נוער"
        };
        string[] foodDelivery = {
            "העברת עוף לשבת למשפחה נזקקת",
            "חלוקת ירקות טריים לשוק הקהילתי",
            "מסירת לחם חם לבית יתומים",
            "חלוקת פירות למרכז חסד",
            "העברת מנות חמות למשפחה קשת יום",
            "מסירת קופסאות שימורים למשפחות",
            "העברת חבילות מזון לקשישים",
            "מסירת סלי מזון לנשים חד הוריות",
            "חלוקת ארוחות בוקר לבתי ספר",
            "העברת מזון כשר לחג למשפחות נזקקות",
            "מסירת תרומות אוכל למרכז חסד",
            "חלוקת פירות יבשים ליום המשפחה",
            "העברת קציצות ומנות חמות למשפחה בסיכון",
            "מסירת ארוחות מוכנות לשבת",
            "חלוקת מאפים לחיילים בודדים",
            "העברת שימורים לקהילות נזקקות",
            "מסירת חלות שבת למשפחה רווחתית",
            "חלוקת לחמים טריים לבית אבות",
            "העברת חבילות מזון למרכז קליטה",
            "מסירת פשטידות לחג לנזקקים",
            "העברת ירקות למשפחה מעוטת יכולת",
            "חלוקת עוגות יומולדת לילדים חולים",
            "מסירת ארוחות מוכנות לחיילים בודדים",
            "העברת שוקולדים ופרחים לנשים במקלטים",
            "חלוקת מזון חם בשוק הקהילתי"
        };

        Random random = new Random();

        for (int i = 0; i < 25; i++)
        {
            Call call = new Call(0, CallAddresses[i], Latitudes[i], Longitudes[i], s_dal.Config.Clock.AddHours(-(random.Next(1, 5))), foodPreparation[i], s_dal.Config.Clock.AddHours(random.Next(1, 5)), TypeCall.FoodPreparation);
            Call? checkCall = s_dal.Call?.Read(call.Id);
            if (checkCall != null)
            {
                s_dal.Call?.Create(checkCall);
            }
        }

        for (int i = 0; i < 25; i++)
        {
            Call call = new Call(0, CallAddresses[i], Latitudes[25 + i], Longitudes[25 + i], s_dal.Config.Clock.AddHours(-(random.Next(1, 5))), foodDelivery[i], s_dal.Config.Clock.AddHours(random.Next(1, 5)), TypeCall.FoodDelivery);
            Call? checkCall = s_dal.Call?.Read(call.Id);
            if (checkCall != null)
            {
                s_dal.Call?.Create(checkCall);
            }
        }

    }

    private static void createVolunteers()
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

        Volunteer administarator = new Volunteer(random.Next(200000000, 400000001), "ayala", "meruven", "0501234567", "ayalaMeruven@gmail.com", "A1b!c89&eF3g", "רחוב דיזנגוף 10, תל אביב", null, null, null, true, Role.Administrator, DistanceType.AirDistance);
        Volunteer? checkAdministarator = s_dal.Volunteer.Read(administarator.Id);
        if (checkAdministarator != null)
        {
            s_dal.Volunteer.Create(checkAdministarator);
        }

        for (int i = 0; i < 20; i++)
        {
            Volunteer volunteer = new Volunteer(
                random.Next(200000000, 400000001),
                firstNames[i],
                lastNames[i],
                phoneNumbers[i],
                emails[i],
                passwords[i],
                addresses[i],
                null,
                null,
                random.Next(1, 101),
                true,
                Role.Volunteer,
                DistanceType.AirDistance);
            Volunteer? checkVolunteer = s_dal.Volunteer.Read(volunteer.Id);
            if (checkVolunteer != null)
            {
                s_dal.Volunteer.Create(volunteer);
            }
        }
    }

    //public static void Do(IStudent? dalStudent, ICourse? dalCourse, ILink? dalStudentInCourse, IConfig? dalConfig) // stage 1
    public static void Do(IDal dal) //stage 2
    {
        s_dal = dal ?? throw new NullReferenceException("DAL object can not be null!"); // stage 2

        Console.WriteLine("Reset Configuration values and List values...");
        s_dal.ResetDB(); //stage 2

        createAssignments();
        createCalls();
        createVolunteers();
    }

}
