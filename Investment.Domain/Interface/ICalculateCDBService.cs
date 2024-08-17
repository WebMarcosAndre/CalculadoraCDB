using Investment.API.Models;
using Investment.Domain.DTO;

namespace Investment.Domain.Interface
{
    public interface ICalculateCDBService
    {
        CalculateCDBResult CalculateInvestment(CalculateCDBInput input);
    }
}
