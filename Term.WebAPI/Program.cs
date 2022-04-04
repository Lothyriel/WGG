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

app.UseCors(/*x => x.AllowAnyOrigin()*/);

app.MapGet("/randomTerm", async (IMediator mediator, int? count) =>
{
    var terms = await mediator.Send(new TermRequest(count ?? 1));

    return terms is not null ? Results.Ok(terms) : Results.BadRequest();
})
.WithName("Random term");

app.MapPost("/addTerm", async (IMediator mediator, Term term) =>
{
    var result = await mediator.Send(new AddTermRequest(term));

    return result ? Results.Ok("Word Added!") : Results.Conflict("Word already defined!");
})
.WithName("Add Term");

app.Run();