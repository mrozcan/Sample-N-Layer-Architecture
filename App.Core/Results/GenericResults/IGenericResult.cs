namespace App.Core.Results.GenericResults;

public interface IGenericResult
{
    int Status { get; }
    int? MessageCode { get; }
}
