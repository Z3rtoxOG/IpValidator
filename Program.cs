using System;

class Program
{
    static void Main(string[] args)
    {
        string MyIp;
        Console.WriteLine("podaj twoje IP");
        MyIp = Console.ReadLine();

        if (Validator(MyIp))
        {
            Console.WriteLine($"Twoje ip {MyIp} jest poprawne");
        }
        else
        {
            Console.WriteLine($"Twoje ip {MyIp} nie  jest poprawne");
        }
    }
    static bool Validator(string ipadress)
    {
        var ipParts = ipadress.Split(".");

        if (ipParts.Length != 4)
        {
            return false;
        }

        foreach (var part in ipParts)
        {
            if (part.StartsWith("0") && part.Length > 1)
            {
                return false;
            }

            if (part.Length != part.Trim().Length)
            {
                return false;
            }

            int number;
            var result = Int32.TryParse(part, out number);

            if (!result || number > 255 || number < 0)
            {
                return false;
            }
        }

        return true;
    }
}