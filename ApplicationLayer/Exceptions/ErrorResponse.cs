namespace ApplicationLayer.Exceptions
{
    public class ErrorResponse
    {
        public bool Success { get; set; }
        public string Message 
        {
            get;set;
        } 
        public string InnerExceptionMessage 
        {
            get;set;
        }
        public string DetailStackTrace { get; set; }
    }
    
}
