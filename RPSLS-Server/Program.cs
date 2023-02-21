using RPSLS_Server.Providers;
using RPSLS_Server.Services.Scoreboard;
using RpslsServer.Mapper;
using RpslsServer.Models;
using RpslsServer.Models.Dto;
using RpslsServer.Options;
using RpslsServer.Services.Game;
using RpslsServer.Services.RandomNumberService;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer(); //No need because we're not using minimal API endpoints
builder.Services.AddSwaggerGen();

builder.Services.AddOptions<RandomNumberServiceOptions>().BindConfiguration(RandomNumberServiceOptions.RandomNumberService);
builder.Services.AddOptions<ScoreboardOptions>().BindConfiguration(ScoreboardOptions.Scoreboard);

builder.Services.AddHttpClient<IRandomNumberService, RandomNumberService>();
builder.Services.AddSingleton<IMapper<GameResult, GameResultDto>, GameResultMapper>();
builder.Services.AddSingleton<IMapper<int, Gesture>, RandomNumberMapper>();
builder.Services.AddSingleton<IMapper<GameResult, ScoreboardEntry>, ScoreboardEntryMapper>();
builder.Services.AddSingleton<IMapper<ScoreboardEntry, ScoreboardEntryDto>, ScoreboardEntryDtoMapper>();

builder.Services.AddSingleton<IGameManagerService, GameManagerService>();
builder.Services.Decorate<IGameManagerService, ScoreBoardGameManagerService>();

builder.Services.AddSingleton<IGameRulesProvider, GameRulesProvider>();
builder.Services.AddSingleton<IScoreboardProvider, ScoreboardProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();
