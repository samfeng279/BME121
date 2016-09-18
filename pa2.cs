// -------------------------------------------------------------------
// Biomedical Engineering Program
// Department of Systems Design Engineering
// University of Waterloo
//
// Student Name:     Samantha Feng
// Userid:           s38feng
//
// Assignment:       Programming Assignment 2
// Submission Date:  10/19/2015
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// Acknowledgements:
// Original code template and comments written by Jeff Luo, BME121 TA
// -------------------------------------------------------------------

using System;

// Class Program is a procedural-programming implementation of the game of tic-tac-toe.
// Player is a string [X or O].
// Player type is a string [ai or human]
// Location is a string [a1, a2, a3, b1, b2, b3, c1, c2, or c3].

static class Program
{
    // Each variable holds the mark made in the cell at the corresponding location on the game board.
    static string a1, a2, a3, b1, b2, b3, c1, c2, c3;
    
    // The player types.
    static string xPlayerType, oPlayerType;
    
    // A random number generator for use by AI players.
    static Random rGen = new Random( );
    
    //--------------------
    // Main plays the game by calling other methods.
    static void Main( )
    {
        string currentPlayer;
        string location;
        
        Console.WriteLine( );
        Console.WriteLine( "Welcome to BME121 Tic-Tac-Toe" );
        
        ClearBoard( );
        WriteBoard( );
        
        xPlayerType = GetPlayerType( "X" );
        oPlayerType = GetPlayerType( "O" );
        
        currentPlayer = GetFirstPlayer( );
        
        while( ! IsFullBoard( ) )
        {
            location = GetNextLocation( currentPlayer );
            
            MarkBoard( currentPlayer, location );
            WriteBoard( );
            
            if( IsWinForPlayer( currentPlayer ) )
            {
                Console.WriteLine( );
                Console.WriteLine( "Player {0} wins! ({1})", currentPlayer, WinPatterns( currentPlayer ) );
                return;
            }
            
            currentPlayer = GetNextPlayer( currentPlayer );
        }
        
        Console.WriteLine( );
        Console.WriteLine( "Game is a draw (no winner)." );
    }
    
    // Board-related methods
    
    //--------------------
    // Set every board cell to blank, ready for play.
    static void ClearBoard( )
    {
        a1 = " "; a2 = " "; a3 = " ";
        b1 = " "; b2 = " "; b3 = " ";
        c1 = " "; c2 = " "; c3 = " ";
    }
    
    //--------------------
    // Mark the board for a given player at a given location.
    // Invalid locations are ignored.
    static void MarkBoard( string player, string location )
    {
		switch ( location )
		{
			case "a1": a1 = player;
				break;
			case "a2": a2 = player;
				break;
			case "a3": a3 = player;
				break;
			case "b1": b1 = player;
				break;
			case "b2": b2 = player;
				break;
			case "b3": b3 = player;
				break;
			case "c1": c1 = player;
				break;
			case "c2": c2 = player;
				break;
			case "c3": c3 = player;
				break;
			default:
				break;
		}//end switch
		
    }//end MarkBoard( ) method
    
    //--------------------
    // Check whether the board is full so no more moves are possible.
    static bool IsFullBoard( )
    {
		//if all possible locations are full, IsFullBoard is true
		//if there is one or more empty spaces on the grid, IsFullBoard is false
		
		if ( a1 != " " && a2 != " " && a3 != " " && b1 != " " && b2 != " " && b3 != " " && c1 != " " && c2 != " " && c3 != " " )
		{ 
			return true; 
		}
		
		else 
		{ 
			return false; 
		}//end if-else loop
		
    }//end IsFullBoard( ) method

    //--------------------
    // Display the current board on the console.
    static void WriteBoard( )
    {
        // Renaming some horrible codes for box elements to something memorable
        const char hl = '\u2500'; // horizontal line     
        const char vl = '\u2502'; // vertical line       
        const char tl = '\u250c'; // top left corner     
        const char tm = '\u252c'; // top middle joint    
        const char tr = '\u2510'; // top right corner    
        const char ml = '\u251c'; // middle left joint   
        const char mm = '\u253c'; // middle middle joint 
        const char mr = '\u2524'; // middle right joint  
        const char bl = '\u2514'; // bottom left corner  
        const char bm = '\u2534'; // bottom middle joint 
        const char br = '\u2518'; // bottom right corner 
        
        // Format string for output lines that are only box edges
        // Argument index   1 0 2       3
        // Line of the form [---+---+---]
        string format1 = "   {1}{0}{0}{0}{2}{0}{0}{0}{2}{0}{0}{0}{3}";
        
        // Format string for output lines that are mostly box contents
        // Argument index   0 1  2     3     4
        // Line of the form x | x11 | x12 | x13 |
        string format2 = " {0} {1} {2} {1} {3} {1} {4} {1}";
        
        // Show the board
        Console.WriteLine( );
        Console.WriteLine( format2, " ", " ", "1", "2", "3" );  // col index labels
        Console.WriteLine( format1,       hl,  tl,  tm,  tr );  // tops of boxes
        Console.WriteLine( format2, "a",  vl,  a1,  a2,  a3 );  // game-play
        Console.WriteLine( format1,       hl,  ml,  mm,  mr );  // middles of boxes
        Console.WriteLine( format2, "b",  vl,  b1,  b2,  b3 );  // game-play
        Console.WriteLine( format1,       hl,  ml,  mm,  mr );  // middles of boxes
        Console.WriteLine( format2, "c",  vl,  c1,  c2,  c3 );  // game-play
        Console.WriteLine( format1,       hl,  bl,  bm,  br );  // bottoms of boxes
    }
    
    // Player-related methods.
    
    //--------------------
    // Ask which player should go first.
    // We retry until the user enters X or O.
    // Input is automatically converted to upper case.
    static string GetFirstPlayer( )
    {		
		Console.WriteLine( );
		
		//Prompts user for first player (X or O)
		//Takes input of first player from user and converts input into upper case
		Console.Write( "Enter player who will go first: " );
		string firstPlayer = Console.ReadLine( ).ToUpper( );
		
		//If user enters a value that is invalid, prompts user until X or O is entered
		while( firstPlayer != "X" && firstPlayer != "O" )
		{
			Console.WriteLine("Player must be X or O.");
			Console.Write( "Try again: " );
			firstPlayer = Console.ReadLine( ).ToUpper( );
		}//end while loop
		
		return firstPlayer;
		
    }//end GetFirstPlayer() method
    
    //--------------------
    // Request the player type (ai/human) for a given player.
    // We retry until the user enters human or ai.
    // Input is automatically converted to lower case.
    static string GetPlayerType( string player )
    {
		Console.WriteLine( );
		Console.Write( "Enter player {0} type: ", player);
		string playerType = Console.ReadLine( ).ToLower( );
		
		while( playerType != "human" && playerType != "ai" )
		{
			Console.WriteLine( "Player type must be 'human' or 'ai'." );
			Console.Write( "Try again: " );
			playerType = Console.ReadLine( ).ToLower( );
		}//end while loop
		
		return playerType;		
    }//end GetPlayerType() method
    
    //--------------------
    // Return whether a given player is human.
    // We return false for an invalid player.
    static bool IsHuman( string player )
    {
        switch( player )
        {
            case "X": return xPlayerType == "human";
            case "O": return oPlayerType == "human";
            default: return false;
        }
    }
    
    //--------------------
    // Given the current player, return the next player.
    // We return "X" for an invalid player.
    static string GetNextPlayer( string player )
    {
        switch( player )
        {
            case "X": return "O";
            case "O": return "X";
            default: return "X";
        }
    }

    // Win-pattern-related methods.
    
    //----------
    // Check whether a given player has won the game.
    static bool IsWinForPlayer( string player )
    {
        return WinPatterns( player ) != null;
    }
    
    //--------------------
    // Identify all winning patterns for a given player.
    // We return null if there is no winning pattern.
    static string WinPatterns( string player )
    {
        if (player == a1 && player == a2 && player == a3)
		{
			return "Win: a1, a2, a3";
		}
		
		else if (player == b1 && player == b2 && player == b3)
		{
			return "Win: b1, b2, b3";
		}
		
		else if (player == c1 && player == c2 && player == c3)
		{
			return "Win: c1, c2, c3";
		}
		
		else if (player == a1 && player == b1 && player == c1)
		{
			return "Win: a1, b1, c1";
		}
		
		else if (player == a2 && player == b2 && player == c2)
		{
			return "Win: a2, b2, c2";
		}
		
		else if (player == a3 && player == b3 && player == c3)
		{
			return "Win: a3, b3, c3";
		}
		
		else if (player == a1 && player == b2 && player == c3)
		{			
			return "Win: a1, b2, c3";
		}
		
		else if (player == a3 && player == b2 && player == c1)
		{
			return "Win: a3, b2, c1";
		}
		
		else
		{ 
			return null;
		}
    }
    
    // Location-related methods
    
    //--------------------
    // Check whether a string represents a valid location.
    static bool IsValidLocation( string location )
    {
		if( location == "a1" || location == "a2" || location == "a3" || location == "b1" || location == "b2" || location == "b3" || location == "c1" || location == "c2" || location == "c3" )
			{return true;}
		
		else {return false;}
    }
    
    //--------------------
    // Check whether a given location empty, i.e., not marked X or O.
    // We return false for an invalid location.
    static bool IsEmptyLocation( string location )
    {
        
		if( !IsValidLocation (location) )
		{
			return false;
		}
		
		switch (location)
		{
			case "a1":
				if (a1 == " ") return true;
				else {return false;}
			case "a2":
				if (a2 == " ") return true;
				else {return false;}
			case "a3":
				if (a3 == " ") return true;
				else {return false;}
			case "b1":
				if (b1 == " ") return true;
				else {return false;}
			case "b2":
				if (b2 == " ") return true;
				else {return false;}
			case "b3":
				if (b3 == " ") return true;
				else {return false;}
			case "c1":
				if (c1 == " ") return true;
				else {return false;}
			case "c2":
				if (c2 == " ") return true;
				else {return false;}
			case "c3":
				if (c3 == " ") return true;
				else {return false;}	
			default: return false;
		}
    }
    
    //--------------------
    // Choose a board location at random.
    // For the required default case (which can't happen here), we return null. 
    static string GetRandomLocation( )
    {		
		int number = rGen.Next( 1, 10 );		//A number from 1 to 9 is randomly generated
		string location;						//Position on the grid that AI selects
		
		switch ( number )						//
		{
			case 1: location = "a1";			//Each number from 1 to 9 correlates to a unique position on the grid
				break;							//For example, if 1 is rolled, AI selects a1 as location
			case 2: location = "a2";
				break;
			case 3: location = "a3";
				break;
			case 4: location = "b1";
				break;
			case 5: location = "b2";
				break;
			case 6: location = "b3";
				break;
			case 7: location = "c1";
				break;
			case 8: location = "c2";
				break;
			case 9: location = "c3";
				break;
			default: return null;				//There is no default case; therefore, return null
		}//end switch
		
		return location;						//Returns: a randomly chosen location on the board
    }
    
    //--------------------
    // Use AI to choose a location.
    // This AI chooses randomly from the unoccupied locations.
    static string GetAIChosenLocation( )
    {
        if( IsFullBoard( ) ) throw new Exception( );
        string location = GetRandomLocation( );
        while( ! IsEmptyLocation( location ) ) 
        {
            location = GetRandomLocation( );
        }
        return location;
    }
    
    //--------------------
    // Request the next play location from a given player.
    // For a human player, we repeat the request until the user
    // enters a valid location which is currently empty.
    // Input is automatically converted to lower case.
    static string GetNextLocation( string player )
    {
        string location;
		
        
        if( IsHuman( player ) )
        {
            Console.WriteLine( );
			Console.Write("Human player {0}, enter your play location: ", player);
			location = Console.ReadLine().ToLower();			
			
			while ( !IsValidLocation( location ) )
				{	

					Console.WriteLine( );
					Console.WriteLine( "Location must be one of a1,a2,a3,b1,b2,b3,c1,c2,c3.");
					Console.Write( "Try again: " );
					location = Console.ReadLine().ToLower();
				}
			
			while ( !IsEmptyLocation(location) )
				{
					if ( !IsValidLocation (location) )
					{
						Console.WriteLine( );
						Console.WriteLine( "Location must be one of a1,a2,a3,b1,b2,b3,c1,c2,c3.");
					}
					else
					{
						Console.WriteLine( );
						Console.WriteLine( "You must pick an empty location.");
					}
					
					Console.Write( "Try again: " );
					location = Console.ReadLine().ToLower();
				}
			
			if (IsValidLocation(location) && IsEmptyLocation ( location ) )
			{
				return location;
			}	
			
        }
        else // AI player
        {
            Console.WriteLine( );
            Console.WriteLine( "AI player {0} is thinking ...", player );
            System.Threading.Thread.Sleep( 1000 );
            location = GetAIChosenLocation( );
            Console.WriteLine( "AI player {0} chose location: {1}", player, location );
            System.Threading.Thread.Sleep( 1000 );
        }
        
        return location;
    }
}