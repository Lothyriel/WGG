using Application;
using Domain;
using Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddMediatR(typeof(TermHandler));
builder.Services.AddDbContext<TermContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection")));
builder.Services.AddScoped<ITermRepository, TermRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(/*x => x.AllowAnyOrigin()*/);

app.MapGet("/randomTerm", async (IMediator mediator) =>
{
    return await mediator.Send(new TermRequest());
})
.WithName("Random term");

app.MapPost("/addTerm", async (IMediator mediator, Term term) =>
{
    var result = await mediator.Send(new AddTermRequest(term));

    return result ? Results.Ok(result) : Results.Conflict("Word already defined!");
})
.WithName("Add Term");

app.Run();