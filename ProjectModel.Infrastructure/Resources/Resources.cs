using Microsoft.Extensions.Localization;

namespace ProjectModel.Infrastructure.Resources
{
    public class Resources : IResources
    {
        private readonly IStringLocalizer<Resources> _localizer;

        public Resources(IStringLocalizer<Resources> localizer)
        {
            _localizer = localizer;
        }

        public string UserIDNotFound(int id = default)
        {
            return string.Format(_localizer["UserIDNotFound"], id);
        }

        //public string GetUserNotFound => _localizer["GetUserNotFound"];

        public string UpdateUserNotFound => _localizer["UpdateUserNotFound"];

        public string InternalServerError => _localizer["InternalServerError"];

        public string BadRequest => _localizer["BadRequest"];

        public string Unauthorized => _localizer["Unauthorized"];
    }
}