using System;
using System.Collections.Generic;
using System.Text;

namespace ExcellentGolf
{
    class Course
    {
        public double CourseLength { get; set; }
        public double CourseWidth { get; set; }
        public double PlacementOfTee { get; } = 0;
        public double PlacementOfPin { get; set; }

        public Course()
        {

        }
    }

    
}
