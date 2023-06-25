using NHibernate.Mapping.ByCode;
using NHibernate;
using NHibernate.Cfg;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace adstaskhub_api.Data
{
    public class NHibernateConfig
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    var configuration = new Configuration();

                    // Configurar a leitura do arquivo appsettings.json
                    var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");

                    var config = builder.Build();

                    // Obter a string de conexão do arquivo appsettings.json
                    var connectionString = config.GetConnectionString("DefaultConnection");

                    configuration.DataBaseIntegration(db =>
                    {
                        db.ConnectionString = connectionString;
                        db.Dialect<NHibernate.Dialect.PostgreSQLDialect>();
                    });

                    var modelMapper = new ModelMapper();
                    modelMapper.AddMappings(typeof(NHibernateConfig).Assembly.GetExportedTypes());
                    var mapping = modelMapper.CompileMappingForAllExplicitlyAddedEntities();
                    configuration.AddDeserializedMapping(mapping, null);

                    _sessionFactory = configuration.BuildSessionFactory();
                }

                return _sessionFactory;
            }
        }
    }
}
