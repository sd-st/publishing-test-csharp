using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTestUnauthorizedException : PublishingTest4xxException
{
    public PublishingTestUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
