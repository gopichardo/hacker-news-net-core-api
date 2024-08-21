

using Domain.Entities;
using Microsoft.Extensions.Options;

namespace Infrastructure.Services
{
    public class TimeConverter(IOptions<AppSettings> _options) : ITimeConverter
    {
        private readonly AppSettings appSettings = _options.Value;

        public string DateTimeToString(DateTime date)
        {
            var isoDate = date.ToString(appSettings.DateFormat);
            return isoDate;
        }
    }
}