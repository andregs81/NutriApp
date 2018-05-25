﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace NutriApp.Controllers
{
    [Route("api/[controller]")]
    public class ConversorAlturasController : Controller
    {

        [Authorize("Bearer")]
        [HttpGet("PesMetros/{alturaPes}")]
        public object Get(double alturaPes)
        {
            return new
            {
                AlturaPes = alturaPes,
                AlturaMetros = Math.Round(alturaPes * 0.3048, 4)
            };
        }


    }
}