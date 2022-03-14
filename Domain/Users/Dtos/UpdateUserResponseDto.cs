namespace Domain.Users.Dtos;

public record UpdateUserResponseDto(Guid Id, string Name, string Email, DateTime UpdatedAt);