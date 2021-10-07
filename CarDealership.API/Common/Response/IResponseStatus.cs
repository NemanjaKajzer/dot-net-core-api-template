using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarDealership.API.Common.Response
{
    public interface IResponseStatus
    {
        IActionResult CustomStatusCode(int statusCode, Exception e);
    }
}