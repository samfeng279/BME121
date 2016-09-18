using System;
using System.IO;

static class Program
{
	static void Main( )
	{
		//Declare variables.
		int count = 0; 						//Number of proteins counted in the file.
		string line;						//Line being examined
		string fileName = "protein.fasta";	//File name
		
		//Open file.
		using( StreamReader sr = new StreamReader( "protein.fasta" ) )
		{
			//Each line is read and set as line.
			line = sr.ReadLine();
			
			//Read each line that has text. 
			while( line != null )
			{
				//If the line being read starts with the character ">", then add one to count. 
				if( line.StartsWith( ">" ) )
				{
					count++;
				}
				
				line = sr.ReadLine();
				
			}
			
		//Close file. 
		sr.Close( );
		
		}
		
		Console.WriteLine( "Counted {0} proteins in the file '{1}'.", count, fileName );
	}
}