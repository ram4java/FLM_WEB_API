using FLM_WEB_API.CalcService;
using FLM_WEB_API.Models;
using Microsoft.EntityFrameworkCore;
using SoapCore;
using SoapCore.ServiceModel;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddDbContext<LmsContext>(options => options.UseSqlServer("Data Source=localhost;Initial Catalog=LMS;Integrated Security=True;Encrypt=False;Trust Server Certificate=true;"));
builder.Services.AddSingleton<ICalcService, CalcServiceImpl>();
builder.Services.AddSoapCore();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // No trailing slash
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseCors("AllowAngularOrigins");
app.UseRouting();
app.UseAuthorization();

//below are the soap api end points
app.UseEndpoints(endpoints => {
    endpoints.UseSoapEndpoint<ICalcService>("/DigitalCalc.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
    endpoints.UseSoapEndpoint<ICalcService>("/ScientificCalc.asmx", new SoapEncoderOptions(), SoapSerializer.XmlSerializer);
});

app.MapControllers();

//below are the minimal api end points
app.MapGet("/SayHello", () => "Hello Developers!! Welcome to MinimalAPI");

app.MapGet("/GreetCaller", (string callerName) => "Hello "+callerName+"!! Welcome to MinimalAPI :: I have modified this api state");

app.MapGet("/GetSingleCourse", (LmsContext context, int id) => 
context.Coursemasters.FirstOrDefault(course=>course.Id == id)
//new Coursemaster("PythonFS", "Python FS with Django")
);

app.MapGet("/GetCourseList", (LmsContext context) => context.Coursemasters
    /*new List<Coursemaster>() {
        new Coursemaster("DotnetFS", "Dotnet FS with Microservices"),
        new Coursemaster("JavaFS", "Java FS with Microservices"),
        new Coursemaster("PythonFS", "Python FS with Django"),
        new Coursemaster("NewCourse","New State in courses api")
    } */    
);


app.Run();
