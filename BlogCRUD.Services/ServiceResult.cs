                                                                                               using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BlogCRUD.Services
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }

        public List<string> Errors { get; set; }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess()
        {
            return Errors == null || Errors.Count == 0;
        }

        public bool IsFailure()
        {
            return !IsSuccess();
        }   


        public static ServiceResult<T> Success(T data,HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult<T>
            {
                Data = data,
                StatusCode = status
            };
        }

        public static ServiceResult<T> Failure(string errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult<T>
            {
                Errors = new List<string> { errors },
                StatusCode = status
            };
        }


    }

    public class ServiceResult
    {
   

        public List<string> Errors { get; set; }

        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccess()
        {
            return Errors == null || Errors.Count == 0;
        }

        public bool IsFailure()
        {
            return !IsSuccess();
        }


        public static ServiceResult Success( HttpStatusCode status = HttpStatusCode.OK)
        {
            return new ServiceResult
            {
             
                StatusCode = status
            };
        }

        public static ServiceResult Failure(string errors, HttpStatusCode status = HttpStatusCode.BadRequest)
        {
            return new ServiceResult
            {
                Errors = new List<string> { errors },
                StatusCode = status
            };
        }


    }
}
