using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// builder.Services.AddScoped<Supabase.Client>(_ => new Supabase.Client(
//     builder.Configuration["https://sfkewboncxzexcxcayhb.supabase.co"]!,
//     builder.Configuration["sb_publishable_0SQgPOUraYx3AzLx1CKQcw_LlUs9qV4"]!,
//     new SupabaseOptions
//     {
//         AutoRefreshToken = true,
//         AutoConnectRealtime = true
//     }   
// ));

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("AllowAll");
app.UseStaticFiles();
app.MapControllers();
app.Run();