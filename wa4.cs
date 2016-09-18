using System;

class Cat
{
	string name;
	int age; 
	
	public Cat( string name, int age )
	{
		this.name = name;
		this.age = age;
	}
	
	public override string ToString()
	{
		// string retVal = "";
		// retVal = "Cat: " + name + ", age " + age;
		// return retVal;
		
		return ("Cat: " + name + ", age " + age);
	}
}

static class Program
{
    static void Main( )
    {
        Cat fluffy = new Cat( "Fluffy", 3 );
        Cat daisy = new Cat( "Daisy", 6 );
        
        Console.WriteLine( "{0}", fluffy );
        Console.WriteLine( "{0}", daisy );
    }
}