namespace KanbanBoard.Shared.Response
{
    public class ResponseGenericList<T> : BaseResponse
    {
        public ICollection<T>? Data { get; set; }
        public int Count { get; set; }
    }
}
