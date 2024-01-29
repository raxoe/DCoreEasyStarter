using EasyStarter.DataAccess;
using EasyStarter.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI for DBContext with connectionstring
//builder.Services.AddDbContext<DbShoppingContext>(options =>
//  options.UseSqlServer(builder.Configuration.GetConnectionString("DBShoppingConnectionString")));

//EFCore ErrorPage middleware for to detect and diagnose errors with Entity Framework Core migrations.
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
EFDependencyInjections.ConfigureServices(builder.Services, builder.Configuration);

//Repository Service Register
RepoDependencyInjections.ConfigureServices(builder.Services,builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Make DB to EnsureCreated, and Initize Default Data
using (var scope = app.Services.CreateScope())
{
    //    var services = scope.ServiceProvider;

    //    var context = services.GetRequiredService<SchoolContext>();
    //    context.Database.EnsureCreated();
    //    // DbInitializer.Initialize(context);

    EFDependencyInjections.MigrateDatabase(scope);

    //EFDependencyInjections.DbEnsureCreate(scope);
}

app.Run();
