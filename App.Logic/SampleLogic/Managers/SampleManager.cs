using App.Core.Results.ActionResults;
using App.Core.Results.GenericResults;
using App.Domain.Documents;
using App.Domain.Entities;
using App.Infrastructure.DataTransferObjects;
using App.Infrastructure.ORMs.EntityFramework.Abstract;
using App.Infrastructure.ORMs.Mongo.Abstract;
using App.Logic.SampleLogic.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace App.Logic.SampleLogic.Managers;

public class SampleManager : ISampleService
{
    private readonly IMapper _mapper;
    private readonly ISampleRepository _sampleRepository;
    private readonly ISampleDocumentRepository _sampleDocumentRepository;

    public SampleManager(IMapper mapper, ISampleRepository sampleRepository, ISampleDocumentRepository sampleDocumentRepository)
    {
        _mapper = mapper;
        _sampleRepository = sampleRepository;
        _sampleDocumentRepository = sampleDocumentRepository;
    }

    public async Task<IActionResult> Add(SampleAddDto sampleAddDto)
    {
        var mappedEntity = _mapper.Map<SampleEntity>(sampleAddDto);
        await _sampleRepository.AddAsync(mappedEntity);

        return new DataActionResult<SampleEntity>(200, data: mappedEntity);
    }


    public async Task<IActionResult> DeleteByGuid(Guid guid)
    {
        var entity = await _sampleRepository.Queryable().SingleOrDefaultAsync(x => x.Id == guid);

        if (entity != null)
            await _sampleRepository.DeleteAsync(entity);
        else
            return new FailActionResult(404, 50);

        return new SuccesActionResult(200, 100);
    }

    public async Task<IActionResult> GetByGuid(Guid guid)
    {
        var data = await _sampleRepository.Queryable().SingleOrDefaultAsync(x => x.Id == guid);

        if (data == null)
            return new FailActionResult(404, 50);

        return new DataActionResult<SampleEntity?>(200, data: data);
    }

    public async Task<IActionResult> GetList()
    {
        var listOfSample = await _sampleRepository.Queryable().ToListAsync();
        return new DataActionResult<List<SampleEntity>>(200, data: listOfSample);
    }

    // Method for GRPC Api
    public async Task<DataResult<List<SampleEntity>>> GetListDataResult()
    {
        var listOfSample = await _sampleRepository.Queryable().ToListAsync();
        return new DataResult<List<SampleEntity>>(200, listOfSample);
    }

    public async Task<IActionResult> Update(SampleUpdateDto sampleUpdateDto)
    {
        var entity = await _sampleRepository.Queryable().SingleOrDefaultAsync(x => x.Id == sampleUpdateDto.Id);

        if (entity == null)
            return new FailActionResult(404, 50);

        _mapper.Map<SampleUpdateDto, SampleEntity>(sampleUpdateDto, entity);
        entity.UpdateDate = DateTime.UtcNow;

        await _sampleRepository.UpdateAsync(entity);

        return new SuccesActionResult(200, 100);
    }

    public async Task<IActionResult> AddDocument(SampleDocument sampleDocument)
    {
        await _sampleDocumentRepository.AddAsync(sampleDocument);
        return new SuccesActionResult(statusCode: 200, messageCode: 200);
    }

    public IActionResult GetAllDocument()
    {
        return new DataActionResult<List<SampleDocument>>(statusCode: 200, messageCode: 200, data: _sampleDocumentRepository.GetAll().ToList());
    }

}
