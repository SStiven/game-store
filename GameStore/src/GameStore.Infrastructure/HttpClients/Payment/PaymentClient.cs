using System.Net;
using System.Net.Http.Json;
using System.Text.Json;

using ErrorOr;

using GameStore.Application.Common.Interfaces;

namespace GameStore.Infrastructure.HttpClients.Payment;

public class PaymentClient(HttpClient httpClient) : IPaymentClient
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ErrorOr<DateTimeOffset>> MakeIBoxTerminalPaymentAsync(Guid userId, double amount)
    {
        var request = new PayWithIBoxTerminalRequest(userId, amount);
        var response = await _httpClient.PostAsJsonAsync("/ibox-terminal", request);
        if (response.IsSuccessStatusCode)
        {
            using var contentStream = await response.Content.ReadAsStreamAsync();
            var payResponse = await JsonSerializer.DeserializeAsync<PayWithIBoxTerminalResponse>(contentStream);
            return payResponse.PaymentDate;
        }

        return response.StatusCode == HttpStatusCode.BadRequest
            ? Error.Validation(description: "Invalid ibox terminal information")
            : Error.Unexpected(description: "Internal Server Error");
    }
}
