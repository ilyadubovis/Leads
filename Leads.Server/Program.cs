using Leads.Server.Data;
using Leads.Server.Repositories;
using Leads.Server.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLeadOrigins", policy =>
    {
        policy
        .WithOrigins("https://localhost:4201")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .SetIsOriginAllowed((x) => true)
        .AllowCredentials();
    });
});

// Add services to the container.
builder.Services.AddSingleton<InMemoryDBContext>();
builder.Services.AddSingleton<LeadSignalRHub>();

builder.Services.AddScoped<ILeadRepositiry, LeadRepository>();
builder.Services.AddScoped<ILeadService, LeadService>();

builder.Services.AddAutoMapper<LeadAutoMapperProfile>();

builder.Services.AddSignalR();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseCors("AllowLeadOrigins");

app.MapHub<LeadSignalRHub>("/leadhub");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
