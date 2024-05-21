using System;

namespace CW1_Task2_3var
{
    abstract class Shape
    {
        public abstract double Объём { get; }
        public abstract void PrintInfo();
    }

    class Sphere : Shape
    {
        public double Радиус { get; }

        public Sphere(double радиус)
        {
            Радиус = радиус;
        }

        public override double Объём => (4.0 / 3) * Math.PI * Math.Pow(Радиус, 3);

        public override void PrintInfo()
        {
            Console.WriteLine($"Sphere - Радиус: {Радиус}, Объём: {Объём}");
        }
    }

    class Cube : Shape
    {
        public double Сторона { get; }

        public Cube(double сторона)
        {
            Сторона = сторона;
        }

        public override double Объём => Math.Pow(Сторона, 3);

        public override void PrintInfo()
        {
            Console.WriteLine($"Cube - Сторона: {Сторона}, Объём: {Объём}");
        }
    }

    class Cylinder : Shape
    {
        public double Радиус { get; }
        public double Высота { get; }

        public Cylinder(double радиус, double высота)
        {
            Радиус = радиус;
            Высота = высота;
        }

        public override double Объём => Math.PI * Math.Pow(Радиус, 2) * Высота;

        public override void PrintInfo()
        {
            Console.WriteLine($"Cylinder - Радиус: {Радиус}, Высота: {Высота}, Объём: {Объём}");
        }
    }

    class Program
    {
        static void SortShapes(Shape[] shapes)
        {
            for (int i = 0; i < shapes.Length - 1; i++)
            {
                for (int j = i + 1; j < shapes.Length; j++)
                {
                    if (shapes[i].Объём < shapes[j].Объём)
                    {
                        Shape temp = shapes[i];
                        shapes[i] = shapes[j];
                        shapes[j] = temp;
                    }
                }
            }
        }

        static void PrintShapesTable(string title, Shape[] shapes)
        {
            Console.WriteLine(title);
            Console.WriteLine(new string('-', 40));
            foreach (var shape in shapes)
            {
                shape.PrintInfo();
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Sphere[] spheres = new Sphere[5]
            {
                new Sphere(1),
                new Sphere(2),
                new Sphere(3),
                new Sphere(4),
                new Sphere(5)
            };

            Cube[] cubes = new Cube[5]
            {
                new Cube(1),
                new Cube(2),
                new Cube(3),
                new Cube(4),
                new Cube(5)
            };

            Cylinder[] cylinders = new Cylinder[5]
            {
                new Cylinder(1, 2),
                new Cylinder(2, 3),
                new Cylinder(3, 4),
                new Cylinder(4, 5),
                new Cylinder(5, 6)
            };

            SortShapes(spheres);
            SortShapes(cubes);
            SortShapes(cylinders);

            PrintShapesTable("Сферы", spheres);
            PrintShapesTable("Кубы", cubes);
            PrintShapesTable("Цилиндры", cylinders);

            Shape[] allShapes = new Shape[15];
            spheres.CopyTo(allShapes, 0);
            cubes.CopyTo(allShapes, 5);
            cylinders.CopyTo(allShapes, 10);

            SortShapes(allShapes);
            PrintShapesTable("Все", allShapes);
        }
    }
}