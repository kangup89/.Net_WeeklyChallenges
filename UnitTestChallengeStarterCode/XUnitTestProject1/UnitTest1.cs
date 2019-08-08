using System;
using Xunit;
using CalculationsLibrary;
using System.Collections.Generic;
using System.IO;

namespace XUnitTestProject1
{
    public class CalculatorTest
    {
        [Fact]
        public void AddTest()
        {
            double a = 3;
            double b = 4;
            double expected = 7;

            double result = Calculator.Add(a, b);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void AddTest2()
        {
            int a = 3;
            int b = 4;
            int expected = 7;

            double result = Calculator.Add(a, b);
            Assert.Equal(expected, result);

            double a2 = 4;
            double b2 = 8;
            double expected2 = 11;

            double result2 = Calculator.Add(a2, b2);
            Assert.NotEqual(expected2, result2);
        }

        [Fact]
        public void DivideTest()
        {
            double a = 12;
            double b = 4;
            double expected = 3;

            double result = Calculator.Divide(a, b);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void DividedTest2()
        {
            double a = 12;
            double b = 0;

            Action testCode = () => { var result = Calculator.Divide(a, b); };

            var ex = Record.Exception(testCode);

            Assert.NotNull(ex);
            Assert.IsType<ArgumentException>(ex);
        }

        [Fact]
        public void LimitedAddTest()
        {
            double a = 5;
            double b = 6;
            double min = 0;
            double max = 10;
            double expected = 11;

            double result = Calculator.LimitedAdd(a, b, min, max);
            Assert.Equal(expected, result);

            a = 11;
            b = 4;

            Action testCode = () => { double result2 = Calculator.LimitedAdd(a, b, min, max); };
            var ex = Record.Exception(testCode);
            Assert.IsType<ArgumentOutOfRangeException>(ex);
        }
    }

    public class TextDataAccessTest
    {
        [Fact]
        public void SaveTextTest()
        {
            string filePath = "filepath";
            List<string> lines = new List<string>() { "dlkfjwoeitupisposf, ", "sjdlfujrtppqepoiqq", "fccoviuoeqlkjwe" };

            List<string> result = TextDataAccess.SaveText(filePath, lines);

            Assert.Equal(lines, result);
        }

        [Fact]
        public void SaveTextTest2()
        {
            string filePath = "lskdfjkdjfkdjflkdjlfkdjlskdjfpwierpweurppppppppppppppppppppppppppppppppppppppppppppppp" +
                "oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                "oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo";
            List<string> lines = new List<string>() { "dlkfjwoeitupisposf, ", "sjdlfujrtppqepoiqq", "fccoviuoeqlkjwe" };

            Action testCode = () => { List<string> result = TextDataAccess.SaveText(filePath, lines); };
            var ex = Record.Exception(testCode);

            Assert.IsType<PathTooLongException>(ex);
        }
    }
}
