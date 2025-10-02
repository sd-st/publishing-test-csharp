using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTestRateLimitException : PublishingTest4xxException
{
    public PublishingTestRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
