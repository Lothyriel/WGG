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

app.UseHttpsRedirection();
app.UseCors(/*x => x.AllowAnyOrigin()*/);

app.MapGet("/newGame", async (IMediator mediator) =>
{
    return await mediator.Send(new CrosswordRequest());
})
.WithName("New Game");

app.Run();