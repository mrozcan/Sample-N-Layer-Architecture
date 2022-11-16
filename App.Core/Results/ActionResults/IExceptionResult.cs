namespace App.Core.Results.ActionResults;

internal interface IExceptionResult : IResult
{
    public Exception Exception { get; }
}
