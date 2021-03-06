﻿using System;
using System.Collections.Generic;

namespace Step3
{
    public class Solution
    {
        private const string LuckyNumber = "3";

        public IList<Result> FizzBuzz(int start, int end)
        {
            if (start > end)
            {
                throw new ArgumentException("The starting point cannot be greater than the ending point.");
            }

            var results = new List<Result>();
            
            for (var i = start; i <= end; i++)
            {
                var divisibleBy3 = i % 3 == 0;
                var divisibleBy5 = i % 5 == 0;
                var resultType = ResultType.Number;

                if (divisibleBy3)
                {
                    resultType = ResultType.Fizz;
                }
                if (divisibleBy5)
                {
                    resultType = ResultType.Buzz;
                }
                if (divisibleBy3 && divisibleBy5)
                {
                    resultType = ResultType.FizzBuzz;
                }
                if (i.ToString().Contains(LuckyNumber))
                {
                    resultType = ResultType.Lucky;
                }

                results.Add(new Result(resultType, i));
            }

            return results;
        }
    }
}