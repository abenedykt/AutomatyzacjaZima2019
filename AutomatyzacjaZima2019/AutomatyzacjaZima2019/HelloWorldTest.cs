using System;
using Xunit;

namespace AutomatyzacjaZima2019
{
    public class HelloWorldTest
    {
        [Fact]
        public void CanSayHello()
        {
            // aaa

            // arrange
            var a = 1;
            var b = 2;
            
            // act
            var result = Function(a, b);

            // assert
            Assert.Equal(42, result);
        }

        private int Function(int a, int b)
        {
            return 42;
        }
    }
}
