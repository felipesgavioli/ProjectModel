using System.Text.Json.Serialization;

namespace ProjectModel.Application.Dto.User
{
    public record class UserDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        public static UserDto FromDomain(Domain.User entity) =>
            new UserDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password
            };

        public static IEnumerable<UserDto> FromDomain(IEnumerable<Domain.User> users)
        {
            foreach (var user in users)
            {
                yield return FromDomain(user);
            }
        }
    }
}