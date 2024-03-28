
//using HealthFundCoronaSystemServer.Store;
//using Microsoft.OpenApi.Models;
//using System.Reflection;

//var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
//var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(MyAllowSpecificOrigins,
//                          policy =>
//                          {
//                              policy.WithOrigins("http://example.com",
//                                                  "http://www.contoso.com")
//                              .AllowAnyOrigin()
//                                                  .AllowAnyHeader()
//                                                  .AllowAnyMethod();
//                          });
//});
//builder.Services.AddControllers();

//// Register stores and any other dependencies
//builder.Services.AddScoped<MemberStore>();
//builder.Services.AddScoped<CoronaStatusStore>();
//builder.Services.AddScoped<DailyActivePatientsStore>();
//builder.Services.AddScoped<MemberPhotoStore>();
//builder.Services.AddScoped<VaccinationStore>();

//// Swagger/OpenAPI configuration
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthFundCoronaSystemServer", Version = "v1" }); // Corrected

//    //// Optional: Set up XML comments for Swagger UI, if you're using them
//    //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
//    //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
//    //c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true); // Ensure XML file exists
//});

//var app = builder.Build();

////configure the http request pipeline.
////if (app.environment.isdevelopment())
////{
////    app.use developerexceptionpage();
////    app.use swagger();
////}
//    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthFundCoronaSystemServer v1")); // Ensure path matches


//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();
//app.UseCors(MyAllowSpecificOrigins);

//app.Run();
using HealthFundCoronaSystemServer.Store;
using Microsoft.OpenApi.Models;
using System.Reflection;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
// Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://example.com", "http://www.contoso.com")
                                .AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});

// Add controllers
builder.Services.AddControllers();

// Register stores and other dependencies
builder.Services.AddScoped<MemberStore>();
builder.Services.AddScoped<CoronaStatusStore>();
builder.Services.AddScoped<DailyActivePatientsStore>();
builder.Services.AddScoped<MemberPhotoStore>();
builder.Services.AddScoped<VaccinationStore>();

// Swagger/OpenAPI configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthFundCoronaSystemServer", Version = "v1" });

    // Optional: Set up XML comments for Swagger UI, if you're using them
    // Ensure the XML file exists and is correctly linked in your project settings if you uncomment this
    /*
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);
    */
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthFundCoronaSystemServer v1"));
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseCors(MyAllowSpecificOrigins);
app.Run();


