using System;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.WriteLine("Ведите первое число");
        ComplexNumber num1 = new ComplexNumber(Console.ReadLine());
        Console.WriteLine("Ведите второе число");
        ComplexNumber num2 = new ComplexNumber(Console.ReadLine());

        Console.WriteLine($"Число 1: {num1.ToString()}");
        Console.WriteLine($"Число 2: {num2.ToString()}");

        Console.WriteLine($"Сложение: {num1.Add(num2).ToString()}");
        Console.WriteLine($"Вычитание: {num1.Subtract(num2).ToString()}");
        Console.WriteLine($"Умножение: {num1.Multiply(num2).ToString()}");
        Console.WriteLine($"Деление: {num1.Divide(num2).ToString()}");
    }
}

class ComplexNumber
{
    public double Real { get; set; }
    public double Imaginary { get; set; }

    public ComplexNumber(string str)
    {
        string imaginaryPattern = @"-?\d+i";
        Match imaginaryMatch = Regex.Match(str, imaginaryPattern);
        if (imaginaryMatch.Success)
        {
            Imaginary = Convert.ToDouble(imaginaryMatch.Value.Replace("i", ""));
        }

        string realPattern = @"^-?\d+";
        Match realMatch = Regex.Match(str, realPattern);
        if (realMatch.Success)
        {
            Real = Convert.ToDouble(realMatch.Value);
        }
    }

    public ComplexNumber(double real, double imaginary)
    {
        Real = real;
        Imaginary = imaginary;
    }

    public ComplexNumber Add(ComplexNumber other)
    {
        return new ComplexNumber(Real + other.Real, Imaginary + other.Imaginary);
    }

    public ComplexNumber Subtract(ComplexNumber other)
    {
        return new ComplexNumber(Real - other.Real, Imaginary - other.Imaginary);
    }

    public ComplexNumber Multiply(ComplexNumber other)
    {
        double newReal = Real * other.Real - Imaginary * other.Imaginary;
        double newImaginary = Imaginary * other.Real + Real * other.Imaginary;
        return new ComplexNumber(newReal, newImaginary);
    }

    public ComplexNumber Divide(ComplexNumber other)
    {
        double divisor = other.Real * other.Real + other.Imaginary * other.Imaginary;
        double newReal = (Real * other.Real + Imaginary * other.Imaginary) / divisor;
        double newImaginary = (Imaginary * other.Real - Real * other.Imaginary) / divisor;
        return new ComplexNumber(newReal, newImaginary);
    }

    public  string ToString()
    {
        return $"{Real} + {Imaginary}i";
    }
}


