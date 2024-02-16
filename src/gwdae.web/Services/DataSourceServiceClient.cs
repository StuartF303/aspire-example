using gwdae.grpcservice;

namespace gwdae.web.Services
{
    public class DataSourceServiceClient(DataSource.DataSourceClient client )
    {

        public async Task<DataReply> GetDataSourceEntry()
        {
            DataRequest request = new DataRequest();
            request.Start = "now";
            request.Name = "alice";

            var response = await client.GetDataAsync(request);

            return response;
        }
    }
}
