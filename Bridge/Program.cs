// Bridge: Implementation interface for Color
public interface IColor
{
    string GetColor();
}

// Concrete Implementation: Red Color
public class Red : IColor
{
    public string GetColor()
    {
        return "Red";
    }
}

// Concrete Implementation: Blue Color
public class Blue : IColor
{
    public string GetColor()
    {
        return "Blue";
    }
}

// Abstraction: Shape class
public abstract class Shape
{
    protected IColor color;

    public Shape(IColor color)
    {
        this.color = color;
    }

    public abstract void Draw();
}

// Refined Abstraction: Circle
public class Circle : Shape
{
    public Circle(IColor color) : base(color) { }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a {color.GetColor()} circle");
    }
}

// Refined Abstraction: Square
public class Square : Shape
{
    public Square(IColor color) : base(color) { }

    public override void Draw()
    {
        Console.WriteLine($"Drawing a {color.GetColor()} square");
    }
}

// Client code
class Program
{
    static void Main()
    {
        // Creating shapes with different colors
        Shape redCircle = new Circle(new Red());
        redCircle.Draw(); // Output: Drawing a Red circle

        Shape blueSquare = new Square(new Blue());
        blueSquare.Draw(); // Output: Drawing a Blue square

        Shape blueCircle = new Circle(new Blue());
        blueCircle.Draw(); // Output: Drawing a Blue circle
    }
}
