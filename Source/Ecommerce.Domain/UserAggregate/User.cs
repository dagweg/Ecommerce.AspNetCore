namespace Ecommerce.Domain.UserAggregate;

using System.ComponentModel.DataAnnotations.Schema;
using Ecommerce.Domain.Common.Entities;
using Ecommerce.Domain.Common.Errors;
using Ecommerce.Domain.Common.Models;
using Ecommerce.Domain.Common.ValueObjects;
using Ecommerce.Domain.NotificationAggregate;
using Ecommerce.Domain.OrderAggregate;
using Ecommerce.Domain.OrderAggregate.ValueObjects;
using Ecommerce.Domain.ProductAggregate;
using Ecommerce.Domain.ProductAggregate.Entities;
using Ecommerce.Domain.UserAggregate.Entities;
using Ecommerce.Domain.UserAggregate.Events;
using Ecommerce.Domain.UserAggregate.ValueObjects;
using FluentResults;

public class User : AggregateRoot<UserId>
{
  public Name FirstName { get; private set; }
  public Name LastName { get; private set; }
  public Email Email { get; private set; }
  public Password Password { get; private set; }
  public PhoneNumber PhoneNumber { get; private set; }
  public UserAddress? Address { get; private set; }
  public Wishlist Wishlist { get; private set; }
  public Cart Cart { get; private set; }
  public BillingAddress? BillingAddress { get; private set; }
  public bool AccountVerified { get; set; }

  private List<Order> _orders = [];
  private List<Product> _products = [];
  private List<Notification> _notifications = [];
  public IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
  public IReadOnlyCollection<Product> Products => _products.AsReadOnly();
  public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();

  public OneTimePassword? EmailVerificationOtp { get; private set; }
  public OneTimePassword? PasswordResetOtp { get; private set; }

  public Image? ProfileImage { get; private set; }

  protected User(
    UserId id,
    Name firstName,
    Name lastName,
    Email email,
    Password password,
    PhoneNumber phoneNumber
  )
    : base(id)
  {
    FirstName = firstName;
    LastName = lastName;
    Email = email;
    Password = password;
    PhoneNumber = phoneNumber;
    Cart = Cart.Create();
    Wishlist = Wishlist.Create();
  }

  public static User Create(
    Name firstName,
    Name lastName,
    Email email,
    Password password,
    PhoneNumber phoneNumber
  )
  {
    var user = new User(UserId.CreateUnique(), firstName, lastName, email, password, phoneNumber);

    user.EmailVerificationOtp = OneTimePassword.CreateNew(); // first time

    user.AddDomainEvent(new UserCreatedDomainEvent(user));

    return user;
  }

  public User WithUserId(UserId userId)
  {
    base.Id = userId;
    return this;
  }

  public User WithAddress(UserAddress address)
  {
    Address = address;
    return this;
  }

  public User WithWishlist(Wishlist wishlist)
  {
    Wishlist = wishlist;
    return this;
  }

  public User WithCart(Cart cart)
  {
    Cart = cart;
    return this;
  }

  public User WithOrders(List<Order> orders)
  {
    _orders = orders;
    return this;
  }

  public User WithProducts(List<Product> products)
  {
    _products = products;
    return this;
  }

  public User WithNotifications(List<Notification> notifications)
  {
    _notifications = notifications;
    return this;
  }

  public User WithBillingAddress(BillingAddress billingAddress)
  {
    BillingAddress = billingAddress;
    return this;
  }

  public User WithAccountVerified(bool accountVerified)
  {
    AccountVerified = accountVerified;
    return this;
  }

  public User WithEmailVerificationOtp(OneTimePassword emailVerificationOtp)
  {
    EmailVerificationOtp = emailVerificationOtp;
    return this;
  }

  public User WithPasswordResetOtp(OneTimePassword passwordResetOtp)
  {
    PasswordResetOtp = passwordResetOtp;
    return this;
  }

  public User WithHashedPassword(string hashedPassword)
  {
    Password.ValueHash = hashedPassword;
    return this;
  }

  public void ChangePassword(Password newPassword)
  {
    Password = newPassword;
  }

  public User WithProfileImage(Image profileImage)
  {
    ProfileImage = profileImage;
    return this;
  }

  /// <summary>
  /// Sets the email verification OTP for the user. Pass in null to revoke otp.
  /// </summary>
  /// <param name="oneTimePassword"></param>
  public void SetEmailVerificationOtp(int[]? oneTimePassword = null)
  {
    EmailVerificationOtp?.SetValue(oneTimePassword);
    if (oneTimePassword is not null) // if its not null we'll assume its a resend attempt
    {
      EmailVerificationOtp?.AddResendDelay();
    }
  }

  /// <summary>
  /// Sets the password reset OTP for the user. Pass in null to revoke otp.
  /// </summary>
  /// <param name="oneTimePassword"></param>
  public void SetPasswordResetOtp(OneTimePassword? oneTimePassword)
  {
    PasswordResetOtp = oneTimePassword;
  }

  public Result VerifyEmail(OneTimePassword otp)
  {
    if (EmailVerificationOtp is null)
    {
      return InvalidOtpError.GetResult(nameof(otp), "OTP is not issued");
    }

    var result = EmailVerificationOtp.Validate(otp);

    if (result.IsFailed)
      return result;

    EmailVerificationOtp = null;
    AccountVerified = true;
    return Result.Ok();
  }

  public Result VerifyPasswordResetOtp(OneTimePassword otp)
  {
    if (PasswordResetOtp is null)
    {
      return InvalidOtpError.GetResult(nameof(otp), "Otp not issued");
    }

    var result = PasswordResetOtp.Validate(otp);

    if (result.IsFailed)
      return result;

    PasswordResetOtp = null;
    return Result.Ok();
  }

  public override IEnumerable<object> GetEqualityComponents()
  {
    yield return Id;
  }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
  private User()
    : base(UserId.CreateUnique()) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
}
