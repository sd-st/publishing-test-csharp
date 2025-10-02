using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTest4xxException : PublishingTestApiException
{
    public PublishingTest4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
