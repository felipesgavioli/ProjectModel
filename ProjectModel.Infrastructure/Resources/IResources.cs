namespace ProjectModel.Infrastructure.Resources
{
    public interface IResources
    {
        public string UserIDNotFound(int id = default);

        public string UpdateUserNotFound { get; }

        public string InternalServerError { get; }

        public string BadRequest { get; }

        public string Unauthorized { get; }
    }
}