using System;
using System.Collections.Generic;
using System.Linq;

namespace Step3
{
    public class Reporter
    {
        public IList<ResultTypeCount> Report(IList<Result> results)
        {
            if (results == null)
            {
                throw new ArgumentNullException(nameof(results));
            }

            var resultTypes = Enum.GetValues(typeof(ResultType)).Cast<ResultType>();

            var resultTypeCounts = new List<ResultTypeCount>();

            foreach (var resultType in resultTypes)
            {
                var count = results.Count(_ => _.ResultType == resultType);

                resultTypeCounts.Add(new ResultTypeCount(resultType, count));
            }

            return resultTypeCounts;
        }
    }
}