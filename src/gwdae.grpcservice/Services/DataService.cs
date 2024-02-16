using Grpc.Core;
using gwdae.grpcservice;

namespace gwdae.grpcservice.Services;

public class DataService : DataSource.DataSourceBase
{
    private readonly ILogger<DataService> _logger;

    public DataService(ILogger<DataService> logger)
    {
        _logger = logger;
    }

    public override Task<DataReply> GetData(DataRequest request, ServerCallContext context)
    {
        _logger.LogInformation("Get Data Requested for {Name}", request.Name);
        return Task.FromResult(new DataReply
        {
            Message = "Hello " + request.Name
        });
    }
}
