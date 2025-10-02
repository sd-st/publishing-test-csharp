using System;
using System.Net.Http;

namespace PublishingTest.Exceptions;

public class PublishingTestIOException : PublishingTestException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public PublishingTestIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
