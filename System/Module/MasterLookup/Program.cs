using Utils;

var builder = WebApplication.CreateBuilder(args);

// injection kebutuhan service 
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureCors(); //inisiasi cors
builder.Services.ConfigureJwtToken(builder.Services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>(), builder.Configuration);
builder.Services.AddControllers();
builder.Services.ConfigureSwagger("Master Lookup");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSwagger();
app.UseSwaggerUI();

//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment()) // saya mau hanya proses development swagger dijalankan
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "local");
//        c.DocumentTitle = "Documentation";
//        c.DocExpansion(DocExpansion.None);
//    });
//}


app.UseCors("CorsPolicy"); //execute cors
app.MiddlewareCookies();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
