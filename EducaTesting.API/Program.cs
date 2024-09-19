using EducaTesting.Application.Courses;
using EducaTesting.Persistence;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<EducaTestingDbContext>(op =>
{
    op.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddMediatR(typeof(GetCourseQuery.GetCourseQueryHandler).Assembly);

builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<CreateCourseCommand>());

builder.Services.AddAutoMapper(typeof(GetCourseQuery.GetCourseQueryHandler));

builder.Services.AddCors(o => o.AddPolicy("corsApp", builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

builder.Services.AddControllers();

var app = builder.Build();
app.UseCors("corsApp");

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

