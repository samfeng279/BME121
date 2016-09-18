using System;

static class Program
{
    static void Main()
    {
        //establishing variables
		string gender;
		double age;
		double weight;
		double heartRate;
		double time;
		double calBurned;
		
        //title of program
		Console.WriteLine();
        Console.WriteLine("Exercise calories-expended estimator");
        
        //determines if user is female or male 
		Console.Write("Enter your gender [male/female]: ");
        gender = Console.ReadLine();
		
		//input values from user
		Console.Write("Enter your age in years: ");
		age = double.Parse(Console.ReadLine());
		Console.Write("Enter your weight in pounds: ");
		weight = double.Parse(Console.ReadLine());
		Console.Write("Enter your average heart rate (in beats per minute): ");
		heartRate = double.Parse(Console.ReadLine());
		Console.Write("Enter your exercise time (in minutes): ");
		time = double.Parse(Console.ReadLine());
        
        if(gender == "female")
        {
			//calculations for females
			calBurned = (age * 0.074) - (weight * 0.05741) + (heartRate * 0.4472) - 20.4022;
			calBurned = calBurned * time / 4.184;
			
			//calories burned during exercise for females
			Console.Write("Your estimated calories burned during exercise: {0}", calBurned);
			
			
        }
        else if(gender == "male")
        {
			//calculations for males
			calBurned = (age * 0.2017) - (weight * 0.09036) + (heartRate * 0.6309) - 55.0969;
			calBurned = calBurned * time / 4.184;
			
			//calories burned during exercise for females
			Console.Write("Your estimated calories burned during exercise: {0}", calBurned);
			
        }
        else
        {
            // User entered an incorrect gender.
            Console.WriteLine( "Gender must be either male or female" );
            return;
        }
    }
}