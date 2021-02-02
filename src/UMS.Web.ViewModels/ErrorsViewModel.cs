namespace UMS.Web.ViewModels
{
    public class ErrorsViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
