using System;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Main Menu:");
            Console.WriteLine("1. Rectangular Tower");
            Console.WriteLine("2. Triangular Tower");
            Console.WriteLine("3. Exit");

            Console.Write("Choose an option: ");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    CalculateRectangularTower();
                    break;
                case 2:
                    CalculateTriangularTower();
                    break;
                case 3:
                    exit = true;
                    Console.WriteLine("Exiting program...");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please choose again.");
                    break;
            }

            Console.WriteLine();
        }
    }

    static void CalculateRectangularTower()
    {
        Console.Write("Enter height of the tower: ");
        int height = int.Parse(Console.ReadLine());
        Console.Write("Enter width of the tower: ");
        int width = int.Parse(Console.ReadLine());

        if (height == width)
        {
            Console.WriteLine("The tower is a square.");
            Console.WriteLine("Area: " + (height * width));
        }
        else if (Math.Abs(height - width) > 5)
        {
            Console.WriteLine("The tower is a rectangle.");
            Console.WriteLine("Area: " + (height * width));
        }
        else
        {
            Console.WriteLine("The tower is a rectangle.");
            Console.WriteLine("Perimeter: " + 2 * (height + width));
        }
    }

    static void CalculateTriangularTower()
    {
        Console.Write("Enter height of the triangle: ");
        int height = int.Parse(Console.ReadLine());
        Console.Write("Enter width of the triangle: ");
        int width = int.Parse(Console.ReadLine());

        Console.WriteLine("1. Calculate perimeter");
        Console.WriteLine("2. Print triangle");
        Console.Write("Choose an option: ");
        int option = int.Parse(Console.ReadLine());

        switch (option)
        {
            case 1:
                int perimeter = 2 * width + height;
                Console.WriteLine("Perimeter: " + perimeter);
                break;
            case 2:
                if (width % 2 == 0 || width < 2 * height)
                {
                    Console.WriteLine("Cannot print the triangle.");
                }
                else
                {
                    PrintTriangle(width);
                }
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }
    }

    static void PrintTriangle(int width)
    {
        int spaces = width / 2;
        int stars = 1;

        for (int i = 1; i <= width; i += 2)
        {
            string line = new string(' ', spaces) + new string('*', stars);
            Console.WriteLine(line);
            spaces--;
            stars += 2;
        }
    }
}
