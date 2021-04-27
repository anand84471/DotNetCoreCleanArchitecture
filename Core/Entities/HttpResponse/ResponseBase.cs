using Core.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.HttpResponse
{
    public class ResponseBase
    {
        [JsonProperty("response_code")]
        public int ResponseCode { get; set; }
        [JsonProperty("response_message")]
        public string ResponseMessage { get; set; }
        [JsonProperty("error")]
        public ErrorResponseBase Error { get; set; }
        public ResponseBase()
        {
            ResponseCode = CoreConstants.RESPONSE_CODE_FAIL;
            ResponseMessage = CoreConstants.RESPONSE_MESSAGE_FAIL;
        }
        public void SetSuccessResponse()
        {
            ResponseCode = CoreConstants.RESPONSE_CODE_SUCCESS;
            ResponseMessage = CoreConstants.RESPONSE_MESSAGE_SUCCESS;
        }
        public void SetError(int errorCode,string errorMeesage)
        {
            Error = new ErrorResponseBase();
            Error.ErrorCode = errorCode;
            Error.ErrorMessage = errorMeesage;
        }
    }
}
