using DatabaseConsole.Data;
using DatabaseConsole.Models;
using DatabaseConsole.Models.Entity;
using static DatabaseConsole.Models.Entity.CustomerEntity;

namespace DatabaseConsole.Services;

public class MenuService
{
    public static async Task MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Välkommen till IT-Support");
            Console.WriteLine("1. Skapa ett ärende/ en kontakt");
            Console.WriteLine("2. Se alla ärende");
            Console.WriteLine("3. Se ett specifikt ärende");
            Console.WriteLine("4. Uppdatera ett ärende");
            Console.WriteLine("0. Avsluta programmet");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await CreateUserAndErrandAsync();
                    break;
                case "2":
                     GetAllErrand();
                    break;
                case "3":
                    GetSpecificErrand();
                    break;
                case "4":
                    UpdateErrand();
                    break;
                case "0":
                    Console.WriteLine("Tack för att du använde IT-Support!");
                    return;
                default:
                    Console.WriteLine("Felaktigt val. Försök igen.");
                    break;
            }

            Console.WriteLine("Tryck på en tangent för att fortsätta.");
            Console.ReadKey();
        }
    }


   
    public static async Task CreateUserAndErrandAsync()
    {
        Console.Clear();
        Errand errand = new();
        Customer customer= new();
        StatusAndComment statusAndComment = new();

        Console.WriteLine("Ange förnamn: ");
        customer.FirstName = Console.ReadLine() ?? "";

        Console.WriteLine("Ange efternamn: ");
        customer.LastName = Console.ReadLine() ?? "";

        Console.WriteLine("Ange e-postadress: ");
        customer.Email = Console.ReadLine() ?? "";

        Console.WriteLine("Ange telefonnummer: ");
        customer.PhoneNumber = Console.ReadLine() ?? "";

        Console.WriteLine("Skapa ett nytt ärende");

        Console.WriteLine("Beskriv ditt ärende");
        errand.ErrandDescription = Console.ReadLine() ?? "";

        if (customer != null && errand != null)
            await CustomerService.SaveUserAndErrandAsync(customer, errand, statusAndComment);

        Console.WriteLine("Tryck på valfri tanget för att komma vidare");
        Console.ReadLine();
        Console.Clear();
    }

    public static void GetAllErrand()
    {
        
        List<ErrandEntity> errands = (List<ErrandEntity>) ErrandService.GetAll();
        Console.Clear();


        foreach (ErrandEntity errand in errands)
        {
            Console.WriteLine($"Ärendenummer: {errand.ErrandId}");
            Console.WriteLine($"Beskrivning av ärende: {errand.ErrandDescription}");
            Console.WriteLine($"Utfärdat: {errand.TimeStamp}");
            Console.WriteLine($"Status: {errand.StatusAndComment.Status}");
            Console.WriteLine($"Kommentar: {errand.StatusAndComment.Comment}");
            Console.WriteLine($"Updaterad: {errand.StatusAndComment.UpdateTime}");
            Console.WriteLine("");
        }     
    }
    public static void GetSpecificErrand()
    {
        Console.Clear();
        CustomerEntity customer = new();
        Console.Write("Ange e-postadress: ");
        var email = Console.ReadLine();

        if (email != null)
        {
 
            ErrandEntity errand = ErrandService.GetErrandByEmail(email);

            if (errand != null)
            {
                Console.WriteLine($"Ärendenummer: {errand.ErrandId}");
                Console.WriteLine($"Beskrivning av ärende: {errand.ErrandDescription}");
                Console.WriteLine($"Utfärdat: {errand.TimeStamp}");
                Console.WriteLine($"Status: {errand.StatusAndComment.Status}");
                Console.WriteLine($"Kommentar: {errand.StatusAndComment.Comment}");
                Console.WriteLine($"Updaterad: {errand.StatusAndComment.UpdateTime}");
            }
            else
            {
                Console.WriteLine("Inget ärende hittades");
            }
        }
    }
    public static void UpdateErrand()
    {
        Console.Clear();

        Console.Write("Ange e-postadress: ");
        var email = Console.ReadLine() ?? "";

        ErrandEntity errand = ErrandService.GetErrandByEmail(email);

        Console.WriteLine($"Ärendenummer: {errand.ErrandId}");
        Console.WriteLine($"Beskrivning av ärende: {errand.ErrandDescription}");
        Console.WriteLine($"Utfärdat: {errand.TimeStamp}");
        Console.WriteLine($"Status: {errand.StatusAndComment.Status}");
        Console.WriteLine($"Kommentar: {errand.StatusAndComment.Comment}");
        Console.WriteLine($"Uppdaterad av ansvarig: {errand.StatusAndComment.UpdateTime}");
        Console.WriteLine("");

        Console.WriteLine("Lägg till/uppdatera kommentar på ärendet");

        var comment = Console.ReadLine() ?? "";

        if (comment != null)
        {
            errand.StatusAndComment.Comment = comment; 
        }

        Console.WriteLine("Uppdatera Status på ärendet. (1) Ej Påbörjad, (2) Påbörjad eller (3) Klar");
        Console.Write("Ange Status: ");

        var statusAsString = Console.ReadLine();

        if (statusAsString != null)
        {
            switch(statusAsString)
            {
                case "1": errand.StatusAndComment.Status = Status.NotStarted; break;
                case "2": errand.StatusAndComment.Status = Status.Started; break;
                case "3": errand.StatusAndComment.Status = Status.Done; break;
            }
        }
        else
        {
            Console.WriteLine("Knappvalet är inte rätt");
        }

         ErrandService.UpdateErrand(errand);
    }
}
