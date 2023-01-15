namespace Api.Grpc.GrpcDtos;

public class SampleGrpcDto
{
    public Guid Id { get; init; }
    public string? CreateDate { get; set; }
    public string? UpdateDate { get; set; }
    public string? SampleStringData { get; set; }
    public int SampleIntData { get; set; }

    public SampleGrpcDto(Guid id, DateTime createDate, DateTime? updateDate, string? sampleStringData, int sampleIntData)
    {
        Id = id;
        CreateDate = createDate.ToString();
        UpdateDate = updateDate.ToString();
        SampleStringData = sampleStringData;
        SampleIntData = sampleIntData;
    }
}

