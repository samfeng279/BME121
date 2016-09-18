using System;

static class Program
{ 
	static void Main()
	{
		double x = Math.Sqrt(2);
		double y = Math.Log10(50);
		
		double angleDegrees = 15;
		double angleRadians = angleDegrees / (180 / Math.PI);
		
		double xPrime = x * Math.Cos(angleRadians) - y * Math.Sin(angleRadians);
		double yPrime = x * Math.Sin(angleRadians) + y * Math.Cos(angleRadians);
		
		Console.WriteLine("x' = " + xPrime);
		Console.WriteLine("y' = " + yPrime);
	}
}