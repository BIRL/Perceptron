﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLocalService.DTO
{
    public class BlindPtmInfo
    {
        public int Start;
        public int End;
        public double Mass;

        public BlindPtmInfo()
        {
            Start = -1;
            End = -1;
            Mass = -1;
        }

        public BlindPtmInfo(int cStart, int cEnd, double cMass)
        {
            Start = cStart;
            End = cEnd;
            Mass = cMass;
        }
    }
}