﻿using Movies_Catalogue.Services;
using System;
using System.Collections.Generic;

namespace Movies_Catalogue.Models
{
    public class BoxOfficeRequest
    {
        public int Id { get; set; }
        public double Budget { get; set; }
        public double RevenueOpeningWeek { get; set; }
        public double RevenueWorldWide { get; set; }

       
    }
}
