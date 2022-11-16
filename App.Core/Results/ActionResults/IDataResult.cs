namespace App.Core.Results.ActionResults;

internal interface IDataResult<TData> : IResult
{
    TData Data { get; }
}
