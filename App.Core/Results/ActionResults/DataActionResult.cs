using Microsoft.AspNetCore.Mvc;

namespace App.Core.Results.ActionResults;

public class DataActionResult<TData> : IActionResult
{
    private readonly IDataResult<TData> _result;
    public DataActionResult(int statusCode, TData data, bool success = true) => _result = new DataResult<TData>(success, statusCode, data);
    public DataActionResult(int statusCode, int messageCode, TData data, bool success = true) => _result = new DataResult<TData>(success, statusCode, messageCode, data);

    public async Task ExecuteResultAsync(ActionContext context)
    {
        var response = new ObjectResult(new { Success = _result.Success, MessageCode = _result.MessageCode, Data = _result.Data })
        { StatusCode = _result.StatusCode };

        await response.ExecuteResultAsync(context);
    }
}
