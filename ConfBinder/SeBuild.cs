using Microsoft.Extensions.Configuration;
using System.Diagnostics;

namespace ConfBinder
{
    public class SeBuild
    {
        public IConfiguration _con;

        public SeBuild()
        {
            _con = new ConfigurationBuilder()
                .AddJsonFile("DeviceMapper.config.json", optional: false, reloadOnChange: false)
                .Build();

            var positionOptions = new PositionOptions();
            _con.GetSection(PositionOptions.Position).Bind(positionOptions);

            Debug.WriteLine("#################");
            Debug.WriteLine(positionOptions.Name);
        }
    }

    public class PositionOptions
    {
        public class PositionParameter
        {
            public string Port { get; set; } = String.Empty;
            public string Address { get; set; } = String.Empty;
        }

        public const string Position = "Position";

        public string Title { get; set; } = String.Empty;
        public string Name { get; set; } = String.Empty;

        public List<string>? Devs { get; set; }

        public PositionParameter? Param { get; set; }
    }
}