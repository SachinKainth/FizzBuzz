using System;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Step1.Tests
{
    [TestFixture]
    class SolutionTests
    {
        private Solution _solution;

        [SetUp]
        public void Setup()
        {
            _solution = new Solution();
        }

        [Test]
        public void FizzBuzz_StartNumberGreaterThanEndNumber_ThrowsException()
        {
            Action a = () =>_solution.FizzBuzz(2, 1);

            a.ShouldThrow<ArgumentException>().WithMessage("The starting point cannot be greater than the ending point.");
        }

        [Test]
        public void FizzBuzz_StartNumberEqualToEndNumber_DoesntThrowException()
        {
            Action a = () => _solution.FizzBuzz(1, 1);

            a.ShouldNotThrow<ArgumentException>();
        }

        [TestCase(3)]
        [TestCase(6)]
        [TestCase(9)]
        [TestCase(12)]
        [TestCase(18)]
        public void FizzBuzz_WhenNumberOnlyDivisibleBy3_ReturnsFizz(int start)
        {
            ExecuteAndCheckResult(start, ResultType.Fizz);
        }
        
        [TestCase(5)]
        [TestCase(10)]
        [TestCase(20)]
        [TestCase(25)]
        [TestCase(35)]
        public void FizzBuzz_WhenNumberOnlyDivisibleBy5_ReturnsBuzz(int start)
        {
            ExecuteAndCheckResult(start, ResultType.Buzz);
        }

        [TestCase(15)]
        [TestCase(30)]
        [TestCase(45)]
        public void FizzBuzz_WhenNumberDivisibleBy3And5_ReturnsFizzBuzz(int start)
        {
            ExecuteAndCheckResult(start, ResultType.FizzBuzz);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(4)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(11)]
        [TestCase(13)]
        [TestCase(14)]
        public void FizzBuzz_WhenNumberNotDivisibleBy3Or5_ReturnsNumber(int start)
        {
            ExecuteAndCheckResult(start, ResultType.Number);
        }

        [Test]
        public void FizzBuzz_WhenRangeOfNumbersPassedIn_ReturnsResultForEach()
        {
            const int start = 1;
            const int end = 15;
            var results = _solution.FizzBuzz(start, end);

            results.Count.Should().Be(end);

            ExecuteAndCheckResult(results, 1, ResultType.Number);
            ExecuteAndCheckResult(results, 2, ResultType.Number);
            ExecuteAndCheckResult(results, 3, ResultType.Fizz);
            ExecuteAndCheckResult(results, 4, ResultType.Number);
            ExecuteAndCheckResult(results, 5, ResultType.Buzz);
            ExecuteAndCheckResult(results, 6, ResultType.Fizz);
            ExecuteAndCheckResult(results, 7, ResultType.Number);
            ExecuteAndCheckResult(results, 8, ResultType.Number);
            ExecuteAndCheckResult(results, 9, ResultType.Fizz);
            ExecuteAndCheckResult(results, 10, ResultType.Buzz);
            ExecuteAndCheckResult(results, 11, ResultType.Number);
            ExecuteAndCheckResult(results, 12, ResultType.Fizz);
            ExecuteAndCheckResult(results, 13, ResultType.Number);
            ExecuteAndCheckResult(results, 14, ResultType.Number);
            ExecuteAndCheckResult(results, 15, ResultType.FizzBuzz);
        }

        private static void ExecuteAndCheckResult(IList<Result> results, int number, ResultType resultType)
        {
            var result = results[number-1];
            result.ResultType.Should().Be(resultType);
            result.Number.Should().Be(number);
        }

        private void ExecuteAndCheckResult(int start, ResultType resultType)
        {
            var results = _solution.FizzBuzz(start, start);

            results.Count.Should().Be(1);

            var result = results[0];
            result.ResultType.Should().Be(resultType);
            result.Number.Should().Be(start);
        }
    }
}