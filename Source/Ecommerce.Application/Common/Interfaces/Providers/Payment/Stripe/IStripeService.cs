using Ecommerce.Domain.Common.Enums;
using Ecommerce.Domain.OrderAggregate.Entities;
using Ecommerce.Domain.PaymentAggregate.Enums;
using FluentResults;

namespace Ecommerce.Application.Common.Interfaces.Providers.Payment.Stripe;

public interface IStripeService
{
  Task<Result<CreateCheckoutSessionResult>> CreateCheckoutSessionAsync(
    CheckoutSessionRequest request
  );
}

public record CheckoutSessionRequest
{
  public List<OrderItemCheckout> lineItems { get; init; } = [];
  public PaymentMethod paymentMethod { get; init; }
  public PaymentMode paymentMode { get; init; }
}

public record OrderItemCheckout(string productName, int quantity, long amountInCents);

public record CreateCheckoutSessionResult(string sessionId, string redirectUrl);
