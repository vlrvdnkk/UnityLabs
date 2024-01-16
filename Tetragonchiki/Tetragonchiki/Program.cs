public abstract class ATetragon
{
    public virtual float CountPerimeter(float a, float b, float c = 0, float d = 0)
    {
        return a + b + c + d;
    }

    public virtual float CountArea(float a, float b, float angle)
    {
        return a * b / 2 * (float)Math.Sin(angle); //диагонали на 1/2 и на синус угла
    }
}

public class ConvexTetragon : ATetragon
{

}

public class Parallelogram : ConvexTetragon
{
    public override float CountArea(float a, float b, float angle = 0)
    {
        return a * b; //сторона на высоту
    }

    public override float CountPerimeter(float a, float b, float c = 0, float d = 0)
    {
        return 2 * (a + b);
    }
}

public class Rhombus : Parallelogram
{
    public override float CountArea(float a, float b, float angle = 0)
    {
        return a * b / 2; //диагонали на 1/2
    }

    public override float CountPerimeter(float a, float b = 0, float c = 0, float d = 0)
    {
        return 4 * a;
    }
}

public class Rectangle : Parallelogram
{
    //площадь та же, но сторона на сторону
}

public class Square : Rhombus
{
    public override float CountArea(float a, float b = 0, float angle = 0)
    {
        return (float)Math.Pow(a, 2); //сторона на сторону
    }
}

class Program
{
    static void Main()
    {
        ATetragon[] tetragons = new ATetragon[]
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