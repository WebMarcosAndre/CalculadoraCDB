namespace Investment.API.Models
{
    public class CalculateCDBRequest
    {
        public int TermInMonths { get; set; }

        public decimal InitialAmount { get; set; }

        public static explicit operator CalculateCDBInput(CalculateCDBRequest request)
        {
            return new CalculateCDBInput(
                request.InitialAmount,
                request.TermInMonths);
        }
    }
}