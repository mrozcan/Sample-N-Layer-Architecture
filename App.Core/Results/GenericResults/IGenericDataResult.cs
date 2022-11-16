namespace App.Core.Results.GenericResults;

public interface IGenericDataResult<TData> : IGenericResult
{
    TData Data { get; }
}
