using System;

namespace SuperMarket.Core.Structs
{
    public struct ServiceResult<T>
    {
        public T? Data { get; }
        public string? ErrorMessage { get; } 
        public bool IsSuccess =>    ErrorMessage == null;

        public ServiceResult(T data)
        {
            Data = data;
            ErrorMessage = null;
        }

        public ServiceResult(string errorMessage)
        {
            Data = default;
            ErrorMessage = errorMessage;
        }

        public static ServiceResult<T> Success(T data)
        {
            return new ServiceResult<T>(data);
        }

        public static ServiceResult<T> Error(string errorMessage)
        {
            return new ServiceResult<T>(errorMessage);
        }

        public static ServiceResult<T> Exception(Exception ex)
        {
            return new ServiceResult<T>(ex.Message);
        }

        public static implicit operator ServiceResult<T>(T data)
            => new ServiceResult<T>(data);

        public static implicit operator ServiceResult<T>(string errorMessage)
            => new ServiceResult<T>(errorMessage);
    }
}
