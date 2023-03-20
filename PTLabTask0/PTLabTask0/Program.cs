using System;
using PTLabTask0;
class Hello
{
    static void Main()
    {
        Calculator calc = new Calculator();

        double addition = calc.Add(2, 2);
        Console.WriteLine("2+2="+ addition);
    }
}