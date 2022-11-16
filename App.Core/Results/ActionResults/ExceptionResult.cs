namespace App.Core.Results.ActionResults;

internal class ExceptionResult : Result, IExceptionResult
{
    public Exception Exception { get; }
    public ExceptionResult(int statusCode, Exception exception) : base(false, statusCode) => Exception = exception;
    public ExceptionResult(int statusCode, int messageCode, Exception exception) : base(false, statusCode, messageCode) => Exception = exception;
}
