using Ecommerce.Application.UseCases.Images.Common;
using FluentResults;
using MediatR;

namespace Ecommerce.Application.UseCases.Images.Commands;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
public class CreateImageCommand : IRequest<Result<ImageResult>>
{
  public string Base64 { get; set; }
  public string FileType { get; set; }
  public string? FileName { get; set; } = null;
  public long? FileSize { get; set; } = null;
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider adding the 'required' modifier or declaring as nullable.
