﻿using System.Collections.Generic;
using System;
using Movies_Catalogue.Models;
using Movies_Catalogue.Interfaces;

namespace Movies_Catalogue.Validators
{
    public class ValidateMovieGender : IValidateMovieGender
    {
        public void ValidateGender(MovieGenderRequest gender)
        {
            if (gender.Gender == null
                || gender.Gender.Length == 0)
            {
                throw new Exception("The field Gender can't be empty or null. Please fill the gender to continue.");
            }
        }
    }
}
