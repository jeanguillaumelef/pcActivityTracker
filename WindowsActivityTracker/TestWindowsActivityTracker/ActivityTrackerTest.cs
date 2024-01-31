using DomainLogic;
using TestWindowsActivityTracker.FakedRepositories;

namespace TestWindowsActivityTracker
{
    public class ActivityTrackerTest
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("a","a")]
        [InlineData("b\\b","b\\b")]
        [InlineData("a - a", "a - a")]
        [InlineData("a - a - a", "a - a")]
        [InlineData("a - private - a", "Private")]
        [InlineData("a - Private - a", "Private")]
        [InlineData("Private - a - a", "Private")]
        [InlineData("a - a - Private", "Private")]        
        public void CanAddTheory(string rawWindowTitle, string expectedResult)
        {
            FakeWindowInformation fakeWindowInformation = new(rawWindowTitle);

            ActivityTracker activityTracker = new(fakeWindowInformation);

            var activityName = activityTracker.GetActivityName();

            Assert.Equal(activityName, expectedResult);
        }
    }
}