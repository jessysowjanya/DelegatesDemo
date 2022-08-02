using Xunit;
using DelegatesDemo;
using System.Net;

namespace DelegatesDemoTest
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("abc")]
        [InlineData("123abc")]
        [InlineData("a1b2c3")]
        public void ConsoleReader_ForAlphabetsAndNumbers(string entered)
        {
            var reader = new ConsoleReader();
            var wordObj = new onWordDelegate(reader.OnWord);
            Assert.Equal("From OnWord Method", wordObj.Invoke(entered));

        }
        [Fact]
        public void ConsoleReader_ForOnlyNumbers()
        {
            var reader = new ConsoleReader();
            string num = "123";
            string num1 = string.Empty;
            var numObj = new onNumberDelegate(reader.OnNumber);
            Assert.Equal("From OnNumber method ", numObj.Invoke(num));
            Assert.Equal("From OnNumber method ", numObj.Invoke(num1));
        }
        [Fact]
        public void ConsoleReader_ForJunk()
        {
            var reader = new ConsoleReader();
            string symb = "123@#$";
            string symb1 = "^&%";
            var junkObj = new onNumberDelegate(reader.OnJunk);
            Assert.Equal("From OnJunk method ", junkObj.Invoke(symb));
            Assert.Equal("From OnJunk method ", junkObj.Invoke(symb1));
        }
    }
}