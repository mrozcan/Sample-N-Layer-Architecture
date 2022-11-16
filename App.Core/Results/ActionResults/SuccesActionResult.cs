using Microsoft.AspNetCore.Mvc;

namespace App.Core.Results.ActionResults;

public class SuccesActionResult : IActionResult
{
    private readonly IResult _result;
    public SuccesActionResult(int statusCode) => _result = new Result(true, statusCode);
    public SuccesActionResult(int statusCode, int messageCode) => _result = new Result(true, statusCode, messageCode);

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var response = new ObjectResult(new { Success = _result.Success, MessageCode = _result.MessageCode })
        { StatusCode = _result.StatusCode };

        await response.ExecuteResultAsync(context);
    }
}
