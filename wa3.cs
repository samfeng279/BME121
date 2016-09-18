using System;

static class Program
{
	static void Main ( )
	{
		int n; 			//positive integer from 2 to 20
		int i;			//smallest positive integer 
		int b;			//base ranging from 2 to n
		int iCopy;		//copy of i
		int count; 		//number of bases that satisfy the condition
		bool found;		//does tested integer use digit b-1 in each base b from 2 to n?
		bool foundDigit;//is digit b-1 used in the base-b representation of i?
		
		//head line
		Console.WriteLine(" {0,0} {1,8}", "n", "a(n)");
		
		for( n = 2 ; n <= 20 ; n++ )
		{
			found = false;
			i = 1;
			
			while( !found )
			{							
				count = 0;
				
				for( b = 2; b <= n; b++ )				
				{
					foundDigit = false;
					
					iCopy = i;
					
					while( ! foundDigit && iCopy > 0 )
					{
						if( iCopy % b == b - 1 ) foundDigit = true;
						iCopy = iCopy / b;
												
					}//end While
					
					if(foundDigit == true)
					{
						count++;
					}//end If
							
				}//end For
				
				if(count == n-1)
				{
					found = true;
				}
				else 
				{
					i++;			
				}//end If/Else
									
			}//end While
			
			Console.WriteLine("{0,2:n0}{1,8:n0}", n, i );
		
		}//end For
	}
}