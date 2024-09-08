using Utils;

var builder = WebApplication.CreateBuilder(args);

// injection kebutuhan service 
builder.Services.ConfigureSqlContext(builder.Configuration); // Tambahkan ini untuk dbRmTools_Context
builder.Services.ConfigureSqlContext2(builder.Configuration);
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureCors(); //inisiasi cors
builder.Services.AddControllers();
builder.Services.ConfigureSwagger("Api");
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();
