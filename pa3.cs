// -------------------------------------------------------------------
// Biomedical Engineering Program
// Department of Systems Design Engineering
// University of Waterloo
//
// Student Name:     Samantha Feng
// Userid:           20604727
//
// Assignment:       Programming Assignment 3
// Submission Date:  November 15, 2015
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// Jeff for his help with my code during the help session. 
// -------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// Represent one protein from the Human Metabolome Database (www.hmdb.ca).
class Protein
{
    // TO DO: Fields
	private string pID;					//Protein ID
	private string pName;				//Protein name
	private string pSequence;			//Amino acid sequence of protein
    
    // Construct the protein from FASTA information.
    public Protein( string proteinHeader, string proteinSequence )
    {
        //Split the header line read from FASTA file into two sections, the protein ID and protein name
		string[ ] header = proteinHeader.Split( new char[ ] {' '}, 2 );

		pID = header[ 0 ];
		pName = header[ 1 ];
		
		
		//Format the protein sequence read from Fasta file into lines with maximum 80 characters
		StringBuilder sb = new StringBuilder();
		
		int interval = 80;		//Maximum number of characters per line, the interval at which a new line must be added
		int upperBound;			//Upper bound of index of substring
		int charsRemaining;		//Number of characters in last line of the sequence, if the last line is != to 80 characters 
		
		//If the sequence of amino acids of the protein is longer than 80 characters, divide the sequence into lines of 80 characters. The last line of the sequence, however, may be less than 80 characters. 
		if( proteinSequence.Length >= 80 )
		{
			for( int i = 0; i <= proteinSequence.Length; i += interval )
			{
				if( i < proteinSequence.Length )
				{
					charsRemaining = proteinSequence.Length - i;
		
					if ( charsRemaining <= interval )
					{
						upperBound = charsRemaining;
						sb.Append( proteinSequence.Substring( i, upperBound ) );
					}
					else
					{
						upperBound = interval;
						sb.Append( proteinSequence.Substring( i, upperBound ) );
						sb.Append( Environment.NewLine );
					}//End of if/else statement
				}//End if statement
			}//End of for loop
			
			pSequence = sb.ToString();	
        }
		
		//If the sequence is 80 characters long or less, return the protein sequence without an altered format
		else
			{
				pSequence = proteinSequence;
			}
		
	}
    
    //Find and returns the positions of a target subesequence of amino acids in the sequence of a protein sequence.
	public int[ ] FindAllIndicesOf( string subsequence )
    {
        if( string.IsNullOrEmpty( subsequence ) ) return new int[ 0 ];
		
		List< int > indices = new List< int >( );
		
		string[] aSequences = pSequence.Split( new string [] {subsequence}, StringSplitOptions.None );
		int sum = 0;
		
		for(int i = 0; i < aSequences.Length - 1; i++)
		{
			sum += aSequences[i].Length;
			
			if(i > 0)
			{
				sum += subsequence.Length;
			}
			
			
			Console.WriteLine(sum);
			indices.Add(sum);
		}
		
        return indices.ToArray( );
    }
    
    // Get a string representation of the protein in FASTA format.
    public string FastaFormat
    {
        get
        {
			return string.Concat( pID, " ", pName, Environment.NewLine, pSequence );
		}	
    }
    
    // Return an array of proteins read from a FASTA file.
    public static Protein[ ] ReadArrayFromFastaFile( string fileName ) 
        { return ReadListFromFastaFile( fileName ).ToArray( ); }
    
    // Return a list of proteins read from a FASTA file.
    public static List< Protein > ReadListFromFastaFile( string fileName )
    {
        List< Protein > proteins = new List< Protein >( );
        
        using( StreamReader sr = new StreamReader( fileName ) )
        {
            string line = sr.ReadLine( );
            while( line != null )
            {
                // Gather the protein header information.
                string proteinHeader = line;
                line = sr.ReadLine( );
                
                // Gather the protein amino-acid sequence information.
                string proteinSequence = null;
                while( line != null && ! line.StartsWith( ">" ) )
                {
                    proteinSequence += line;
                    line = sr.ReadLine( );
                }
                
                // Add a protein object to the list of proteins.
                proteins.Add( new Protein( proteinHeader, proteinSequence ) );
            }
        }
        return proteins;
    }
    
    // Write an enumerable collection of proteins into a file in FASTA format.
    public static void WriteToFastaFile( IEnumerable< Protein > proteins, string fileName )
    {
        if( File.Exists( fileName ) )
        {
            string message = string.Format( "The file '{0}' already exists.", fileName );
            string parameter = "fileName";
            throw new ArgumentException( message, parameter );
        } 
        
        // TO DO: Complete this method.
		
		//If the file does not exist yet, write each protein in a new line.
		else
		{
			StreamWriter sw = new StreamWriter ( fileName );			
					
			foreach( Protein value in proteins ) 
			{				
				sw.WriteLine( value.FastaFormat );
				sw.Flush( );
			}
		}
    }
}

// Perform a few simple tests on the Protein class.
static class Program
{
    static string inputFile = "protein.fasta";
    static string outputFile = "testOut.fasta";
    
    static void Main( )
    {
        // Test reading from a FASTA file.
        Protein[ ] proteins = Protein.ReadArrayFromFastaFile( inputFile );
        
        Console.WriteLine( );
        Console.WriteLine( "Read {0} proteins from the file '{1}'.", proteins.Length, inputFile );
        
        // Test writing to a FASTA file.
        Protein.WriteToFastaFile( proteins, outputFile );
        
        Console.WriteLine( );
        Console.WriteLine( "Wrote {0} proteins to the file '{1}'.", proteins.Length, outputFile );
        
        // Test finding the indices of a target subsequence.
        foreach( int proteinIndex in new int[ ]{ 2000, 3600, 4000 } )
        {
            string target = "TEE";
            
            Console.WriteLine( );
            Console.WriteLine( proteins[ proteinIndex ].FastaFormat );
            
            int[ ] targetIndices = proteins[ proteinIndex ].FindAllIndicesOf( target );
            if( targetIndices.Length == 0 ) 
            {
                Console.WriteLine( "{0} not found", target );
            }
            else 
            {
                foreach( int index in targetIndices ) 
                {
                    Console.WriteLine( "{0} found starting at index {1}", target, index );
                }
            }
        }
    }
}