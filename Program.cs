
class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("podaj twoje IP");
        string myIp = Console.ReadLine();

        //wynik 
        if (Validator(myIp))
        {
            Console.WriteLine($"Twoje ip {myIp} jest poprawne");
        }
        else
        {
            Console.WriteLine($"Twoje ip {myIp} nie  jest poprawne");
        }
    }
    static bool Validator(string ipadress)
    {
        //sprawdzenie czy ip nie jest równe adresom zarezerwowanym dla masek
        if (ipadress == "0.0.0.0" || ipadress == "255.255.255.255")
        {
            return false;
        }

        //dzielimy nasz ciąg na 4 części według standardu IPV4
        var parts = ipadress.Split(".");

        if (parts.Length != 4) { return false; }

        // validacja ip v4 nie zaczyna się od 0
        foreach (var part in parts)
        {
            if (part.StartsWith("0") && part.Length > 1) { return false; }
            //sprawdzam czy występują spacje w podanym IP 
            if (part.Length != part.Trim().Length) { return false; }
            int number;
            var result = Int32.TryParse(part, out number);
            // nie pozwalamy na wejscie cyf poniżej 0 i powyżej 255
            if (!result || number > 255 || number < 0)
            {
                return false;
            }

        }

        return true;
    }
}