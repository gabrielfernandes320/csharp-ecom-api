namespace Domain.Users.Dtos;

public record FindUserResponseDto(Guid Id, string Name, string Email, DateTime CreatedAt);