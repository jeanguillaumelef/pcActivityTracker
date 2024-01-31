using DomainLogic.Repositories;

namespace TestWindowsActivityTracker.FakedRepositories
{
    public class FakeWindowInformation : IWindowInformation
    {
        public string WindowTitle { get; set; }

        public FakeWindowInformation(string windowTitle)
        {
            WindowTitle = windowTitle;
        }


        public string GetWindowTitle()
        {
            return WindowTitle;
        }
    }
}