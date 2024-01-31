using DomainLogic.Repositories;
using System.Linq;

namespace DomainLogic
{
    public class ActivityTracker
    {
        private const string privacyTerm = "private";
        private const string privateActivityName = "Private";
        private const char windowTitleSeparatorChar = '-';
        private IWindowInformation _windowInformation;


        public ActivityTracker(IWindowInformation windowInformation)
        {
            _windowInformation = windowInformation;
        }

        public string GetActivityName()
        {
            var windowTitle = _windowInformation.GetWindowTitle();
            var activityName = CleanAndPrivatiseWindowTitle(windowTitle);

            return activityName;
        }

        private string CleanAndPrivatiseWindowTitle(string windowTitle)
        {
            string activityName = windowTitle;

            if (windowTitle.Contains(privacyTerm, StringComparison.OrdinalIgnoreCase))
            {
                activityName = privateActivityName;
            }
            else if (windowTitle.Count(x => string.Equals(x, windowTitleSeparatorChar)) > 1)
            {
                activityName = GetStringBeforeAndAfterLastSeparator(windowTitle);

            }

            return activityName.TrimStart();
        }

        private static string GetStringBeforeAndAfterLastSeparator(string windowTitle)
        {
            string activityName;
            int separatorCharIndex = windowTitle.LastIndexOf(windowTitleSeparatorChar);
            int secondToLastHyphenIndex = windowTitle.LastIndexOf(windowTitleSeparatorChar, separatorCharIndex - 1);
            activityName = windowTitle.Substring(secondToLastHyphenIndex + 1);
            return activityName;
        }
    }
}