using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTestNotFoundException : PublishingTest4xxException
{
    public PublishingTestNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
