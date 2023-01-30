using MediatR;
using Microsoft.Extensions.Logging;
using PosTerminal.Net.Application.Models.Common;

namespace PosTerminal.Net.Application.Common;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TResponse : class where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
    {
        _logger = logger;
    }


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            var response = await next();
            return response;
        }
        catch (Exception e)
        {
            _logger.LogError(exception: e, message: e.Message);

            if (typeof(TResponse).GetGenericTypeDefinition() == typeof(OperationResult<>))
            {
                var response = new OperationResult<TResponse> { IsException = true };
                #pragma warning disable 8603
                return response as TResponse;
                #pragma warning restore
            }

            throw;
        }
    }
}