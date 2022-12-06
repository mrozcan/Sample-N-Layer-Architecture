using App.Logic.SampleLogic.Services;
using Grpc.Core;
using MapsterMapper;

namespace Api.Grpc.Services;

public class SampleGrpcService : Sample.SampleBase
{
    private readonly ILogger<SampleGrpcService> _logger;
    private readonly ISampleService _sampleService;
    private readonly IMapper _mapper;

    public SampleGrpcService(ILogger<SampleGrpcService> logger, IMapper mapper, ISampleService sampleService)
    {
        _logger = logger;
        _mapper = mapper;
        _sampleService = sampleService;
    }

    public override async Task<GetAllReply> GetAll(GetAllRequest request, ServerCallContext context)
    {
        var listOfSampleData = await _sampleService.GetListDataResult();
        GetAllReply getAllReply = new GetAllReply();
        getAllReply.Sample.AddRange(_mapper.Map<List<SampleData>>(listOfSampleData.Data));
        return getAllReply;
    }
}
