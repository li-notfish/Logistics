var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Logistics_Core>("logistics-core");
builder.AddProject<Projects.Logistics_Web>("logistics-web");
builder.Build().Run();
