Booking booking = new Booking();
booking.OpretLokale("Stue 1", 44);
booking.OpretLokale("Stue 2", 40);
booking.OpretLokale("Stue 3", 49);
booking.OpretLokale("Stue 4", 33);
booking.OpretLokale("Stue 5", 12);

Console.WriteLine(booking.findLokale("Stue 3"));
Console.WriteLine(booking.findLokale("Stue 7"));
Console.WriteLine(booking.findLokale("Stue 1"));

class Booking
{
    private List<Lokal> lokaleList = new List<Lokal>();
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