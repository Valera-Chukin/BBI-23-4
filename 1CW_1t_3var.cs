using System;

namespace CW1_Task1_3Var
{
    struct Dot
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public Dot(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }

    struct Vector
    {
        public Dot Точка1 { get; }
        public Dot Точка2 { get; }

        public Vector(Dot точка1, Dot точка2)
        {
            Точка1 = точка1;
            Точка2 = точка2;
        }

        public double Length()
        {
            return Math.Sqrt(Math.Pow(Точка2.X - Точка1.X, 2) +
                             Math.Pow(Точка2.Y - Точка1.Y, 2) +
                             Math.Pow(Точка2.Z - Точка1.Z, 2));
        }

        public void PrintInfo()
        {
            Console.WriteLine($"Точка1: ({Точка1.X}, {Точка1.Y}, {Точка1.Z})");
            Console.WriteLine($"Точка2: ({Точка2.X}, {Точка2.Y}, {Точка2.Z})");
            Console.WriteLine($"Длина: {Length()}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector[] vectors = new Vector[5]
            {
                new Vector(new Dot(0, 0, 0), new Dot(1, 1, 1)),
                new Vector(new Dot(1, 2, 3), new Dot(4, 5, 6)),
                new Vector(new Dot(-1, -2, -3), new Dot(3, 2, 1)),
                new Vector(new Dot(3, 2, 1), new Dot(0, 0, 0)),
                new Vector(new Dot(5, 5, 5), new Dot(10, 10, 10))
            };

            for (int i = 0; i < vectors.Length - 1; i++)
            {
                for (int j = i + 1; j < vectors.Length; j++)
                {
                    if (vectors[i].Length() < vectors[j].Length())
                    {
                        Vector temp = vectors[i];
                        vectors[i] = vectors[j];
                        vectors[j] = temp;
                    }
                }
            }

            foreach (var vector in vectors)
            {
                vector.PrintInfo();
                Console.WriteLine();
            }
        }
    }
}