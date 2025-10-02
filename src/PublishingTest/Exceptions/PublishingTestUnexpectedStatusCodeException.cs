using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTestUnexpectedStatusCodeException : PublishingTestApiException
{
    public PublishingTestUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
