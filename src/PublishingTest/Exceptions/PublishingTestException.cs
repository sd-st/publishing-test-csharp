using System;
using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTestException : Exception
{
    public PublishingTestException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected PublishingTestException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
