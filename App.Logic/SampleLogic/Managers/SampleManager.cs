using App.Core.Results.ActionResults;
using App.Domain.Entities;
using App.Infrastructure.DataTransferObjects;
using App.Infrastructure.ORMs.EntityFramework.Abstract;
using App.Logic.SampleLogic.Services;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace App.Logic.SampleLogic.Managers;

public class SampleManager : ISampleService
{
    private readonly IMapper _mapper;
    private readonly ISampleRepository _sampleRepository;

    public SampleManager(IMapper mapper, ISampleRepository sampleRepository)
    {
        _mapper = mapper;
        _sampleRepository = sampleRepository;
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
}
