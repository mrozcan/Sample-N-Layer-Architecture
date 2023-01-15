using App.Domain.Documents;
using App.Infrastructure.DataTransferObjects;
using App.Logic.SampleLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SampleApiClass : ControllerBase
{

    private readonly ISampleService _sampleService;

    public SampleApiClass(ISampleService sampleService)
    {
        _sampleService = sampleService;
    }

    [HttpPost("Add-Sample-Entity")]
    public async Task<IActionResult> AddEntity(SampleAddDto sampleAddDto) => await _sampleService.Add(sampleAddDto);

    [HttpPut("Update-Sample-Entity")]
    public async Task<IActionResult> UpdateEntity(SampleUpdateDto sampleUpdateDto) => await _sampleService.Update(sampleUpdateDto);

    [HttpGet("Get-By-Guid")]
    public async Task<IActionResult> GetByGuid(Guid guid) => await _sampleService.GetByGuid(guid);

    [HttpDelete("Delete-By-Guid")]
    public async Task<IActionResult> DeleteByGuid(Guid guid) => await _sampleService.DeleteByGuid(guid);

    [HttpGet("Get-List")]
    public async Task<IActionResult> GetList() => await _sampleService.GetList();

    [HttpPost("Add-Sample-Document")]
    public async Task<IActionResult> AddDocument(SampleDocument sampleDocument) => await _sampleService.AddDocument(sampleDocument);

    [HttpGet("Document-Get-List")]
    public IActionResult GetAllDocument() => _sampleService.GetAllDocument();
}
