using Serilog.Core;
using Serilog.Events;

namespace ECommerceAPI.API.Configurations.ColumnWriters
{
    public class CustomUserNameColumn : ILogEventEnricher

    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var (username, value) = logEvent.Properties.FirstOrDefault(x => x.Key == "user_name");
            if (value != null)
            {
                var getValue = propertyFactory.CreateProperty(username, value);
                logEvent.AddPropertyIfAbsent(getValue);
            }
        }
    }
}
