// -------------------------------------------------------------------
// Biomedical Engineering Program
// Department of Systems Design Engineering
// University of Waterloo
//
// Student Name:     Samantha Feng
// Userid:           s38feng
//
// Assignment:       Programming Assignment 1
// Submission Date:  10/01/2015
// 
// I declare that, other than the acknowledgements listed below, 
// this program is my original work.
//
// -------------------------------------------------------------------

using System;

static class Program
{
	static void Main( )
		{
			
			//establishing variables
			double loanAmount;			//value of mortgage loan
			double interest;			//yearly interest rate of loan (percentage)
			double rateOfPayment;		//monthly payment (dollars)
			double years;				//amortization period (years)
			double days;				//amortization period (days)
			DateTime today;				//todays date
			TimeSpan numberOfDays;		//number of days needed to pay off loan
			DateTime payOffDate;		//date loan is paid off
			
			//program title
			Console.WriteLine( "Approximate mortgage time calculator" );
			
			//input from user (value of loan, yearly interest rate, monthly payment) 
			Console.Write( "Enter a loan amount (dollars): ");
			loanAmount = double.Parse(Console.ReadLine( ) );
			Console.Write( "Enter an interest rate (percent): ");
			interest = double.Parse(Console.ReadLine( ) );
			Console.Write( "Enter a monthly payment (dollars): ");
			rateOfPayment = double.Parse( Console.ReadLine( ) );
			
			//calculations for amortization period in years
			years = -( 100 / interest ) * Math.Log( 1 - loanAmount * interest / ( 1200 * rateOfPayment ) );
			
			//display amortization period in years to user
			Console.WriteLine( "Amortization period: {0:f3} years", years );
			
			//conversion of amortization period from years to days
			days = years * 365.242199;

			//calculation for date loan is paid off
			today = DateTime.Now;
			numberOfDays = TimeSpan.FromDays( days );
			payOffDate = today + numberOfDays;

			//display date loan is paid off to user
			Console.WriteLine( "Loan paid off: {0:MMMM yyyy}", payOffDate );
			
			
		
		}
}