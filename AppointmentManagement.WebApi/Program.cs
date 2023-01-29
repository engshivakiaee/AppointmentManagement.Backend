using AppointmentManagement.WebApi;

var builder = WebApplication.CreateBuilder(args);
var app = builder.ConfigureServices().ConfigurePipeline();

await app.ResetDataBaseAsync();

app.Run();

