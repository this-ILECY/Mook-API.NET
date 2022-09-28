using MookApi.Models;

namespace MookApi.ViewModel
{
    public class RequestViewModel
    {
        public RequestHeader requestHeader{ get; set; }
        public List<RequestDetails> requestDetails{ get; set; }
        public Students students { get; set; }
    }
}
