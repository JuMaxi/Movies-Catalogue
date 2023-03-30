﻿using Microsoft.AspNetCore.Mvc;
using Movies_Catalogue.Models;
using Movies_Catalogue.Services;
using Movies_Catalogue.Validators;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace Movies_Catalogue.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MovieController : ControllerBase
    {
        ActionMovie ActionMovie;

        public MovieController() 
        {
            ActionMovie = new ActionMovie(new AccessDB(), new ValidateMovie());
        }

        [HttpPost]
        public void AddMo(Movie Movie)
        {
            ActionMovie.NewMovie(Movie);
        }
    }
}
