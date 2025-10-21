
using WebApiNTT.Services;

namespace WebApiNTT
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddControllers();
            
            builder.Services.AddHttpClient<PersonaService>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //AdicionarCors en caso de incluir otras fuentes de consumo
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigins", p => 
                p.WithOrigins(
                "http://localhost:5173"
                )
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

            var app = builder.Build();

            //Se comenta el swagger para prevenir en despliegue
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseCors("AllowOrigins");

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
