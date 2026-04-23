namespace BookStore.Responses;
public class ResponseMessage
    {
        public string Message { get; set; } = string.Empty;
        public string Type { get; set; } = "success"; // success, danger, warning, info
    }