using Api.Grpc.GrpcDtos;
using App.Domain.Entities;
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

        // Create new configuration for converting data
        _mapper.Config.NewConfig<SampleEntity, SampleGrpcDto>()
            .ConstructUsing(src => new SampleGrpcDto(src.Id, src.CreateDate, src.UpdateDate, src.SampleStringData, src.SampleIntData));
    }

    public override async Task<GetAllReply> GetAll(GetAllRequest request, ServerCallContext context)
    {
        var listOfSampleData = await _sampleService.GetListDataResult();
        GetAllReply getAllReply = new GetAllReply();
        var mappedGrpcData = _mapper.Map<List<SampleGrpcDto>>(listOfSampleData.Data);
        getAllReply.Sample.AddRange(_mapper.Map<List<SampleData>>(mappedGrpcData));
        return getAllReply;
    }
}
