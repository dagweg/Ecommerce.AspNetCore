using Ecommerce.Application.UseCases.Images.Commands;
using Ecommerce.Application.UseCases.Products.Common;
using FluentResults;
using MediatR;

namespace Ecommerce.Application.UseCases.Products.Commands;

public record CreateProductCommand(
  string ProductName,
  string ProductDescription,
  int StockQuantity,
  decimal PriceValue,
  string PriceCurrency,
  CreateImageCommand Thumbnail,
  CreateImageCommand? LeftImage = null,
  CreateImageCommand? RightImage = null,
  CreateImageCommand? FrontImage = null,
  CreateImageCommand? BackImage = null,
  List<string>? Tags = null
) : IRequest<Result<ProductResult>>;
