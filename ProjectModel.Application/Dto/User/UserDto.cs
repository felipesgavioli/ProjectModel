using System.Text.Json.Serialization;

namespace ProjectModel.Application.Dto.User
{
    public class UserDto
    {
        public UserDto(int id, string name, string email, string password)
        {
            Id = id;
            Name = name;
            Email = email;
            Password = password;
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        public static UserDto MapFromDomain(Domain.User entity)
        {
            var customerViewModel = new UserDto(
                entity.Id,
                entity.Name,
                entity.Email,
                entity.Password
            );
            return customerViewModel;
        }

        public static IEnumerable<UserDto> MapFromDomain(IList<Domain.User> entity)
        {
            foreach (var item in entity)
            {
                yield return MapFromDomain(item);
            }
        }
    }
}