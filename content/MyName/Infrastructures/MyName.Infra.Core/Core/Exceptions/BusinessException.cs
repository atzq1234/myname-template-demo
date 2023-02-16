namespace MyName.Infra.Core.Exceptions;

[Serializable]
public class BusinessException : Exception, IMyNameException
{
    public BusinessException(string message)
        : base(message)
    {
        base.HResult = (int)HttpStatusCode.BadRequest;
    }

    public BusinessException(HttpStatusCode statusCode, string message)
    : base(message)
    {
        base.HResult = (int)statusCode;
    }
}