using App.Infrastructure.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace App.Logic.SampleLogic.Services;

public interface ISampleService
{
    Task<IActionResult> Add(SampleAddDto sampleAddDto);
    Task<IActionResult> GetByGuid(Guid guid);
    Task<IActionResult> GetList();
    Task<IActionResult> Update(SampleUpdateDto sampleUpdateDto);
    Task<IActionResult> DeleteByGuid(Guid guid);
}
