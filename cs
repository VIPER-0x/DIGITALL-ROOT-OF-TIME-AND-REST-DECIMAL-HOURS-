using System;  
using System.Threading;  

public class DigitalRootChecker  
{  
    public static int CalculateDigitalRoot(int number)  
    {  
        while (number >= 10)  
        {  
            int sum = 0;  
            while (number > 0)  
            {  
                sum += number % 10;  
                number /= 10;  
            }  
            number = sum;  
        }  
        return number;  
    }  

    public static bool CheckDigitalRoot(decimal hours, int targetRoot)  
    {  
        int decimalHours = (int)(hours * 100); // Convert to integer for digital root calculation  
        int digitalRoot = CalculateDigitalRoot(decimalHours);  
        return digitalRoot == targetRoot;  
    }  

    public static void Main(string[] args)  
    {  
        int targetRoot = 7; // Set your desired target digital root  

        while (true)  
        {  
            DateTime now = DateTime.Now; // Get the current time  
            DateTime startOfDay = now.Date; // Start of the current day  
            DateTime endOfDay = startOfDay.AddDays(1); // End of the current day (midnight)  

            // Calculate passed time and remaining time  
            TimeSpan passedTime = now - startOfDay;  
            TimeSpan remainingTime = endOfDay - now;  

            // Convert to decimal hours  
            decimal passedHours = (decimal)passedTime.TotalHours;  
            decimal remainingHours = (decimal)remainingTime.TotalHours;  

            // Calculate digital roots  
            int passedDigitalRoot = CalculateDigitalRoot((int)(passedHours * 100));  
            int remainingDigitalRoot = CalculateDigitalRoot((int)(remainingHours * 100));  

            // Check for matches  
            bool isPassedMatch = CheckDigitalRoot(passedHours, targetRoot);  
            bool isRemainingMatch = CheckDigitalRoot(remainingHours, targetRoot);  

            // Display the results  
            Console.Clear();  
            Console.WriteLine($"Passed Time: {passedHours:F2} hours");  
            Console.WriteLine($"Remaining Time: {remainingHours:F2} hours");  
            Console.WriteLine($"Digital Root of Passed Time: {passedDigitalRoot}");  
            Console.WriteLine($"Digital Root of Remaining Time: {remainingDigitalRoot}");  
            Console.WriteLine($"Match for Passed Time Digital Root (Target: {targetRoot}): {isPassedMatch}");  
            Console.WriteLine($"Match for Remaining Time Digital Root (Target: {targetRoot}): {isRemainingMatch}");  

            // Wait for a second before updating  
            Thread.Sleep(1000);  
        }  
    }  
}
