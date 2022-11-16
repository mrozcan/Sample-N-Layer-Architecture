using Microsoft.AspNetCore.Mvc;

namespace App.Core.Results.ActionResults;

public class ExceptionActionResult : IActionResult
{
    private readonly IExceptionResult _result;
    public ExceptionActionResult(int statusCode, Exception exception) => _result = new ExceptionResult(statusCode, exception);
    public ExceptionActionResult(int statusCode, Exception exception, int messageCode) => _result = new ExceptionResult(statusCode, messageCode, exception);

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var response = new ObjectResult(new { Success = _result.Success, MessageCode = _result.MessageCode, Exception = _result.Exception })
        { StatusCode = _result.StatusCode };
        await response.ExecuteResultAsync(context);
    }
}