//Todo comienza aqui

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

//Configuracion de las rutas
//Si no se encuentra la ruta o accion, se ejecuta la accion Index del controlador Home
app.MapControllerRoute(
    name: "default", //Por defecto
    pattern: "{controller=Home}/{action=Index}/{id?}") //Controlador Home y accion Index por defecto con id opcional, por eso el "?"
    .WithStaticAssets();


app.Run();
