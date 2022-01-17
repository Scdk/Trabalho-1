using System;
using System.Numerics;

public class main
{
    #region Change trigonometric functions to fix sin and cos 
    static double Sin(double angle)
    {
        if (angle % Math.PI == 0) return 0.0;
        return Math.Sin(angle);
    }

    static double Cos(double angle)
    {
        if ((angle+(Math.PI/2)) % Math.PI == 0) return 0.0;
        return Math.Cos(angle);
    }
    #endregion

    public static void Main(string[] args)
    {
        var q = new Qubit();
        string count = "a";
        foreach (var item in q.waveFunction())
        {
            Console.WriteLine($"{count}: {item}");
            count = "b";
        }
        q.set_bs((50*2*Math.PI) + 3/2*Math.PI, (50*2*Math.PI) + 3/2*Math.PI);
        q.set_pa(new Complex(Math.Sqrt(2)/2, 0), new Complex(Math.Sqrt(2)/2, 0));
        Console.WriteLine($"Expected: {Math.Sqrt(2)/2}, {Math.Sqrt(2)/2}");
        Console.WriteLine($"Given: {q.a}, {q.b}");
    }
}