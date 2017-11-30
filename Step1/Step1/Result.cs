namespace Step1
{
    public class Result
    {
        public ResultType ResultType { get; }
        public int Number { get; }

        public Result(ResultType resultType, int number)
        {
            ResultType = resultType;
            Number = number;
        }
    }
}