using System.Diagnostics.SymbolStore;

Booking booking = new Booking();
booking.OpretLokale("Stue 1", 44);
booking.OpretLokale("Stue 2", 40);
booking.OpretLokale("Stue 3", 49);
booking.OpretLokale("Stue 4", 33);
booking.OpretLokale("Stue 5", 12);

Console.WriteLine(booking.findLokale("Stue 3"));
Console.WriteLine(booking.findLokale("Stue 7"));
Console.WriteLine(booking.findLokale("Stue 1"));
Console.WriteLine("-------------------BOOKING af lokaler--------");
Console.WriteLine( booking.BookLokale("Stue 2"));
Console.WriteLine(booking.BookLokale("Stue 2")); 
Console.WriteLine(booking.BookLokale("Stue 2"));
Console.WriteLine("-------------------AFLYS booking--------");
Console.WriteLine( booking.AflysBooking("Stue 2"));
Console.WriteLine(booking.AflysBooking("Stue 2"));
Console.WriteLine("-------------------VisLedigeLokaler--------");
Console.WriteLine(booking.VisLedigeLokaler());
booking.BookLokale("Stue 5");
booking.BookLokale("Stue 1");
Console.WriteLine("-------------------VisLedigeLokaler--------");
Console.WriteLine(booking.VisLedigeLokaler());

class Booking
{
    private List<Lokal> lokaleList = new List<Lokal>();
    public String VisLedigeLokaler ()
    {
       string svar = "";
        int i = 0;
        while(i< lokaleList.Count)
        {
            Lokal l = lokaleList[i];
            if(l.optaget == false)
            {
                svar = svar + l.navn + Environment.NewLine;

            }
            i++;
        }
        return svar;
    }
    public String AflysBooking (string navn)
    {
        String svar = "ikke fundet";
        Lokal l = find(navn);
        if(l.optaget == true)
        {
            l.optaget = false;
            svar = "OK";
        }
        else
        {
            svar ="Lokal var allerede ikke optaget";
        }
        return svar;
    }
    private bool tjekLedighed(Lokal lokal)
    {
        bool svar = false;
     
        if (lokal.optaget == false)
        {
            svar = true;
        }
        return svar;
    }
    public bool BookLokale(string navn)
    {        
        Lokal l = find(navn);
        bool svar = tjekLedighed(l);       
        if(svar)
        {
           l.optaget = true;
        }

        return svar;
    }
    public void OpretLokale(string navn, int antal)
    {
        opret(navn,antal);
    }
    public string findLokale(string navn)
    {
        Lokal lokal = find(navn);
        if(lokal != null)
           return lokal.navn;
        return "ikke fundet";
    }
    private void opret(string navn, int antal)
    {
        Lokal l = new Lokal();
        l.navn = navn;
        l.antal = antal;
        l.optaget = false;
        lokaleList.Add(l);
    }
    private Lokal find (string navn)
    {
        Lokal svar = null;
        int i = 0;
        while(i < lokaleList.Count)
        {
            Lokal lokal = lokaleList[i];
            if(lokal.navn == navn)
            {
                svar = lokal;
            }
            i++;
        }
        return svar;
    }
}
class Lokal
{
    public string navn;
    public int antal;
    public string beskrivelse;
    public bool optaget;
}