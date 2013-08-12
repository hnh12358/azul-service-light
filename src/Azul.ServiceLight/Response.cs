namespace Azul.ServiceLight
{
    using System;

    public static class Response
    {
        #region Methods

        public static ServiceResponse Failure(Exception ex)
        {
            if (ex == null)
            {
                throw new ArgumentNullException("ex");
            }

            return new ServiceResponse(ResponseType.Failure, null, ex);
        }

        public static ServiceResponse Failure(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("message");
            }

            return new ServiceResponse(ResponseType.Failure, message, null);
        }

        public static ServiceResponse Failure(string message, Exception ex)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("message");
            }

            if (ex == null)
            {
                throw new ArgumentNullException("ex");
            }

            return new ServiceResponse(ResponseType.Failure, message, ex);
        }

        public static ServiceResponse Success(string message)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException(message);
            }

            return new ServiceResponse(ResponseType.Success, message, null);
        }

        public static ServiceResponse Success()
        {
            return new ServiceResponse(ResponseType.Success, "Internal Operation Success", null);
        }

        #endregion
    }

    public static class Response<T> where T : class
    {
        public static ServiceResponse<T> Success(string message, T data)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("message");
            }

            return new ServiceResponse<T>(ResponseType.Success, message, null, data);
        }

        public static ServiceResponse<T> Failure(string message, T data = null)
        {
          if (string.IsNullOrWhiteSpace(message))
          {
            throw new ArgumentNullException("message");
          }

          return new ServiceResponse<T>(ResponseType.Failure, message, null, data);
        }

        public static ServiceResponse<T> Failure(string message, Exception ex, T data)
        {
            if (string.IsNullOrWhiteSpace(message))
            {
                throw new ArgumentNullException("message");
            }

            if (ex == null)
            {
                throw new ArgumentNullException("ex");
            }

            return new ServiceResponse<T>(ResponseType.Failure, message, ex, data);
        }

        public static ServiceResponse<T> Success(T data)
        {
          if (null == data)
          {
            throw new ArgumentNullException("data");
          }

          return new ServiceResponse<T>(ResponseType.Success, null, null, data);
        }

        public static ServiceResponse<T> Failure(Exception ex, T data = null)
        {
          if (null == ex)
          {
            throw new ArgumentNullException("ex");
          }

          return new ServiceResponse<T>(ResponseType.Failure, "There was an error", ex, data);
        }
    }
}