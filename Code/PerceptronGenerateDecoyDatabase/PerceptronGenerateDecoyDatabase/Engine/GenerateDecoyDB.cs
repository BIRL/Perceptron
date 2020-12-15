﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerceptronGenerateDecoyDatabase.DTO;

namespace PerceptronGenerateDecoyDatabase.Engine
{
    public class GenerateDecoyDB
    {
        public List<FastaProteinInfo> GeneratingDecoyDB(List<FastaProteinInfo> ProteinList)
        {
            int a = 1;
            var ProteinDecoyList = new List<FastaProteinInfo>(ProteinList.Count);
            string AminoAcidAlphbets = "ABCDEFGHIKLMNOPQRSTUVWYZ";
            int AminoAcidAlphbetsLength = AminoAcidAlphbets.Length;
            int SequenceLength = 0;
            Random rand = new Random();
            int RandomNumer;

            for (int iter = 0; iter < ProteinList.Count; iter+=3)
            {
                SequenceLength = ProteinList[iter].Sequence.Length;

                ProteinList[iter].Header = ProteinList[iter].Header.Replace(">", ">XXX_");
                ProteinList[iter + 1].Header = ProteinList[iter + 1].Header.Replace(">", ">YYY_");
                ProteinList[iter + 2].Header = ProteinList[iter + 2].Header.Replace(">", ">ZZZ_");


                    /*  UPDATE HERE  */
                    RandomNumer = rand.Next(1, SequenceLength);

                    ProteinList[iter].Sequence = ProteinList[iter].Sequence;

                /*  UPDATE HERE  */

                ProteinDecoyList.Add(ProteinList[iter]);
                ProteinDecoyList.Add(ProteinList[iter+1]);
                ProteinDecoyList.Add(ProteinList[iter+2]);

            }

            return ProteinDecoyList;

        }
    }
}
