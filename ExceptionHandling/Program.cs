namespace ExceptionHandling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            // change development/production mode from 
            // solution > properties > Debug > Open Debug Lunch profile UI > ASPNETCORE_ENVIRONMENT = Development/Production
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(options => 
                {
                    options.Run(async context =>
                    {
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "application/json";

                        var errorResponse = new
                        {
                            message = "An unexpected error occurred. Please try again later.",
                            errorCode = "500"
                        };

                        await context.Response.WriteAsJsonAsync(errorResponse);

                    });
                });
            }

            // to test
            // http://localhost:5015/api/demo/triggerError


            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}