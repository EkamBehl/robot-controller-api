using robot_controller_api.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
//builder.Services.AddScoped<IRobotCommandDataAccess,RobotCommandRepository>();
//builder.Services.AddScoped<IMapDataAccess, MapRepository>();
//builder.Services.AddScoped<IRobotCommandDataAccess, RobotCommandADO>();
//builder.Services.AddScoped<IMapDataAccess, MapADO>();

//For 3.4HD
builder.Services.AddScoped<IRobotCommandDataAccess,RobotCommandEF>();
builder.Services.AddScoped<IMapDataAccess, MapEF>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
