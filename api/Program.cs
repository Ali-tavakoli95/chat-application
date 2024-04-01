using api;
using api.Hub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddSingleton<IDictionary<string, UserRoomConnection>>(IServiceProvider =>
        new Dictionary<string, UserRoomConnection>());

var app = builder.Build();

app.UseEndpoints(endpoint =>
{
    endpoint.MapHub<ChatHub>(pattern: "/chat");
});

app.Run();

