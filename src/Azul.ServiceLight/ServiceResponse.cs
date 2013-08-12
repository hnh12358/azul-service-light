namespace Azul.ServiceLight
{
    using System;

    public class ServiceResponse
    {
        #region Constructors

        public ServiceResponse(ResponseType result, string message, Exception exception)
        {
            this.Exception = exception;
            this.Result = result;
            this.Message = message;
        }

        #endregion

        #region Properties

        public ResponseType Result { get; private set; }

        public string Message { get; private set; }

        public Exception Exception { get; private set; }

        public bool IsSuccess
        {
            get
            {
                return this.Result == ResponseType.Success;
            }
        }

        #endregion
    }

    public class ServiceResponse<T> : ServiceResponse where T : class
    {
        #region Constructors

        public ServiceResponse(ResponseType result, string message, Exception exception, T data)
            : base(result, message, exception)
        {
            this.Data = data;
        }

        #endregion

        #region Properties

        public T Data { get; protected set; }

        #endregion
    }
}