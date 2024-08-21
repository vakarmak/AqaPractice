namespace PlaywrightUiTests.Homework;

public abstract class EnumHomework
{
    // TODO: modify enum so CheckCustomIntNumbersForTestDataAgeEnum pass
    private enum TestDataAge
    {
        Child = 7,
        Teenager = 14,
        Adult = 30
    }

    // TODO: uncomment and implement tests so all Assert pass. Use such LINQ as Any(), Count(), Contains()
    [TestFixture]
    public class EnumHomeworkTests
    {
        [Test]
        public void CheckCustomIntNumbersForTestDataAgeEnum()
        {
            Assert.Multiple(() =>
            {
                Assert.That((int)TestDataAge.Child, Is.EqualTo(7));
                Assert.That((int)TestDataAge.Teenager, Is.EqualTo(14));
                Assert.That((int)TestDataAge.Adult, Is.EqualTo(30));
            });
        }

        [Test]
        public void SomeIntCorrespondsToSomeTestDataAgeValue()
        {
            var listOfInt = new List<int>() { 5, 14, 15 };
            
            var enumValues = Enum.GetValues(typeof(TestDataAge))
                .Cast<TestDataAge>()
                .Select(e => (int)e)
                .ToHashSet();

            var isAnyIntCorrespondsToTestDataAge = listOfInt.Any(i => enumValues.Contains(i));

            Assert.That(isAnyIntCorrespondsToTestDataAge, Is.True);
        }

        [Test]
        public void NumberOfIntCorrespondsToSomeTestDataAgeValue()
        {
            var listOfInt = new List<int> { 5, 14, 15, 30 };
            
            var enumValues = Enum.GetValues(typeof(TestDataAge))
                .Cast<TestDataAge>()
                .Select(e => (int)e)
                .ToHashSet();

            var numberOfIntCorrespondToTestDataAge = listOfInt.Count(i => enumValues.Contains(i));
        
            Assert.That(numberOfIntCorrespondToTestDataAge, Is.EqualTo(2));
        }

        [TestCaseSource(nameof(_stringElementsArePresentInEnumCases))]
        public void StringElementsArePresentInEnum(string[] list, int expectedNumberPresent, int expectedNumberExtra,
            bool areAllPresentExpected, bool areExtraElementsExpected)
        {
            var listOfString = list.ToList();

            var enumValues = Enum.GetValues(typeof(TestDataAge))
                .Cast<TestDataAge>()
                .Select(e => e.ToString())
                .ToHashSet();;
        
            // for the first test case { "Child", "Baby", "Teenager", "Elder", "Adult" } there are only 3 (out of 5) strings "Child", "Teenager", "Adult" are present in TestDataAge
            // so for the first case numberOfStringsWhichPresentInEnum is 3
            var numberOfStringsWhichPresentInEnum = listOfString.Count(i => enumValues.Contains(i));
            // "Baby" and "Elder" are not present in TestDataAge, so numberOfStringsWhichAreNotPresentInEnum is 2
            var numberOfStringsWhichAreNotPresentInEnum = listOfString.Count(i => !enumValues.Contains(i));
            // for the first case not all strings are present in TestDataAge (only 3 out of 5 are present)), so expression result should be false
            bool areAllPresent = listOfString.All(i => enumValues.Contains(i));
            // for the first case, yes, there are 2 extra elements "Baby" and "Elder", so result is true
            bool areExtraElements = listOfString.Any(i => !enumValues.Contains(i));
            
            Assert.Multiple(() =>
            {
                Assert.That(numberOfStringsWhichPresentInEnum, Is.EqualTo(expectedNumberPresent));
                Assert.That(numberOfStringsWhichAreNotPresentInEnum, Is.EqualTo(expectedNumberExtra));
                Assert.That(areAllPresent, Is.EqualTo(areAllPresentExpected));
                Assert.That(areExtraElements, Is.EqualTo(areExtraElementsExpected));
            });

        }
        
        private static object[] _stringElementsArePresentInEnumCases =
        [
            new object[] { new string[] { "Child", "Baby", "Teenager", "Elder", "Adult" }, 3, 2, false, true },
            new object[] { new string[] { "Child", "Teenager", "Adult" }, 3, 0, true, false },
            new object[] { new string[] { "Baby", "Teenager", "Elder" }, 1, 2, false, true },
            new object[] { new string[] { "Adult", "Child" }, 2, 0, true, false },
            new object[] { new string[] { "Elder", "Baby" }, 0, 2, false, true },
            new object[] { new string[] { }, 0, 0, true, false }
        ];
    }
}