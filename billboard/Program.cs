using billboard.BillboardMappers;
using billboard.Context;
using billboard.Repositories;
using billboard.services;
using billboard.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<BilllboardDBContext>(options => options.UseSqlServer(conString));



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//                            Add Rep
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>();
builder.Services.AddScoped<IDocumentRepository, DocumentRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
builder.Services.AddScoped<IIndustryRepository, IndustryRepository>();
builder.Services.AddScoped<IPayMethodRepository, PayMethodRepository>();
builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<IUserTypePermissionsRepository, UserTypePermissionsRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IBillboardRepository, BillboardRepository>();
builder.Services.AddScoped<IBillboardStateRepository, BillboardStateRepository>();
builder.Services.AddScoped<IBillboardTypeRepository, BillboardTypeRepository>();
builder.Services.AddScoped<ITenantRepository, TenantRepository>();
builder.Services.AddScoped<ILessorRepository, LessorRepository>();
builder.Services.AddScoped<IResponsibleRepository, ResponsibleRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();

// Add Services 
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IDocumentService, DocumentService>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<IIndustryService, IndustryService>();
builder.Services.AddScoped<IPayMethodService, PayMethodService>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();
builder.Services.AddScoped<IUserTypePermissionsService, UserTypePermissionsService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IBillboardService, BillboardService>();
builder.Services.AddScoped<IBillboardStateService, BillboardStateService>();
builder.Services.AddScoped<IBillboardTypeService, BillboardTypeService>();
builder.Services.AddScoped<ITenantService, TenantService>();
builder.Services.AddScoped<ILessorService, LessorService>();
builder.Services.AddScoped<IResponsibleService, ResponsibleService>();
builder.Services.AddScoped<IRentalService, RentalService>();

// Add Mapper
builder.Services.AddAutoMapper(typeof(BillboardMaper));  
var app = builder.Build();

// Configure the HTTP request pipeline.


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
