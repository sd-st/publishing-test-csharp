# Publishing Test C# API Library

> [!NOTE]
> The Publishing Test C# API Library is currently in **beta** and we're excited for you to experiment with it!
>
> This library has not yet been exhaustively tested in production environments and may be missing some features you'd expect in a stable release. As we continue development, there may be breaking changes that require updates to your code.
>
> **We'd love your feedback!** Please share any suggestions, bug reports, feature requests, or general thoughts by [filing an issue](https://www.github.com/stainless-sdks/publishing-test-csharp/issues/new).

The Publishing Test C# SDK provides convenient access to the Publishing Test REST API from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

## Installation

### Dotnet

```bash
dotnet add reference /path/to/publishing-test-csharp/src/PublishingTest/
```

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```C#
using PublishingTest;
using PublishingTest.Models.Store.Order;
using System;

// Configured using the PETSTORE_API_KEY and PUBLISHING_TEST_BASE_URL environment variables
PublishingTestClient client = new();

OrderCreateParams param = new()
{

};

var order = await client.Store.Order.Create(param);

Console.WriteLine(order);
```

## Client Configuration

Configure the client using environment variables:

```C#
using PublishingTest;

// Configured using the PETSTORE_API_KEY and PUBLISHING_TEST_BASE_URL environment variables
PublishingTestClient client = new();
```

Or manually:

```C#
using PublishingTest;

PublishingTestClient client = new()
{
  APIKey = "My API Key"
};
```

Alternatively, you can use a combination of the two approaches.
