using System;
using System.Diagnostics;
using System.IO;

static class Program
{
    //The method SortCars sorts a collection of NhtsaCar objects first by make, then model, and finally by vin.
    static int SortCars( NhtsaCar one, NhtsaCar two )
    {
        if( one.Make != two.Make ) return one.Make.CompareTo( two.Make );
        else if( one.Model != two.Model ) return one.Model.CompareTo( two.Model );
        else return one.Vin.CompareTo( two.Vin );  
    }
    
    static void Main( )
    {
        // Create a stopwatch for reading the file.
        Stopwatch readTimer = new Stopwatch( );
        
        // Create a stopwatch for sorting the .
        Stopwatch sortTimer = new Stopwatch( );
        
        // Database of NhtsaCar information.
        string carFileName = "veh.csv";
        
        // Form the empty list of cars.
        NhtsaCarList carsList = new NhtsaCarList( );
        Console.WriteLine( );
        Console.WriteLine( "Empty car list:" );
        Console.WriteLine( "carsList = {0}", carsList );
        
        // Fill the list using data read from the file.
        Console.WriteLine( );
        Console.WriteLine( "Reading cars from '{0}' ...", carFileName );
       
        // Start the stopwatch for reading the file, read the file, and stop the stopwatch after reading.
        readTimer.Start( );
        using( StreamReader sr = new StreamReader( carFileName ) )
        {
            while( ! sr.EndOfStream )
            {
                carsList.Append( NhtsaCar.Parse( sr.ReadLine( ) ) );
            }
        }
        readTimer.Stop( );
        
        Console.WriteLine( "carsList = {0}", carsList );
        
        // Convert to an array.
        Console.WriteLine( );
        Console.WriteLine( "Extracting cars as an array ..." );
        NhtsaCar[ ] carsArray = carsList.ToArray( );
        if( carsArray.Length == 0 ) Console.WriteLine( "carsArray has zero elements" );
        if( carsArray.Length > 0 ) Console.WriteLine( "carsArray[ {0,4} ] = {1}", 0, carsArray[ 0 ].ToCsvString( ) );
        if( carsArray.Length > 1 ) Console.WriteLine( "carsArray[ {0,4} ] = {1}", 1, carsArray[ 1 ].ToCsvString( ) );
        if( carsArray.Length > 2 ) Console.WriteLine( "carsArray[ {0,4} ] = {1}", 2, carsArray[ 2 ].ToCsvString( ) );
        if( carsArray.Length > 6 ) Console.WriteLine( "..." );
        if( carsArray.Length > 5 ) 
            Console.WriteLine( "carsArray[ {0,4} ] = {1}", 
            carsArray.Length - 3, carsArray[ carsArray.Length - 3 ].ToCsvString( ) );
        if( carsArray.Length > 4 ) 
            Console.WriteLine( "carsArray[ {0,4} ] = {1}", 
            carsArray.Length - 2, carsArray[ carsArray.Length - 2 ].ToCsvString( ) );
        if( carsArray.Length > 3 ) 
            Console.WriteLine( "carsArray[ {0,4} ] = {1}", 
            carsArray.Length - 1, carsArray[ carsArray.Length - 1 ].ToCsvString( ) );
            
        // Sort the array.
        Console.WriteLine( );
        Console.WriteLine( "Sorting the array ..." );
        
        // Start timer for sorting, call SortCars method to sort array, stop timer for sorting.
        sortTimer.Start( );
        Array.Sort( carsArray, SortCars );
        sortTimer.Stop( );
        
        if( carsArray.Length == 0 ) Console.WriteLine( "carsArray has zero elements" );
        if( carsArray.Length > 0 ) Console.WriteLine( "carsArray[ {0,4} ] = {1}", 0, carsArray[ 0 ].ToCsvString( ) );
        if( carsArray.Length > 1 ) Console.WriteLine( "carsArray[ {0,4} ] = {1}", 1, carsArray[ 1 ].ToCsvString( ) );
        if( carsArray.Length > 2 ) Console.WriteLine( "carsArray[ {0,4} ] = {1}", 2, carsArray[ 2 ].ToCsvString( ) );
        if( carsArray.Length > 6 ) Console.WriteLine( "..." );
        if( carsArray.Length > 5 ) 
            Console.WriteLine( "carsArray[ {0,4} ] = {1}", 
            carsArray.Length - 3, carsArray[ carsArray.Length - 3 ].ToCsvString( ) );
        if( carsArray.Length > 4 ) 
            Console.WriteLine( "carsArray[ {0,4} ] = {1}", 
            carsArray.Length - 2, carsArray[ carsArray.Length - 2 ].ToCsvString( ) );
        if( carsArray.Length > 3 ) 
            Console.WriteLine( "carsArray[ {0,4} ] = {1}", 
            carsArray.Length - 1, carsArray[ carsArray.Length - 1 ].ToCsvString( ) );
            
        // Remake the list from the sorted array.
        Console.WriteLine( );
        Console.WriteLine( "Rebuilding the list from the sorted array ..." );
        carsList = new NhtsaCarList( );
        foreach( NhtsaCar car in carsArray ) carsList.Append( car );
        Console.WriteLine( "carsList = {0}", carsList );
        
        // Return the amount of time taken to read the file, and the time taken to sort the array.
        Console.WriteLine( );
        Console.WriteLine( "Reading from the file took {0} ms", readTimer.ElapsedMilliseconds );
        Console.WriteLine( "Sorting the array took {0} ms", sortTimer.ElapsedMilliseconds );
    }
}