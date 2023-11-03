namespace KanbanBoard.Shared.Response
{
    public class ResponseGenericObject<T> : BaseResponse
    {
        public T? Data { get; set; }
    }
}
