using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Ввод одним числом: {new Drob(2).GetFraction()}");
            Console.WriteLine($"Двумя: {new Drob(2, 3).GetFraction()}");
            Console.WriteLine($"Тремя: {new Drob(2, 3, 6).GetFraction()}");
            Console.WriteLine($"Результат деления: {(new Drob(5, 5) / new Drob(6, 4)).GetFraction()}");
            Console.WriteLine($"Результат сложения: {(new Drob(1, 2) + new Drob(1, 3)).GetFraction()}");
            Console.WriteLine($"Результат вычитания: {(new Drob(5, 5) - new Drob(6, 4)).GetFraction()}");
            Console.WriteLine($"Результат умножения: {(new Drob(5, 5) * new Drob(6, 4)).GetFraction()}");


            Drob a1 = new Drob(2, 4);

            a1.RepFanN += RepfanConsoleN;
            a1.RepFanD += RepfanConsoleD;

            Console.WriteLine($"Получение десятичной дроби: {a1.ConvertDec()}");
            Console.WriteLine($"Получение знака: {a1.GetADrSign()}");
            a1.NewNumerator(7);
            a1.NewDenominator(8);
            Console.WriteLine($"Вывод дроби: {a1.GetFraction()}");
            Console.WriteLine($"Получение числа по индексу 0: {a1[0]}");
        }
        public static void RepfanConsoleN(Drob inFrac, double int2)
        {
            Console.WriteLine($"Числитель {inFrac.GetNumerator()} будет числом {int2}");
        }
        public static void RepfanConsoleD(Drob inFrac, double int2)
        {
            Console.WriteLine($"Знаменатель {inFrac.GetDenominator()} будет числом {int2}");
        }
    }

    public class Drob
    {
        public delegate void matod(Drob tish, double int1);
        public event matod RepFanD;
        public event matod RepFanN;
        private double numerator;
        private double denominator;

        public Drob(double numerator)
        {
            this.numerator = numerator;
            this.denominator = 1;
        }
        public Drob(double numerator, double denominator)
        {
            this.numerator = numerator;
            this.denominator = denominator;
        }
        public Drob(double integer, double numerator, double denominator)
        {
            this.numerator = integer * denominator + numerator;
            this.denominator = denominator;
        }

        //1
        public double ConvertDec()
        {
            return (this.numerator / this.denominator);
        }

        //2
        public static Drob operator +(Drob x1, Drob x2)
        {
            if (x1.denominator == x2.denominator)
            {
                double cNumenator = x1.numerator + x2.numerator;
                double cDenominator = x1.denominator;
                return (new Drob(cNumenator, cDenominator));
            }
            else
            {
                Drob in3 = new Drob
                            (x1.numerator * x2.denominator,
                            x1.denominator * x2.denominator);
                Drob in4 = new Drob
                            (x2.numerator * x1.denominator,
                            x2.denominator * x1.denominator);
                return (in3 + in4);
            }
        }
        public static Drob operator -(Drob in1, Drob in2)
        {
            if (in1.denominator == in2.denominator)
            {
                double cNumenator = in1.numerator - in2.numerator;
                double cDenominator = in1.denominator;
                return (new Drob(cNumenator, cDenominator));
            }
            else
            {
                Drob in3 = new Drob
                            (in1.numerator * in2.denominator,
                            in1.denominator * in2.denominator);
                Drob in4 = new Drob
                            (in2.numerator * in1.denominator,
                            in2.denominator * in1.denominator);
                return (in3 - in4);
            }
        }
        public static Drob operator *(Drob in1, Drob in2)
        {
            double cNum = in1.numerator * in2.numerator;
            double cDen = in1.denominator * in2.denominator;
            return (new Drob(cNum, cDen));
        }
        public static Drob operator /(Drob in1, Drob in2)
        {
            double cNum = in1.numerator * in2.denominator;
            double cDen = in1.denominator * in2.numerator;
            return (new Drob(cNum, cDen));
        }

        //3
        public String GetADrSign()
        {
            if (this.numerator * this.denominator > 0)
            {
                return ("+");
            }
            else return ("-");
        }

        //4
        public void NewNumerator(double numerator)
        {
            RepFanN(this, numerator);
            this.numerator = numerator;
        }
        public void NewDenominator(double denominator)
        {
            RepFanD(this, denominator);
            this.denominator = denominator;
        }
        //5
        public double this[int index]
        {
            get { return (index == 0) ? numerator : denominator; }
        }

        public String GetFraction()
        {
            return numerator + "/" + denominator;
        }
        public double GetNumerator()
        {
            return (this.numerator);
        }
        public double GetDenominator()
        {
            return (this.denominator);
        }
    }
}
