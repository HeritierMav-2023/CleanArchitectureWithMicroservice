using MediatR;
using Microsoft.Extensions.Logging;


namespace Student.Application.Behavior
{
    public class LogginBehavior<TRequest, TReponse> : IPipelineBehavior<TRequest, TReponse>
              where TRequest : IRequest<TReponse>
    {

        private readonly ILogger<LogginBehavior<TRequest, TReponse>> _logger;

        public LogginBehavior(ILogger<LogginBehavior<TRequest, TReponse>> logger)
        {
            _logger = logger;
        }
        public async Task<TReponse> Handle(TRequest request, RequestHandlerDelegate<TReponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling {typeof(TRequest).Name}");

            var reponse = await next();

            _logger.LogInformation($"Handled {typeof(TReponse).Name}");

            return reponse;
        }
    }
}
