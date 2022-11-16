namespace App.Core.Results.ActionResults;

internal class Result : IResult
{
    public bool Success { get; }
    public int StatusCode { get; }
    public int? MessageCode { get; }
    public Result(bool success, int statusCode) { Success = success; StatusCode = statusCode; }
    public Result(bool success, int statusCode, int messageCode) : this(success, statusCode) => MessageCode = messageCode;

}
