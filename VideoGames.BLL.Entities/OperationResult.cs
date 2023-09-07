namespace VideoGames.BLL.Domain
{
    public class OperationResult
    {
        public OperationResult(OperationStatus status, string message)
        {
            Message = message;
            Status = status;
        }

        public OperationStatus Status { get; set; }
        public string Message { get; set; }

        public enum OperationStatus
        {
            Success,
            NotSuccess
        }
    }
}
