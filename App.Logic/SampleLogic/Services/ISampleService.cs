using App.Core.Results.GenericResults;
using App.Domain.Documents;
using App.Domain.Entities;
using App.Infrastructure.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace App.Logic.SampleLogic.Services;

public interface ISampleService
{
    Task<IActionResult> Add(SampleAddDto sampleAddDto);
    Task<IActionResult> GetByGuid(Guid guid);
    Task<IActionResult> GetList();
    Task<DataResult<List<SampleEntity>>> GetListDataResult();
    Task<IActionResult> Update(SampleUpdateDto sampleUpdateDto);
    Task<IActionResult> DeleteByGuid(Guid guid);
    Task<IActionResult> AddDocument(SampleDocument sampleDocument);
    IActionResult GetAllDocument();
}
