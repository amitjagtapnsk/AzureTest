var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var AllowSpecificOrigin = "_AllowSpecificOrigin";
builder.Services.AddCors(options => {
    options.AddPolicy(name:AllowSpecificOrigin, policy =>
    {
        //policy.WithOrigins("http://localhost:7038");
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(AllowSpecificOrigin);

app.UseAuthorization();

app.MapControllers();

app.Run();
