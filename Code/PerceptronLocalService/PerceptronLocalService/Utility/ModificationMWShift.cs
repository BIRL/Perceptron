﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerceptronLocalService.Utility
{
    public class ModificationMWShift
    {

        public double ModificationMWShiftTable(string Mod) //Gives the weight of different types of modifications
        {

            //SHIFTed From PostTranslationalModificationCpu.cs with New name (Previouly its ModTable) 
            //TO THE UTILITY FOR COMBINE USE
            // DELETE ModTable FROM PostTranslationalModificationCpu.cs AFTER STABLILITY.
            // NO MORE EDITTING THERE

            //#Enhancement Switch Cases will be more better here
            double ModWeight = 0;
            if (Mod == "Propionamidation" || Mod == "Cys_PAM")
                ModWeight = 174.04631;
            else if (Mod == "Pyruvate-S")
                ModWeight = -17.0265;
            else if (Mod == "Pyruvate-C")
                ModWeight = 70.0055;
            else if (Mod == "Amidation")
                ModWeight = -0.984016;
            else if (Mod == "Citrullination")
                ModWeight = 0.984016;
            else if (Mod == "Methylation")
                ModWeight = 14.0156;
            else if (Mod == "Hydroxylation")
                ModWeight = 15.9949;
            else if (Mod == "Sulfoxide" || Mod == "MSO")
                ModWeight = 147.0354;
            else if (Mod == "Formylation")
                ModWeight = 27.9949;
            else if (Mod == "DiMethylation")
                ModWeight = 28.0313;
            else if (Mod == "S-Nitrosylation")
                ModWeight = 28.9902;
            else if (Mod == "Sulfone")
                ModWeight = 31.9898;
            else if (Mod == "DiHydroxylation")
                ModWeight = 31.9898;
            else if (Mod == "TriMethylation")
                ModWeight = 42.047;
            else if (Mod == "Acetylation")
                ModWeight = 42.0106;
            else if (Mod == "Gamma-Carboxyglutamic-Acid")
                ModWeight = 43.9898;
            else if (Mod == "Nitration")
                ModWeight = 44.9851;
            else if (Mod == "Phosphorylation")
                ModWeight = 79.9663;
            else if (Mod == "Pyrrolidone-Aarboxylic-Acid")
                ModWeight = -17.0265;
            else if (Mod == "O-linked-Glycosylation")
                ModWeight = 203.0794;
            else if (Mod == "Palmitoylation")
                ModWeight = 238.23;
            else if (Mod == "Glutathionylation")
                ModWeight = 305.068;
            else if (Mod == "N-linked-Glycosylation")
                ModWeight = 317.122;
            else
                ModWeight = 0.0;
            return ModWeight;
        }

    }
}