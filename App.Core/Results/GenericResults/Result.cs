namespace App.Core.Results.GenericResults;

public class Result : IGenericResult
{
    public int Status { get; }
    public int? MessageCode { get; }
    public Result(int status) => Status = status;
    public Result(int status, int messageCode) : this(status) => MessageCode = messageCode;
}
