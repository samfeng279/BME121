using System;
using System.Collections.Generic;
using System.IO;

// Class BabyName defines objects to hold baby-name records.
class BabyName
{
    // Fields are all private.
    string year;
    string name;
    string county;
    string gender;
    int count;
    
    // Public methods to read each field.
    public string Year { get { return year; } }
    public string Name { get { return name; } }
    public string County { get { return county; } }
    public string Gender { get { return gender; } }
    public int Count { get { return count; } }
    
    // Constructor which receives a value for each field.
    public BabyName( string year, string name, string county, string gender, int count )
    {
        this.year = year;
        this.name = name;
        this.county = county;
        this.gender = gender;
        this.count = count;
    }
    
    // String representation identical to the form used in the file.
    public override string ToString( )
    {
        return string.Format( "{0},{1},{2},{3},{4}", year, name, county, gender, count );
    }
    
    // Parse a string representing one line from the file.
    public static BabyName Parse( string line )
    {
        string[ ] words = line.Split( ',' );
        string year = words[ 0 ];
        string name = words[ 1 ];
        string county = words[ 2 ];
        string gender = words[ 3 ];
        int count = int.Parse( words[ 4 ] );
        return new BabyName( year, name, county, gender, count );
    }
}

static class Program
{
    static void Main( )
    {
        // The file of baby-name data.
        const string babyNameFile = "Baby_Names__Beginning_2007.csv";
        
        // Storing the baby-name data.
        Dictionary< string, List< BabyName > > babyNameListsByName = new Dictionary< string, List< BabyName > >( );
        
        // Load baby-name data from the file.
        using( StreamReader sr = new StreamReader( babyNameFile ) )
        {
            sr.ReadLine( ); // skip header line
            while( !sr.EndOfStream )
            {
                BabyName bn = BabyName.Parse( sr.ReadLine( ) );
                if( ! babyNameListsByName.ContainsKey( bn.Name ) ) 
                    babyNameListsByName[ bn.Name ] = new List< BabyName >( );
                babyNameListsByName[ bn.Name ].Add( bn );
            }
        }
        
        // Report some summary info.
        Console.WriteLine( );
        Console.WriteLine( "New York State baby name data beginning 2007" );
        int numRecords = 0;
        foreach( List< BabyName > list in babyNameListsByName.Values ) numRecords = numRecords + list.Count;
        Console.WriteLine( "Read {0:n0} records from the file '{1}'.", numRecords, babyNameFile );
        Console.WriteLine( "Found {0:n0} unique baby names.", babyNameListsByName.Count );
        
        Console.WriteLine( );
        Console.WriteLine( "Baby names with count of 15 or more in 2013" );
        Console.WriteLine( "but not used in other years:" );
        
        foreach( string babyName in babyNameListsByName.Keys )          // Search through each name of the LinkedList 
        {
            List< BabyName > Key = babyNameListsByName[ babyName ];     // Set Key as the Key of List
            
            bool only2013 = true;                       // Bool variable is true when a baby name is recorded only in 2013.
            int countBabyName = 0;                      // Count of baby name.
            
            foreach( BabyName name in Key )             // Foreach loop searching for a specific name.
            {
                if( name.Year == "2013" )               // If the name is recorded in 2013, add count of the name in 2013 to the total.
                {
                    countBabyName = countBabyName + name.Count;
                }  
                else                                    // If the name is recorded in another year, set the bool to false.
                {
                    only2013 = false;
                }
            }
            
            if( only2013 && countBabyName >= 15)        // If the name was recorded only in 2013 and more than 15 times, write it out.
            {
                Console.WriteLine( babyName + " " + countBabyName );
            }
           
        }
    }
}