namespace App.Core.Results.ActionResults;

internal class DataResult<TData> : Result, IDataResult<TData>
{

    public TData Data { get; }
    public DataResult(bool success, int statusCode, TData data) : base(success, statusCode) => Data = data;
    public DataResult(bool success, int statusCode, int messageCode, TData data) : base(success, statusCode, messageCode) => Data = data;

}
