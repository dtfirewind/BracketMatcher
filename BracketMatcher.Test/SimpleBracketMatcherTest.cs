using System;
using Xunit;
using BracketMatcher.Domain;

namespace BracketMatcher.Test
{
    public class SimpleBracketMatcherTest
    {
        [Fact]
        public void TestEmptyString()
        {
            var emptyString = "";
            var matcher = new SimpleBracketMatcher();
            Assert.Equal(-1,matcher.Match(emptyString));
        }

        [Fact]
        public void TestWithRoundBrackets()
        {
            var roundBrackets = "123(12313)";
            var matcher = new SimpleBracketMatcher();
            Assert.Equal(-1,matcher.Match(roundBrackets));
        }

        [Fact]
        public void TestWithNotMatchedRoundBrackets()
        {
            var roundBrackets = "1)23(12313)";
            var matcher = new SimpleBracketMatcher();
            Assert.Equal(1,matcher.Match(roundBrackets));
        }

        [Fact]
        public void TestWithNotMatchedRoundBrackets2()
        {
            var roundBrackets = "1(())23(12)313)";
            var matcher = new SimpleBracketMatcher();
            Assert.Equal(14,matcher.Match(roundBrackets));
        }

        [Fact]
        public void TestWithMatchedSquareBrackets()
        {
            var roundBrackets = "[12]3[12]3()13[]";
            var matcher = new SimpleBracketMatcher();
            Assert.Equal(-1,matcher.Match(roundBrackets));
        }

        [Fact]
        public void TestWithMatchedCurlyBrackets()
        {
            var roundBrackets = "[12]3{}[12]3()1{}3[]";
            var matcher = new SimpleBracketMatcher();
            Assert.Equal(-1,matcher.Match(roundBrackets));
        }
    }
}
