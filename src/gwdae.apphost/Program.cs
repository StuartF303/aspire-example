using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var grpcService = builder.AddProject<gwdae.grpcservice>("grpcservice");

builder.AddProject<gwdae.web>("webui")
    .WithReference(grpcService);



builder.Build().Run();
