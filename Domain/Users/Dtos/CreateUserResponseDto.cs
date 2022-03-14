namespace Domain.Users.Dtos;

public record CreateUserResponseDto(Guid Id, string Name, string Email, DateTime CreatedAt);