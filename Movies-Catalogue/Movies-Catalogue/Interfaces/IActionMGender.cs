﻿using Movies_Catalogue.Models;
using System.Collections.Generic;

namespace Movies_Catalogue.Interfaces
{
    public interface IActionMGender
    {
        void AddNewGender(MovieGender NewGender);
        List<MovieGender> ShowGender();
        void UpdateGender(MovieGender MovieGender);
        void DeleteGender(int Id);
    }
}
