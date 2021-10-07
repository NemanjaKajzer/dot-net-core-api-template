using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.API.Common.Response
{
    public class ResponseStatus : ControllerBase, IResponseStatus
    {
        public IActionResult CustomStatusCode(int statusCode, Exception e)
        {
#if DEBUG
            return StatusCode(500, e.Message + Environment.NewLine + e.StackTrace);
#endif
#if RELEASE
                return StatusCode(500, e.Message);
#endif
        }
    }
}