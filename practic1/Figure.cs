// Figure.cs
using System;

namespace AnimalsProgram;

public abstract class Figure
{
    protected double _square;
    public double Square => _square;

    protected Figure(double square) => _square = square >= 0 ? square : 0;
}

public class Circle : Figure
{
    public Circle(double radius) : base(Math.PI * radius * radius) { }
}

public class Rectangle : Figure
{
    public Rectangle(double width, double height) : base(width * height) { }
}

public class Triangle : Figure
{
    public Triangle(double baseLength, double height) : base(0.5 * baseLength * height) { }
}