public interface ITetragon
{
    public float CountPerimeter(float a, float b, float c = 0, float d = 0);

    public float CountArea(float a, float b, float angle);
}

public class ConvexTetragon : ITetragon
{
    public float CountPerimeter(float a, float b, float c = 0, float d = 0)
    {
        return a + b + c + d;
    }

    public float CountArea(float a, float b, float angle)
    {
        return a * b / 2 * (float)Math.Sin(angle);
    }
}

public class Parallelogram : ITetragon
{
    public float CountPerimeter(float a, float b, float c = 0, float d = 0)
    {
        return 2 * (a + b);
    }

    public float CountArea(float a, float b, float angle = 0)
    {
        return a * b; //сторона на высоту
    }
}

public class Rhombus : ITetragon
{
    public float CountPerimeter(float a, float b = 0, float c = 0, float d = 0)
    {
        return 4 * a;
    }

    public float CountArea(float a, float b, float angle = 0)
    {
        return a * b / 2; //диагонали на 1/2
    }
}

public class Rectangle : ITetragon
{
    public float CountPerimeter(float a, float b, float c = 0, float d = 0)
    {
        return 2 * (a + b);
    }

    public float CountArea(float a, float b, float angle = 0)
    {
        return a * b; //сторона на сторону
    }
}

public class Square : ITetragon
{
    public float CountArea(float a, float b = 0, float angle = 0)
    {
        return (float)Math.Pow(a, 2); //сторона на сторону
    }

    public float CountPerimeter(float a, float b = 0, float c = 0, float d = 0)
    {
        return 4 * a;
    }
}

class Program
{
    static void Main()
    {
        ITetragon[] tetragons = new ITetragon[]
        {
            new ConvexTetragon(),
            new Parallelogram(),
            new Rhombus(),
            new Rectangle(),
            new Square()
        };

        foreach (var tetragon in tetragons)
        {
            float perimeter = tetragon.CountPerimeter(4, 4);
            float area = tetragon.CountArea(4, 4, (float)Math.PI / 2);

            Console.WriteLine(tetragon.GetType().Name);
            Console.WriteLine("Perimeter: " + perimeter);
            Console.WriteLine("Area: " + area);
            Console.WriteLine();
        }
    }
}