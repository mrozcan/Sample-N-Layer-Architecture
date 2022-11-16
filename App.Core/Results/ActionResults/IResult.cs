namespace App.Core.Results.ActionResults;

internal interface IResult
{
    public bool Success { get; }
    public int StatusCode { get; }
    public int? MessageCode { get; }

}
