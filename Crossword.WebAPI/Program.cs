using Application;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddMediatR(typeof(CrosswordHandler));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(/*x => x.AllowAnyOrigin()*/);

app.MapGet("/newGame", async (IMediator mediator, int? wordsCount) =>
{
    var game = await mediator.Send(new CrosswordRequest(wordsCount ?? 30));

    return game is not null ? Results.Ok(game) : Results.BadRequest();
})
.WithName("New Game");

app.Run();