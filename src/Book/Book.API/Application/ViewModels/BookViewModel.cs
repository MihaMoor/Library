using System.ComponentModel.DataAnnotations;

namespace Book.API.Application.ViewModels;

public record BookViewModel
(
    [property: Required] Guid Id,
    [property: Required] string Title,
    string? Description,
    [property: Required] DateTime Year,
    [property: Required] Guid AuthorId,
    [property: Required] Guid PublishingHouseId
);
