namespace Step3
{
    public class ResultTypeCount
    {
        public ResultType ResultType { get; }
        public int Count { get; }

        public ResultTypeCount(ResultType resultType, int count)
        {
            ResultType = resultType;
            Count = count;
        }
    }
}