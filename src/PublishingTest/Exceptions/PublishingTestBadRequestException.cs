using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTestBadRequestException : PublishingTest4xxException
{
    public PublishingTestBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
