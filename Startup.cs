using ApiPruebaTecnica.Business;
using ApiPruebaTecnica.Business.Interfaces;
using ApiPruebaTecnica.DB;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace ApiPruebaTecnica
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            string nombreEnsamblado = Assembly.GetExecutingAssembly().GetName().Name;
            string abreviacionAmbiente = Configuration["Configuration:environment"].ToLower();
            string connectionString = Configuration.GetConnectionString(String.Format("{0}{1}", abreviacionAmbiente, "ConexionSqlServer"));

            services.AddCors();
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = nombreEnsamblado, Version = "v1" });
                string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                string xmlFile = $"{nombreEnsamblado}.xml";
                string xmlPath = Path.Combine(baseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
            services.AddSingleton(connectionString);
            #region Scopeds
            services.AddScoped<IUsuarioBL, UsuarioBL>();

            #endregion

        }

        public void Configure(IApplicationBuilder app)
        {
            string nombreEnsamblado = Assembly.GetExecutingAssembly().GetName().Name;
            string abreviacionAmbiente = Configuration["Configuration:environment"].ToLower();

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint(
                string.Format("{0}{1}", abreviacionAmbiente == "local" ? String.Empty : abreviacionAmbiente, "/swagger/v1/swagger.json"),
                string.Format("{0} v1", nombreEnsamblado))
            );

            app.UseCors(options =>
            {
                options.AllowAnyMethod();
                options.AllowAnyHeader();
                options.AllowAnyOrigin();
            });

            app.UseDeveloperExceptionPage();
            app.UseHttpsRedirection();
            app.UseFileServer(enableDirectoryBrowsing: true);
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
