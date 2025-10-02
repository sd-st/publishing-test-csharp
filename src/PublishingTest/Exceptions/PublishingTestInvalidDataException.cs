using System;

namespace PublishingTest.Exceptions;

public class PublishingTestInvalidDataException : PublishingTestException
{
    public PublishingTestInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
