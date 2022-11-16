namespace App.Core.Results.GenericResults;

public class DataResult<TData> : Result, IGenericDataResult<TData>
{
    public TData Data { get; }
    public DataResult(int status, TData data) : base(status) => Data = data;
    public DataResult(int status, int messageCode, TData data) : base(status, messageCode) => Data = data;
}
