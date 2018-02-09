using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Lykke.Service.ChainalysisMock.Controllers
{
    public class BaseController : Controller
    {
        /// <summary>
        /// API-key
        /// </summary>
        [FromHeader(Name = "Token")]
        [Required]
        public string Token { get; set; }
        
    }
}
