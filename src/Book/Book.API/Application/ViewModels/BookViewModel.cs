using System.ComponentModel.DataAnnotations;

namespace Book.API.Application.ViewModels;

public record BookViewModel
(
    [property: Required] Guid Id,
    [property: Required] string Title,
    string? Description,
    [property: Required] DateTime Year,
    [property: Required] BookAuthorViewModel Author,
    [property: Required] BookPublishingHouseViewModel PublishingHouse
);

public record BookAuthorViewModel
(
    [property: Required] Guid Id,
    [property: Required] string FullName
);

public record BookPublishingHouseViewModel
(
    [property: Required] Guid Id,
    [property: Required] string Name
);
