using Xunit;

namespace DeveloperSample.Algorithms
{
    public class AlgorithmTest
    {
        [Fact]
        public void CanGetFactorial()
        {
            Assert.Equal(24, Algorithms.GetFactorial(4));
            Assert.Equal(1, Algorithms.GetFactorial(0));
            Assert.Equal(120, Algorithms.GetFactorial(5));
        }

        [Fact]
        public void CanFormatSeparators()
        {
            Assert.Equal("a, b and c", Algorithms.FormatSeparators("a", "b", "c"));
            Assert.Equal("a and b", Algorithms.FormatSeparators("a", "b"));
            Assert.Equal("a", Algorithms.FormatSeparators("a"));
            Assert.Equal(string.Empty, Algorithms.FormatSeparators());
        }
    }
}
