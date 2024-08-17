using Investment.Domain.DTO;

namespace Investment.API.Models
{
    public class CalculateCDBResponse
    {
        public decimal GrossAmount { get; }
        public decimal NetAmount { get; }

        public CalculateCDBResponse(CalculateCDBResult result)
        {
            GrossAmount = result.GrossAmount;
            NetAmount = result.NetAmount;
        }
    }
}