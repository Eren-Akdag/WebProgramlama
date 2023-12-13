﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hastane.Model
{
    public class Lab
    {
        public int Id { get; set; }

        public string LabNumber { get; set; } 

        public ApplicationUser Patient { get; set; }

        public string TestType { get; set; }

        public string TestCode { get; set; }

        public int Weight { get; set; }

        public int Height { get; set; }

        public int BloodPreassure { get; set; }

        public int Temperature { get; set; }

        public string TestResult { get; set; }
    }
}