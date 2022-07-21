using Microsoft.EntityFrameworkCore;
using NoticiasApi.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDbContext<NoticiaDbContext>(opt => {
    opt.UseSqlServer(builder.Configuration.GetConnectionString("newsString"));
});
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.MapGet("/", () => "Hello World!");
app.MapGet("/News", async (NoticiaDbContext db) => await db.NewsBlogs.ToListAsync());
app.MapGet("/NewsComplete/{Id}", async (NoticiaDbContext db, int Id)=> 
    await db.NewsBlogs.FindAsync(Id)
    is NewsBlog news
    ? Results.Ok(news)
    : Results.NotFound());

app.MapPost("/NewsComplete/{Id}", async(NoticiaDbContext db, NewsBlog nblog) =>{
    db.NewsBlogs.Add(nblog);
    await db.SaveChangesAsync();
    return Results.Created($"/NewsComplete/{nblog.Id}", nblog.Id);
});
app.Run();
