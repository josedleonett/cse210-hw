using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction firstConstructor = new Fraction();
        Fraction secondConstructor = new Fraction(5);
        Fraction thirdConstructor = new Fraction(3, 4);
        Fraction fourthConstructor = new Fraction(1, 3);

        Console.WriteLine(firstConstructor.GetFractionString());
        Console.WriteLine(firstConstructor.GetDecimalValue());

        Console.WriteLine(secondConstructor.GetFractionString());
        Console.WriteLine(secondConstructor.GetDecimalValue());
        
        Console.WriteLine(thirdConstructor.GetFractionString());
        Console.WriteLine(thirdConstructor.GetDecimalValue());

        Console.WriteLine(fourthConstructor.GetFractionString());
        Console.WriteLine(fourthConstructor.GetDecimalValue());
    }
}