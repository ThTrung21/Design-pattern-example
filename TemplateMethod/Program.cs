using System;

// Abstract class 
public abstract class Beverage
{
    // Template method, defines the steps for making the beverage
    public void PrepareRecipe()
    {
        BoilWater();
        Brew();
        PourInCup();
        AddCondiments();
    }

    // Common step: boiling water
    private void BoilWater()
    {
        Console.WriteLine("Boiling water");
    }

    // Common step: pouring into cup
    private void PourInCup()
    {
        Console.WriteLine("Pouring into cup");
    }

    // Abstract methods that will be implemented by subclasses
    protected abstract void Brew();
    protected abstract void AddCondiments();
}


// Concrete class for making tea
public class Tea : Beverage
{
    // Implement brewing step for tea
    protected override void Brew()
    {
        Console.WriteLine("Steeping the tea");
    }

    // Implement adding condiments for tea
    protected override void AddCondiments()
    {
        Console.WriteLine("Adding lemon");
    }
}

// Concrete class for making coffee
public class Coffee : Beverage
{
    // Implement brewing step for coffee
    protected override void Brew()
    {
        Console.WriteLine("Dripping coffee through filter");
    }

    // Implement adding condiments for coffee
    protected override void AddCondiments()
    {
        Console.WriteLine("Adding sugar and milk");
    }
}


class Program
{
    static void Main()
    {
        Beverage tea = new Tea();
        Console.WriteLine("Preparing tea:");
        tea.PrepareRecipe();  // Calls the template method

        Console.WriteLine("\nPreparing coffee:");
        Beverage coffee = new Coffee();
        coffee.PrepareRecipe();  // Calls the template method
    }
}
