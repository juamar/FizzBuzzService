namespace FizzBuzzService.Models
{
    public class FizzBuzzResult : FizzBuzzRequest
    {
        public string? FizzBuzzString { get; set; } = "";

        public FizzBuzzResult(){ }

        public FizzBuzzResult(FizzBuzzRequest baseFizzBuzzRequest)
        {
            this.LimitNumber = baseFizzBuzzRequest.LimitNumber;
            this.StartRamdomNumber = baseFizzBuzzRequest.StartRamdomNumber;
        }

        public FizzBuzzResult(FizzBuzzRequest baseFizzBuzzRequest, string fizzBuzzString)
        {
            this.LimitNumber = baseFizzBuzzRequest.LimitNumber;
            this.StartRamdomNumber = baseFizzBuzzRequest.StartRamdomNumber;
            this.FizzBuzzString = fizzBuzzString;
        }
    }
}
