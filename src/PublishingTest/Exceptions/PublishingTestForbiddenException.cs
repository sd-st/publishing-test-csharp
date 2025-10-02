using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTestForbiddenException : PublishingTest4xxException
{
    public PublishingTestForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
