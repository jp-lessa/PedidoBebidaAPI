using Polly;
using Polly.Extensions.Http;

namespace PedidoBebidaAPI.Configuration
{
    public class Policies
    {
        public static IAsyncPolicy<HttpResponseMessage> ObterRetryPolicy()
        {
            return HttpPolicyExtensions
            .HandleTransientHttpError()
            .OrResult(response => !response.IsSuccessStatusCode)
            .WaitAndRetryAsync(
                retryCount: 3,
                sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(2),
                onRetry: (outcome, timespan, retryAttempt, context) =>
                {
                    Console.WriteLine($"[Tentativa {retryAttempt} - Retry] Erro ao chamar API externa: {outcome.Exception?.Message ?? outcome.Result?.ReasonPhrase}");
                });
        }
    }
}
