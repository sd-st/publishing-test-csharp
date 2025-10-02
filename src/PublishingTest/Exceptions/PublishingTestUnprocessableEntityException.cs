using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTestUnprocessableEntityException : PublishingTest4xxException
{
    public PublishingTestUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
