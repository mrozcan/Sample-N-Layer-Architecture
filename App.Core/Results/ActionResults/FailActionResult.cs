using Microsoft.AspNetCore.Mvc;

namespace App.Core.Results.ActionResults;

public class FailActionResult : IActionResult
{
    private readonly IResult _result;
    public FailActionResult(int statusCode) => _result = new Result(false, statusCode);
    public FailActionResult(int statusCode, int messageCode) => _result = new Result(false, statusCode, messageCode);

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var response = new ObjectResult(new { Success = _result.Success, MessageCode = _result.MessageCode })
        { StatusCode = _result.StatusCode };

        await response.ExecuteResultAsync(context);
    }
}
