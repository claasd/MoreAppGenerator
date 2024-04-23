using Caffoa;
using Caffoa.Defaults;

namespace MoreAppBuilder.Implementation.Client;

public class ParseErrorHandler : ICaffoaParseErrorHandler
{
    public CaffoaClientError NoContent() => new DefaultCaffoaClientError("Error during JSON parsing of payload: no body found");

    public CaffoaClientError JsonParseError(Exception err)
    {
        var inner = err;
        while (inner.InnerException != null)
            inner = inner.InnerException;
        return new DefaultCaffoaClientError($"Error during JSON parsing of payload: {inner.Message}", err);
    }


}