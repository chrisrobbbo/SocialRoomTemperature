namespace AwsDotnetCsharp.Shared.Models
{
    public class ListTableItemsRequest : IRequest
    {
        public string TableName { get; set; }
    }
}