using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Step3.Tests
{
    class ReporterTests
    {
        private Reporter _reporter;

        [SetUp]
        public void Setup()
        {
            _reporter = new Reporter();    
        }

        [Test]
        public void Report_WhenListNull_ThrowsException()
        {
            Action a = () => _reporter.Report(null);

            a.ShouldThrow<ArgumentNullException>().WithMessage("Value cannot be null.\r\nParameter name: results");
        }

        [TestCase(ResultType.Fizz)]
        [TestCase(ResultType.Buzz)]
        [TestCase(ResultType.FizzBuzz)]
        [TestCase(ResultType.Lucky)]
        [TestCase(ResultType.Number)]
        public void Report_WhenSingleResult_ReturnsCorrectCount(ResultType resultType)
        {
            const int number = 0;
            var input = new List<Result> {new Result(resultType, number)};
            var results = _reporter.Report(input);

            results.Count.Should().Be(5);

            var result = results.Single(_ => _.ResultType == resultType);
            result.Count.Should().Be(1);
        }

        [Test]
        public void Report_WhenRangeOfNumbersPassedIn_ReturnsResultForEach()
        {
            const int number = 0;
            var input = new List<Result>
            {
                new Result(ResultType.Number, number),
                new Result(ResultType.Number, number),
                new Result(ResultType.Lucky, number),
                new Result(ResultType.Number, number),
                new Result(ResultType.Buzz, number),
                new Result(ResultType.Fizz, number),
                new Result(ResultType.Number, number),
                new Result(ResultType.Number, number),
                new Result(ResultType.Fizz, number),
                new Result(ResultType.Buzz, number),
                new Result(ResultType.Number, number),
                new Result(ResultType.Fizz, number),
                new Result(ResultType.Lucky, number),
                new Result(ResultType.Number, number),
                new Result(ResultType.FizzBuzz, number),
            };

            var results = _reporter.Report(input);

            results.Count.Should().Be(5);

            CheckResult(results, ResultType.Fizz, 3);
            CheckResult(results, ResultType.Buzz, 2);
            CheckResult(results, ResultType.FizzBuzz, 1);
            CheckResult(results, ResultType.Lucky, 2);
            CheckResult(results, ResultType.Number, 7);
        }

        private static void CheckResult(IList<ResultTypeCount> results, ResultType resultType, int count)
        {
            var result = results.Single(_ => _.ResultType == resultType);
            result.Count.Should().Be(count);
        }
    }
}