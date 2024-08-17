using Investment.Application.UseCases.RunCalculate;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Investment.Application
{
    public class RunCalculateHandler : IRequestHandler<RunCalculateCommand, RunCalculateResponse>
    {
        public Task<RunCalculateResponse> Handle(RunCalculateCommand request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
