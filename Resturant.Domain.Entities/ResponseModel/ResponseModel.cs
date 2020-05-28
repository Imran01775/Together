using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace Resturant.Domain.Entities.ResponseModel
{

    public class LoginResponse
    {
        public int UserTypeId { set; get; }
        public string AuthenticationKey { set; get; }
    }
    public class GetListDataResponse<TModel> 
    {
        public int TotalCount { set; get; }
        public IEnumerable<TModel> Model { set; get; }
        public string Message { get; set; }
        public bool DidError { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode
        {
            get
            {
                if (this.Model == null)
                    return 404;
                else
                    return 200;

            }
        }
    }
    public class ResponseModel : IResponseModel
    {
        public string Message { set; get; }
        public bool DidError { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { set; get; }
    }
    public interface IResponseModel
    {
        public string Message { set; get; }
        public bool DidError { set; get; }
        public string ErrorMessage { set; get; }
        public int StatusCode { set; get; }

    }
    public interface ISingleResponseModel<TModel> : IResponseModel
    {
        TModel Model { set; get; }
    }
    public interface IListResponseModel<TModel> : IResponseModel
    {
        IEnumerable<TModel> Model { set; get; }
    }
    public interface IPageResponseModel<TModel> : IListResponseModel<TModel>
    {
        int ItemsCount { set; get; }
        double PageCount { set; get; }
    }
    public class SingleResponseModel<TModel> : ISingleResponseModel<TModel>
    {

        public string Message { get; set; } = "";
        public bool DidError { get; set; } = false;
        public string ErrorMessage { get; set; } = "";
        public int StatusCode { set; get; }
        public TModel Model { get; set; }
    }
    public class ListResponseModel<TModel> : IListResponseModel<TModel>
    {

        public string Message { set; get; }
        public bool DidError { set; get; }
        public string ErrorMessage { set; get; }
        public int StatusCode { set; get; }
        public IEnumerable<TModel> Model { set; get; }
    }
    public class PageResponseModel<TModel> : IPageResponseModel<TModel>
    {
        public int PageSize { set; get; }
        public int PageNumber { set; get; }
        public int ItemsCount { get; set; }
        public double PageCount { get; set; }

        public string Message { get; set; }
        public bool DidError { get; set; }
        public string ErrorMessage { get; set; }
        public int StatusCode { set; get; }
        public IEnumerable<TModel> Model { get; set; }
    }
    public static class ResponseExtensions
    {
        public static IActionResult ToHttpResponse(this IResponseModel response)
            => new ObjectResult(response)
            {
                StatusCode = (int)(response.DidError ? HttpStatusCode.InternalServerError : HttpStatusCode.OK)
            };

        public static IActionResult ToHttpResponse<TModel>(this ISingleResponseModel<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;
            response.StatusCode = (int)status;
            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpCreatedResponse<TModel>(this ISingleResponseModel<TModel> response)
        {
            var status = HttpStatusCode.Created;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NotFound;


            response.StatusCode = (int)status;
            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }

        public static IActionResult ToHttpResponse<TModel>(this IListResponseModel<TModel> response)
        {
            var status = HttpStatusCode.OK;

            if (response.DidError)
                status = HttpStatusCode.InternalServerError;
            else if (response.Model == null)
                status = HttpStatusCode.NoContent;
            response.StatusCode = (int)status;
            return new ObjectResult(response)
            {
                StatusCode = (int)status
            };
        }
    }


    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }

        public string Message { get; }

        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Message = message;
        }
    }

    public class ValidationResultModel
    {
        public string Message { get; }
        public bool DidError { get; set; }
        public string ErrorMessage { get; set; }

        public List<ValidationError> Model { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            Message = "Validation Failed";
            DidError = true;
            ErrorMessage = "There was an model validation failed, please contact to developer.";
            Model = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();
        }
    }
}
