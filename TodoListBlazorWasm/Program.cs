using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoListBlazorWasm;
using TodoListBlazorWasm.Sevices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddTransient<ITaskApiClient,TaskApiClient>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7214") });

await builder.Build().RunAsync();
