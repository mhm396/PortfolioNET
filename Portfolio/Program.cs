//Todo comienza aqui

using Portfolio.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//Inyeccion de dependencias
//AddTransient: Se crea una nueva instancia cada vez que se solicita el servicio, si necesitamos comparir datos entre instancias usariasmo AddSingleton
//Y si necesitamos compartir datos entre otras instancias pero en el mismo http request, usar AddScoped
builder.Services.AddTransient<IProyectosRepositorio, ProyectosRepositorio>(); //Inyectamos el servicio ProyectosRepositorio en el contenedor de servicios, para que se pueda utilizar en los controladores
//up: Cuando se inyecta un servicio en el contenedor de servicios, se puede utilizar en cualquier controlador o clase que lo necesite, ejemplos abajo

/*builder.Services.AddTransient<ServicioTransitorio>(); //Cada instancia se generara cada vez que se solicite el servicio, por ejemplo en el controlador
builder.Services.AddScoped<ServicioDelimitado>(); //Cada instancia se generara una vez, pero si generamos dos instancias iguales tienen el mismo
builder.Services.AddSingleton<ServicioUnico>(); //Siempre es el mismo
*/
builder.Services.AddTransient<IEmailService, EmailService>();
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
