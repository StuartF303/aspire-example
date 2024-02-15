using Projects;

var builder = DistributedApplication.CreateBuilder(args);

var grpcService = builder.AddProject<gwdae_grpcservice>("grpcservice");

builder.AddProject<gwdae_web>("webui")
    .WithReference(grpcService);



builder.Build().Run();
