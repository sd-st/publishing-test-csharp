using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTest5xxException : PublishingTestApiException
{
    public PublishingTest5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
