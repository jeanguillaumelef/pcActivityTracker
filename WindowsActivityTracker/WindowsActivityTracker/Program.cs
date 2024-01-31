using System.Timers;
using DomainLogic;
using WinUser;




WindowInformation windowInformation = new WindowInformation();
ActivityTracker tracker = new(windowInformation);
// Initialize the timer
var timer = new System.Timers.Timer();
timer.Elapsed += WriteToFile;
timer.Interval = 1000; // Set the interval to one minute (in milliseconds)
timer.AutoReset = true; // Set to true for continuous execution

// Start the timer
timer.Start();

Console.WriteLine("Press Enter to exit.");
Console.ReadLine();

// Stop the timer before exiting the application
timer.Stop();

//TODO should be a repo!
void WriteToFile(object? sender, ElapsedEventArgs e)
{
    string filePath = "activity.txt";
    using (StreamWriter writer = new StreamWriter(filePath, true))
    {
        var windowName = tracker.GetActivityName();
        //TODO Write the current time to the file
        writer.WriteLine(windowName);
    }
}    

