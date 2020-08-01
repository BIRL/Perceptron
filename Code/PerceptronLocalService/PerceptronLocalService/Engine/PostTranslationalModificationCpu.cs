﻿/*
 * 
 *      #CFTTB
 *
 */


using System;
using System.Collections.Generic;
using System.Linq;
using PerceptronLocalService.Interfaces;
using PerceptronLocalService.DTO;
using PerceptronLocalService.Utility;

namespace PerceptronLocalService.Engine
{


    public class PostTranslationalModificationModuleCpu : IPostTranslationalModificationModule
    {
        ModificationMWShift ModificationTableClass = new ModificationMWShift();
        Cys_CAM_CPU _Cys_CAM = new Cys_CAM_CPU();
        Cys_CM_CPU _Cys_CM = new Cys_CM_CPU();
        Cys_PAM_CPU _Cys_PAM = new Cys_PAM_CPU();
        Cys_PE_CPU _Cys_PE = new Cys_PE_CPU();
        MSO_CPU _MSO = new MSO_CPU();
        MSONE_CPU _MSONE = new MSONE_CPU();
        SwitchTypeOfPTM _SwitchTypeOfPTM = new SwitchTypeOfPTM();
        Combinations _Combinations = new Combinations();

        private readonly IInsilicoFilter _insilicoFilter;

        public PostTranslationalModificationModuleCpu()
        {
            _insilicoFilter = new InsilicoFilterCpu();
        }
        /// No need for this!!!     Updated 20200714
        //private int _aaSize;

        //private void SetAaSize(int size)
        //{
        //    _aaSize = size;
        //}
        private char _siteDetect = '\0';

        private void SetsiteDetect(char letter)
        {
            _siteDetect = letter;
        }

        private IEnumerable<int[]> Combinations(int m, int n) // nCr = nCm
        {
            var result = new int[m];
            var stack = new Stack<int>();
            stack.Push(0);

            while (stack.Count > 0)
            {
                var index = stack.Count - 1;
                var value = stack.Pop();

                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index != m) continue;
                    yield return result;
                    break;
                }
            }
        }

        // Function: returns the total number of sites found in the given protein sequence
        private int GetSiteNumber(string proteinSequence)
        {
            var arraySize = 0;
            int i;
            for (i = 0; i < proteinSequence.Length; i++)
            {
                if (proteinSequence[i] == _siteDetect)
                    arraySize++;
            }
            return arraySize;
        }

        

        

        ////////*******************************


        //////// calls functions of PTMs and calculates scores
        //////private void RunAlgosv(string protSequence, double tol, List<PostTranslationModificationsSiteDto> filtered, List<int> ptmCode)
        //////{
        //////    // Runs only the PTMS that the user selected

        //////    //List<Sites> filtered_sites = new List<Sites>();
        //////    var dummy = new List<PostTranslationModificationsSiteDto>();

        //////    foreach (var a in ptmCode)
        //////    {
        //////        switch (a)
        //////        {
        //////            case 1:
        //////                dummy = Acetylation_A(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 2:
        //////                dummy = Acetylation_K(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 3:
        //////                dummy = Acetylation_M(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 4:
        //////                dummy = Acetylation_S(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 5:
        //////                dummy = Amidation_F(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 6:
        //////                dummy = Hydroxylation_P(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 7:
        //////                dummy = Methylation_K(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 8:
        //////                dummy = Methylation_R(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 9:
        //////                dummy = N_Linked_Glycosylation_N(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 10:
        //////                dummy = O_Linked_Glycosylation_T(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 11:
        //////                dummy = O_Linked_Glycosylation_S(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 12:
        //////                dummy = Phosphorylation_S(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 13:
        //////                dummy = Phosphorylation_T(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 14:
        //////                dummy = Phosphorylation_Y(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 15:
        //////                dummy = Ubiquitination_K(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            default:
        //////                // idle
        //////                break;
        //////        }
        //////    }
        //////}

        //////private void RunAlgosf(string protSequence, double tol, List<PostTranslationModificationsSiteDto> filtered, List<int> ptmCode)
        //////{
        //////    //List<Sites> filtered_sites = new List<Sites>();
        //////    var dummy = new List<PostTranslationModificationsSiteDto>();

        //////    foreach (var a in ptmCode)
        //////    {
        //////        switch (a)
        //////        {
        //////            case 1:
        //////                dummy = Acetylation_A(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 2:
        //////                dummy = Acetylation_K(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 3:
        //////                dummy = Acetylation_M(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 4:
        //////                dummy = Acetylation_S(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 5:
        //////                dummy = Amidation_F(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 6:
        //////                dummy = Hydroxylation_P(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 7:
        //////                dummy = Methylation_K(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 8:
        //////                dummy = Methylation_R(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 9:
        //////                dummy = N_Linked_Glycosylation_N(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 10:
        //////                dummy = O_Linked_Glycosylation_T(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 11:
        //////                dummy = O_Linked_Glycosylation_S(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 12:
        //////                dummy = Phosphorylation_S(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 13:
        //////                dummy = Phosphorylation_T(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 14:
        //////                dummy = Phosphorylation_Y(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            case 15:
        //////                dummy = Ubiquitination_K(protSequence, tol);
        //////                //filter(dummy, filtered, tol);
        //////                foreach (var b in dummy)
        //////                    filtered.Add(b);
        //////                break;
        //////            default:
        //////                // idle
        //////                break;
        //////        }
        //////    }
        //////}

        // FUNCTION FOR MAKING MODIFIED PROTEINS
        private void make_mod_proteins_2(List<PostTranslationModificationsSiteDto> filteredSites, List<ProteinDto> modProteins, List<int> combos,
            ProteinDto parent, List<ProteinDto> shortProt, string clevageType, string ions, List<double> peakList,
            double tol, double mwWeight, double pstWeight, double insilicoWeight)
        {
            var dummyMw = parent.Mw; // MW of the original sequence
            double dummyPtmScore = 0; // ptm score of the unmodified sequence
            //var aStringBuilder = new StringBuilder(sequence);

            /*foreach(int a in combos)
            {
                Console.WriteLine(a);
            }*/

            var sitesInfo = new List<PostTranslationModificationsSiteDto>();

            foreach (var i in combos)
            {
                if (i != 777)
                {
                    dummyMw += filteredSites.ElementAt(i).ModWeight;
                    // accumulates the mod weight of all the sites in the current combination
                    dummyPtmScore += filteredSites.ElementAt(i).Score; //accumlates the ptm score
                    sitesInfo.Add(filteredSites.ElementAt(i));

                    //aStringBuilder.Remove(filtered_sites.ElementAt(i).i, 1);
                    //aStringBuilder.Insert(filtered_sites.ElementAt(i).i, (filtered_sites.ElementAt(i).site + "mod"));
                    //obj.sequence = aStringBuilder.ToString();
                }
                else if (i == 777)
                {
                    var temp = new ProteinDto();

                    //mod_proteins.Add(temp);     // adding the protein

                    var min = 0;
                    double val = 0;
                    ;

                    if (shortProt.Count == 10000)
                    {
                        min = 0;
                        val = shortProt.ElementAt(0).Score;
                        for (var kkk = 1; kkk < shortProt.Count; kkk++)
                        {
                            if (val > shortProt.ElementAt(kkk).Score)
                            {
                                min = kkk;
                                val = shortProt.ElementAt(kkk).Score;
                            }
                        }

                        shortProt.RemoveAt(min);
                    }


                    shortProt.Add(temp);// Remove (populate temp first)

                    // using count - 1 because the list counts a single object as 1 and not as zeroth element
                    // in case of fixed modifications, the first element is 777. so the unmodified protein is added with the default weight and score
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).MW = dummyMW;
                    shortProt.ElementAt(shortProt.Count - 1).Mw = dummyMw;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).ptm_score = dummy_ptm_score;
                    shortProt.ElementAt(shortProt.Count - 1).PtmScore = dummyPtmScore;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).sequence = parent.sequence;
                    shortProt.ElementAt(shortProt.Count - 1).Sequence = parent.Sequence;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).header = parent.header;
                    shortProt.ElementAt(shortProt.Count - 1).Header = parent.Header;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).est_score = parent.est_score;
                    shortProt.ElementAt(shortProt.Count - 1).PstScore = parent.PstScore;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).insilico_score = parent.insilico_score;
                    shortProt.ElementAt(shortProt.Count - 1).InsilicoScore = parent.InsilicoScore;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).MW_score = parent.MW_score;
                    shortProt.ElementAt(shortProt.Count - 1).MwScore = parent.MwScore;
                    ////mod_proteins.ElementAt(mod_proteins.Count - 1).ptm_particulars = parent.ptm_particulars;
                    ////mod_proteins.ElementAt(mod_proteins.Count - 1).ptm_particulars.Add(filtered_sites.ElementAt(i));
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).score = parent.score;
                    shortProt.ElementAt(shortProt.Count - 1).Score = parent.Score;
                    //mod_proteins.ElementAt(mod_proteins.Count - 1).insilico_details = parent.insilico_details;
                    shortProt.ElementAt(shortProt.Count - 1).InsilicoDetails = parent.InsilicoDetails;

                    foreach (var a in sitesInfo) //Remove (assign list by using =)
                    {
                        //mod_proteins.ElementAt(mod_proteins.Count - 1).ptm_particulars.Add(a);
                        shortProt.ElementAt(shortProt.Count - 1).PtmParticulars.Add(a);
                    }

                    InsilicoFragmentationPtmCpu.insilico_fragmentation(shortProt.ElementAt(shortProt.Count - 1), clevageType,
                        ions);
                    var temp1 = new List<ProteinDto>();
                    temp1.Add(shortProt.ElementAt(shortProt.Count - 1));
                    string pepUnit = "Its Just Commented";
                    //_insilicoFilter.ComputeInsilicoScore(temp1, peakList, tol, pepUnit);
                    //_insilicoFilter.ComputeInsilicoScore(temp1, peakList, tol); // Commented
                    shortProt.ElementAt(shortProt.Count - 1).set_score(mwWeight, pstWeight, insilicoWeight);

                    dummyMw = parent.Mw;
                    dummyPtmScore = 0;
                    sitesInfo = new List<PostTranslationModificationsSiteDto>();
                    //aStringBuilder = new StringBuilder(sequence);
                }
            }
        }

        private double variable_mods_2(List<double> curve, string proteinSequence, List<PostTranslationModificationsSiteDto> filteredSitesA,
            double tol, List<int> indices, List<ProteinDto> modProt, List<int> ptmCodeV, ProteinDto parentPro,
            List<ProteinDto> shortlisted, string clevageType, string ions, List<double> peakList, double insilicoTol,
            double mwWeight, double pstWeight, double insilicoWeight)
        {
            //Console.WriteLine("working");
            /*FOR THE TIME BEING*///RunAlgosv(proteinSequence, tol, filteredSitesA, ptmCodeV); // filtered sites is currently empty

            var sortedList = filteredSitesA.OrderBy(o => o.Score).ToList();
            //sorting in ascending order of scores of sites

            int j;
            var combos = new List<string>();
            //List<int> indices = new List<int>();

            var limitCombs = 0;

            //for (j = 1; j <= SortedList.Count; j++)
            for (j = 1; j <= 5; j++) //Remove (Hard coded value) (Does not return any combination greater than 5)
            {
                foreach (var c in Combinations(j, sortedList.Count))
                {
                    var dummy = "";
                    //Console.WriteLine(int.MaxValue);
                    int i;
                    for (i = 0; i < c.Length; i++)
                    {
                        dummy += c[i].ToString();
                        indices.Add(c[i]); // separates indices
                    }
                    combos.Add(dummy);
                    indices.Add(777);
                    //Console.WriteLine();
                }
                //Console.WriteLine("CHECK");
            }
            //Console.WriteLine("CHECK");

            shortlisted.Add(parentPro);

            InsilicoFragmentationPtmCpu.insilico_fragmentation(shortlisted.ElementAt(shortlisted.Count - 1), clevageType, ions);
            var temp = new List<ProteinDto>();
            temp.Add(shortlisted.ElementAt(shortlisted.Count - 1));
            string pepUnit = "Its Just Commented";//Commented
            //_insilicoFilter.ComputeInsilicoScore(temp, peakList, insilicoTol, pepUnit);
            //_insilicoFilter.ComputeInsilicoScore(temp, peakList, insilicoTol); //Commented
            shortlisted.ElementAt(shortlisted.Count - 1).set_score(mwWeight, pstWeight, insilicoWeight);

            if (sortedList.Count > 0)
                make_mod_proteins_2(filteredSitesA, modProt, indices, parentPro, shortlisted, clevageType, ions,
                    peakList, insilicoTol, mwWeight, pstWeight, insilicoWeight);

            //mod_prot.ElementAt(0).ptm_particulars = new List<Sites>();
            var counter = 1;
            var con = false;
            var dummyList = new List<PostTranslationModificationsSiteDto>();

            double totalScore = 0;

            var cou = 0;
            double finalScore = 0;

            foreach (var a in modProt)
            {
                if (a.PtmScore != 0)
                {
                    a.PtmScore = 1 - Math.Exp(-a.PtmScore);
                }
            }

            return finalScore;
        }

        private double fixed_mods_2(List<double> curve, string proteinSequence, List<PostTranslationModificationsSiteDto> filteredSitesB,
            double tol, List<int> indices, List<ProteinDto> modProt, List<int> ptmCodeF, ProteinDto parentPro,
            List<ProteinDto> shortProt, string clevageType, string ions, List<double> peakList, double insilicoTol,
            double mwWeight, double pstWeight, double insilicoWeight)
        {
            //Console.WriteLine("working");
            //int j;

            /*FOR THE TIME BEING*///RunAlgosf(proteinSequence, 0, filteredSitesB, ptmCodeF);
            // runs the modifications selected by the user and stores the sites in filtered sites

            var sortedList = filteredSitesB.OrderBy(o => o.Score).ToList();
            // sorts the filtered sites in ascending order of their ptm scores

            //indices.Add(777);
            for (var i = 0; i < sortedList.Count; i++)
            {
                indices.Add(i);
            }
            indices.Add(777);

            if (sortedList.Count > 0)
                make_mod_proteins_2(filteredSitesB, modProt, indices, parentPro, shortProt, clevageType, ions,
                    peakList, insilicoTol, mwWeight, pstWeight, insilicoWeight);

            //short_prot.ElementAt(short_prot.Count - 1).ptm_particulars = new List<Sites>();
            //foreach (Sites a in filtered_sitesB)
            //{
            //    mod_prot.ElementAt(mod_prot.Count - 1).ptm_particulars.Add(a);
            //}


            double totalScore = 0;

            var cou = 1;
            foreach (var a in modProt)
            {
                if ((a.PtmScore != 0) && (cou == modProt.Count))
                {
                    a.PtmScore = 1 - Math.Exp(-a.PtmScore);
                }
                cou++;
            }

            return totalScore;
        }


        private void FinalFilter(List<ProteinDto> filterProts)
        {
            //filterProts.Sort((x, y) => y.score.CompareTo(x.score));
            filterProts.AsParallel().OrderBy(x => x.Score);
            filterProts.RemoveRange(10000, filterProts.Count - 10000);
        }

        public void ExecutePtmModule(List<ProteinDto> input, List<ProteinDto> modifiedProteins, List<ProteinDto> shortlistedProt, MsPeaksDto peakData, SearchParametersDto parameters)
        {
            var tolerance = parameters.PtmTolerance;
            var ptmCodeVar = parameters.PtmCodeVar;
            var ptmCodeFix = parameters.PtmCodeFix;
            var clevageType = parameters.InsilicoFragType;
            var ions = parameters.HandleIons;
            var peakList = peakData.Mass;
            var insilicoTol = parameters.HopThreshhold;
            var mwWeight = parameters.MwSweight;
            var pstWeight = parameters.PstSweight;
            var insilicoWeight = parameters.InsilicoSweight;

            var filteredSitesA = new List<PostTranslationModificationsSiteDto>(); // for the variable modifications
            var filteredSitesB = new List<PostTranslationModificationsSiteDto>(); // for the fixed modifications
            var filteredSitesC = new List<PostTranslationModificationsSiteDto>(); // for both kind of modifications
            var curveV = new List<double>(); // for the variable modifications
            var curveF = new List<double>(); // for the fixed modifications
            var curveVarFix = new List<double>(); // for both kind of modifications
            var indicesV = new List<int>(); // and so on
            var indicesF = new List<int>();
            var indicesVarFix = new List<int>();
            double totalScoreVar = 0;
            double totalScoreFix = 0;
            double totalScoreVarFix = 0;

            //string typeCode = "";

            if (ptmCodeVar.Count != 0)
            {
                foreach (var p in input)
                {
                    filteredSitesA.Clear(); // resetting all variables before calling another protein
                    filteredSitesB.Clear();
                    filteredSitesC.Clear();
                    curveV.Clear();
                    curveF.Clear();
                    curveVarFix.Clear();
                    indicesV.Clear();
                    indicesF.Clear();
                    indicesVarFix.Clear();
                    totalScoreVar = 0;
                    totalScoreFix = 0;
                    totalScoreVarFix = 0;
                    totalScoreVar = variable_mods_2(curveV, p.Sequence, filteredSitesA, tolerance, indicesV,
                        modifiedProteins, ptmCodeVar, p, shortlistedProt, clevageType, ions, peakList, insilicoTol,
                        mwWeight, pstWeight, insilicoWeight);
                    p.PtmScore = totalScoreVar;

                    if (shortlistedProt.Count >= 50000)
                    {
                        FinalFilter(shortlistedProt);
                    }
                }
            }

            if (ptmCodeFix.Count != 0)
            {
                foreach (var p in input)
                {
                    //filtered_sitesA.Clear();        // resetting all variables before calling another protein
                    filteredSitesB.Clear();
                    filteredSitesC.Clear();
                    curveV.Clear();
                    curveF.Clear();

                    //indicesV.Clear();
                    indicesF.Clear();

                    totalScoreVar = 0;
                    totalScoreFix = 0;

                    totalScoreFix = fixed_mods_2(curveF, p.Sequence, filteredSitesB, tolerance, indicesF,
                        modifiedProteins, ptmCodeFix, p, shortlistedProt, clevageType, ions, peakList, insilicoTol,
                        mwWeight, pstWeight, insilicoWeight);
                    p.PtmScore
                        = totalScoreFix;

                    var counter = shortlistedProt.Count;
                    var fixProtIndex = shortlistedProt.Count - 1;
                    make_mod_proteins_2(filteredSitesA, modifiedProteins, indicesV,
                        shortlistedProt.ElementAt(shortlistedProt.Count - 1), shortlistedProt, clevageType, ions,
                        peakList, insilicoTol, mwWeight, pstWeight, insilicoWeight);

                    //modified_proteins.ElementAt(0).ptm_particulars = new List<Sites>();
                    //int counter = modified_proteins.Count - 1;
                    /*bool con = false;
                    List<Sites> dummyList = new List<Sites>();
                    foreach (Sites abc in modified_proteins.ElementAt(fix_prot_index).ptm_par
                        {
                            con = false;

                            dummyList.Add(filtered_sitesA.ElementAt(indicesV.ElementAt(x)));
                        }
                        else if (indicesV.ElementAt(x) == 777)
                        {
                            if (con == false)
                            {
                                modified_proteins.ElementAt(counter).ptm_particulars = new List<Sites>();
                                con = true;
                            }

                            foreach (Sites site in dummyList)
                            {
                                modified_proteins.ElementAt(counter).ptm_particulars.Add(site);
                            }

                            //modified_proteins.ElementAt(counter).ptm_particulars.AddRange(dummyList);
                            counter++;
                            dummyList.Clear();
                            foreach (Sites abc in modified_proteins.ElementAt(fix_prot_index).ptm_particulars)
                                dummyList.Add(abc);
                        }
                    }*/
                }
            }
        }        

        public void PTMTruncation_Modification(List<ProteinDto> CandidateProtListInput, MsPeaksDto peakData, SearchParametersDto parameters, string FunctionType)
        {
            //Making a 2D list(peakDatalist) in which Mass & Intensity includes 
            var peakDatalist = new List<peakData2Dlist>();
            List<ProteinDto> CandidateProtListOutput = new List<ProteinDto>();
            for (int row = 0; row < peakData.Mass.Count; row++)
            {
                var dataforpeakDatalist = new peakData2Dlist(peakData.Mass[row], peakData.Intensity[row]);
                peakDatalist.Add(dataforpeakDatalist);
            }
            //Sorting the peakDatalist with respect to the Mass in ascending order
            var ExperimentalSpectrum = peakDatalist.OrderBy(n => n.Mass).ToList();
            var MolW = peakData.Mass[peakData.Mass.Count - 1];    // Molar weight that is the last row of the peak list
            double tolConv = 0;
            string cleavageType = parameters.InsilicoFragType;

            // if size of peakData is 1, then tolConv is equal to that one mass value, else it is the second-last mass value from the sorted peakData list
            if (peakData.Mass.Count == 1)
            {
                tolConv = peakData.Mass[peakData.Mass.Count - 1];
            }
            else
            {
                tolConv = peakData.Mass[peakData.Mass.Count - 2];
            }
            var PeptideTolerance = parameters.PeptideTolerance;
            var PeptideToleranceUnit = parameters.PeptideToleranceUnit;
            double tol = 0;
            if (PeptideToleranceUnit == "ppm")
                tol = (tol / tolConv) * 1000000;
            else if (PeptideToleranceUnit == "%")
                tol = (tol / tolConv) * 100;

            for (int index = 0; index < CandidateProtListInput.Count; index++)
            {
                var protein = CandidateProtListInput.ElementAt(index);
                var TruncationMass = protein.Mw - MolW;
                if (cleavageType == "CID" || cleavageType == "IMD" || cleavageType == "BIRD" || cleavageType == "SID" || cleavageType == "HCD")
                {
                    if (FunctionType == "Truncation_Left_Modification")
                        TruncationMass = TruncationMass + MassAdjustment.Proton;
                    else if (FunctionType == "Truncation_Right_Modification")
                        TruncationMass = TruncationMass + MassAdjustment.OH + 2 * MassAdjustment.H;
                }
                else if (cleavageType == "ECD" || cleavageType == "ETD")
                {
                    if (FunctionType == "Truncation_Left_Modification")
                        TruncationMass = TruncationMass + MassAdjustment.Proton + MassAdjustment.N + 3 * MassAdjustment.H;
                    else if (FunctionType == "Truncation_Right_Modification")
                        TruncationMass = TruncationMass + MassAdjustment.OH - MassAdjustment.NH;
                }
                else if (cleavageType == "EDD" || cleavageType == "NETD")
                {
                    if (FunctionType == "Truncation_Left_Modification")
                        TruncationMass = TruncationMass + MassAdjustment.Proton - MassAdjustment.CO;
                    else if (FunctionType == "Truncation_Right_Modification")
                        TruncationMass = TruncationMass + MassAdjustment.OH + MassAdjustment.CO;
                }

                if (TruncationMass > 0)
                {
                    var Index = -1;
                    for (int ind = 1; ind < protein.Sequence.Length; ind++)
                    {
                        if (FunctionType == "Truncation_Left_Modification")
                        {
                            var diff_left = protein.InsilicoDetails.InsilicoMassLeft[ind] - TruncationMass;
                            if (Math.Abs(diff_left) <= tol)
                                Index = ind;
                            else if (Math.Abs(diff_left) > tol)
                                break;
                        }
                        else if (FunctionType == "Truncation_Right_Modification")
                        {
                            var diff_right = protein.InsilicoDetails.InsilicoMassRight[ind] - TruncationMass;
                            if (Math.Abs(diff_right) <= tol)
                                Index = ind;
                            else if (Math.Abs(diff_right) > tol)
                                break;
                        }
                    }
                    if (Index != -1)
                    {
                        if (FunctionType == "Truncation_Left_Modification")
                        {
                            protein.Truncation = "Left";

                            protein.InsilicoDetails.InsilicoMassLeft = protein.InsilicoDetails.InsilicoMassLeft.Select(x => x - protein.InsilicoDetails.InsilicoMassLeft[Index]).ToList();

                            protein.InsilicoDetails.InsilicoMassLeft = protein.InsilicoDetails.InsilicoMassLeft.GetRange(Index + 1, protein.InsilicoDetails.InsilicoMassLeft.Count - Index - 1);

                            protein.InsilicoDetails.InsilicoMassRight = protein.InsilicoDetails.InsilicoMassRight.GetRange(0, protein.Sequence.Length - Index - 1); // as this will be the MW of protein - Water

                            var sequence = protein.Sequence.Substring(Index + 1, protein.Sequence.Length - Index - 1);
                            protein.Sequence = sequence;
                            if (sequence.Length < 5)
                                continue;

                            protein.TruncationIndex = protein.TruncationIndex + Index;
                            protein.Mw = protein.InsilicoDetails.InsilicoMassRight[protein.Sequence.Length - 1] + MassAdjustment.H + MassAdjustment.H + MassAdjustment.O;

                            CandidateProtListOutput.Add(protein);
                        }
                        else if (FunctionType == "Truncation_Right_Modification")
                        {
                            var truncationIndex = protein.Sequence.Length - Index;
                            protein.Truncation = "Right";
                            protein.InsilicoDetails.InsilicoMassLeft = protein.InsilicoDetails.InsilicoMassLeft.GetRange(0, truncationIndex - 1);

                            protein.InsilicoDetails.InsilicoMassRight = protein.InsilicoDetails.InsilicoMassRight.Select(x => x - protein.InsilicoDetails.InsilicoMassRight[Index]).ToList(); // as this will be the MW of protein - Water

                            protein.InsilicoDetails.InsilicoMassRight = protein.InsilicoDetails.InsilicoMassRight.GetRange(Index + 1, protein.InsilicoDetails.InsilicoMassRight.Count - Index - 1);

                            var sequence = protein.Sequence.Substring(0, truncationIndex - 1);
                            protein.Sequence = sequence;

                            if (sequence.Length < 5)
                                continue;

                            protein.TruncationIndex = truncationIndex - 2;  // "-1" is Added for Zero Indexing of C#
                            protein.Mw = protein.InsilicoDetails.InsilicoMassRight[protein.Sequence.Length - 1] + MassAdjustment.H + MassAdjustment.H + MassAdjustment.O;
                            CandidateProtListOutput.Add(protein);
                        }
                    }
                }
            }
        }

        
                
        //private IEnumerable<int[]> CombinationsRosettaWoRecursion(int m, int n)
        //{
        //    int[] result = new int[m];
        //    Stack<int> stack = new Stack<int>(m);
        //    stack.Push(0);
        //    while (stack.Count > 0)
        //    {
        //        int index = stack.Count - 1;
        //        int value = stack.Pop();
        //        while (value < n)
        //        {
        //            result[index++] = value++;
        //            stack.Push(value);
        //            if (index != m) continue;
        //            yield return (int[])result.Clone(); // thanks to @xanatos
        //            //yield return result;
        //            break;
        //        }
        //    }
        //}
        //public IEnumerable<T[]> CombinationsRosettaWoRecursionArray<T>(T[] array, int m)
        //{
        //    if (array.Length < m)
        //        throw new ArgumentException("Array length can't be less than number of selected elements");
        //    if (m < 1)
        //        throw new ArgumentException("Number of selected elements can't be less than 1");
        //    T[] result = new T[m];
        //    foreach (int[] j in CombinationsRosettaWoRecursion(m, array.Length))
        //    {
        //        for (int i = 0; i < m; i++)
        //        {
        //            result[i] = array[j[i]];
        //        }
        //        yield return result;
        //    }
        //}

        public void PTMs_Generator_Insilico_Generator(ProteinDto protein, SearchParametersDto parameters)
        {
            ProteinDto ModifiedProtein = new ProteinDto();
            List<ProteinDto> ModifiedProtSeq = new List<ProteinDto>();

            List<PostTranslationModificationsSiteDto> All_Cys = new List<PostTranslationModificationsSiteDto>();
            List<PostTranslationModificationsSiteDto> All_Mets = new List<PostTranslationModificationsSiteDto>();
            List<PostTranslationModificationsSiteDto> All_Var_PTMs = new List<PostTranslationModificationsSiteDto>();
            List<PostTranslationModificationsSiteDto> All_Fix_PTMs = new List<PostTranslationModificationsSiteDto>();


            if (parameters.CysteineChemicalModification == "Cys_CAM")
                All_Cys = _Cys_CAM.Cys_CAM(protein.Sequence, parameters.PtmTolerance);
            else if (parameters.CysteineChemicalModification == "Cys_CM")
                All_Cys = _Cys_CM.Cys_CM(protein.Sequence, parameters.PtmTolerance);
            else if (parameters.CysteineChemicalModification == "Cys_PE")
                All_Cys = _Cys_PE.Cys_PE(protein.Sequence, parameters.PtmTolerance);
            else if (parameters.CysteineChemicalModification == "Cys_PAM")
                All_Cys = _Cys_PAM.Cys_PAM(protein.Sequence, parameters.PtmTolerance);

            if (parameters.MethionineChemicalModification == "MSO")
                All_Mets = _MSO.MSO(protein.Sequence, parameters.PtmTolerance);
            else if (parameters.MethionineChemicalModification == "MSONE")
                All_Mets = _MSONE.MSONE(protein.Sequence, parameters.PtmTolerance);
            
            if (parameters.PtmAllow != "True")
            {
                //parameters.VariableModifications = new List<string>{"Acetylation_A", "Acetylation_K", "Acetylation_S", "Hydroxylation_P", "Methylation_K", 
                //    "Methylation_R", "N_Linked_Glycosylation_N", "O_Linked_Glycosylation_S", "O_Linked_Glycosylation_T", "Phosphorylation_S", "Phosphorylation_T",
                //"Phosphorylation_Y"};  ///Hard Code For the time being...//Momina!!

                var NumOfVarMods = parameters.VariableModifications.Count; /// parameters.PtmCodeVar.Count;
                for (int varModIndex = 0; varModIndex < NumOfVarMods; varModIndex++)   // Should Start from Zero Index
                {
                    var TypeOfModification = parameters.VariableModifications[varModIndex];
                    //List<PostTranslationModificationsSiteDto> ModSites = new List<PostTranslationModificationsSiteDto>();

                    var ModificationSite = _SwitchTypeOfPTM.SwitchToTypeOfPTM(TypeOfModification, protein.Sequence, parameters.PtmTolerance);


                    All_Var_PTMs.AddRange(ModificationSite);
                }
            }
            var NumOfFixMods = parameters.FixedModifications.Count; /// parameters.PtmCodeFix.Count;
            double FixedPTMTolerance = 0.0;
            for (int fixModIndex = 0; fixModIndex < NumOfFixMods; fixModIndex++)   // Should Start from Zero Index
            {
                var TypeOfModification = parameters.FixedModifications[fixModIndex];

                var ModificationSite = _SwitchTypeOfPTM.SwitchToTypeOfPTM(TypeOfModification, protein.Sequence, FixedPTMTolerance);

                All_Fix_PTMs.AddRange(ModificationSite);
            }
            All_Fix_PTMs.AddRange(All_Mets);
            All_Fix_PTMs.AddRange(All_Cys);

            var CombinedConsecutiveNumList = _Combinations.GetAllCombination(3);

            int count = All_Var_PTMs.Count;
            int[] array = new int[count];
            for (int i = 0; i < count; i++)
                array[i] = i;
            var passingstr = string.Join("", array);
            int[] AllCombinations = Combinations(passingstr, count);
            List<PostTranslationModificationsSiteDto> ModArray = new List<PostTranslationModificationsSiteDto>();
            for (int i = 0; i < AllCombinations.Length; i++)
            {
                int num = AllCombinations[i].ToString().Count();
                if (num == 1)
                {
                    int Index = AllCombinations[i];
                    ModArray.Add(All_Var_PTMs[i]);
                }
                else
                {
                    var StringCombination = AllCombinations[i].ToString();
                    for (int j = 0; j < num; j++)
                    {
                        var StringIndex = StringCombination[j];
                        var NumIndex = Convert.ToInt16(StringIndex);
                        ModArray.Add(All_Var_PTMs[i]);
                    }
                }
            }
            ModifiedProtein.PtmScore = 0;
            ModifiedProtein.InsilicoDetails.InsilicoMassLeft = protein.InsilicoDetails.InsilicoMassLeft;
            ModifiedProtein.InsilicoDetails.InsilicoMassRight = protein.InsilicoDetails.InsilicoMassRight;
            ModifiedProtein.Mw = protein.Mw;
            ModifiedProtein.TerminalModification = protein.TerminalModification;

            if (All_Fix_PTMs.Any())
            {
                for (int fixedIndex = 0; fixedIndex < All_Fix_PTMs.Count; fixedIndex++)
                {
                    for (int protIndex = 0; protIndex < protein.Sequence.Length - 1; protIndex++)
                    {
                        if (protIndex >= All_Fix_PTMs[protIndex].Index)
                        {
                            ModifiedProtein.InsilicoDetails.InsilicoMassLeft[protIndex] = ModifiedProtein.InsilicoDetails.InsilicoMassLeft[protIndex] + All_Fix_PTMs[fixedIndex].ModWeight;
                        }
                    }
                }
                for (int fixedIndex = 0; fixedIndex < All_Fix_PTMs.Count; fixedIndex++)
                {
                    ModifiedProtein.Mw = ModifiedProtein.Mw + All_Fix_PTMs[fixedIndex].ModWeight;
                }

                for (int fixedIndex = 0; fixedIndex < All_Fix_PTMs.Count; fixedIndex++)
                {
                    for (int protIndex = 0; protIndex < protein.Sequence.Length - 1; protIndex++)
                    {
                        var id = protein.Sequence.Length - All_Fix_PTMs[fixedIndex].Index;
                        if (protIndex >= id)
                        {
                            ModifiedProtein.InsilicoDetails.InsilicoMassRight[protIndex] = ModifiedProtein.InsilicoDetails.InsilicoMassRight[protIndex] + All_Fix_PTMs[fixedIndex].ModWeight;
                        }
                    }
                }
            }
            if (ModArray.Count == 0 && All_Fix_PTMs.Count != 0)
            {
                ModifiedProtein.Sequence = protein.Sequence;
                ModifiedProtein.Header = protein.Header;
                ModifiedProtein.Header = protein.Header;
                var PTMIndex = 0;
                for (int fixedIndex = 0; fixedIndex < All_Fix_PTMs.Count; fixedIndex++)
                {
                    PTMIndex = PTMIndex + 1;
                    ModifiedProtein.PtmScore = ModifiedProtein.PtmScore + All_Fix_PTMs[fixedIndex].Score;
                    ModifiedProtein.PtmParticulars.Add(new PostTranslationModificationsSiteDto(All_Fix_PTMs[fixedIndex].Index, All_Fix_PTMs[fixedIndex].ModName, All_Fix_PTMs[fixedIndex].Site));
                }
                ModifiedProtein.PstScore = protein.PstScore;
                var error = Math.Abs(protein.Mw - ModifiedProtein.Mw);
                if (error == 0)
                    ModifiedProtein.MwScore = 1;
                else
                    ModifiedProtein.MwScore = Math.Pow((1 / 2), error);

                ModifiedProtein.PtmScore = 1 - Math.Exp(-ModifiedProtein.PtmScore / 3);
                ModifiedProtSeq.Add(ModifiedProtein);
            }
            var MolW = ModifiedProtein.Mw;
            var left = ModifiedProtein.InsilicoDetails.InsilicoMassLeft;

            for (int index = 0; index < ModArray.Count; index++)
            {
                var ModifiedSite = ModArray[index];
                ModifiedProtein.Mw = ModifiedProtein.Mw + ModifiedSite.ModWeight;
                for (int protIndex = 0; protIndex < protein.Sequence.Length; protIndex++)
                {
                    if (protIndex >= ModifiedSite.Index)
                        ModifiedProtein.InsilicoDetails.InsilicoMassLeft[protIndex] = ModifiedProtein.InsilicoDetails.InsilicoMassLeft[protIndex] + ModifiedSite.ModWeight;
                }
            }
            for (int InsilicoIndex = 0; InsilicoIndex < ModifiedProtein.InsilicoDetails.InsilicoMassLeft.Count; InsilicoIndex++)
            {
                ModifiedProtein.InsilicoDetails.InsilicoMassRight[InsilicoIndex] = ModifiedProtein.Mw - MassAdjustment.H2O - ModifiedProtein.InsilicoDetails.InsilicoMassLeft[InsilicoIndex];
            }
            ModifiedProtein.Sequence = protein.Sequence;
            ModifiedProtein.Header = protein.Header;

            for (int PTMIndex = 0; PTMIndex < ModArray.Count; PTMIndex++)
            {
                var ModifiedSite = ModArray[PTMIndex];
                ModifiedProtein.PtmScore = ModifiedProtein.PtmScore + ModifiedSite.Score;
                ModifiedProtein.PtmParticulars.Add(new PostTranslationModificationsSiteDto(ModifiedSite.Index, ModifiedSite.ModName, ModifiedSite.Site));
            }

            for (int fixedIndex = 0; fixedIndex < All_Fix_PTMs.Count; fixedIndex++)
            {
                //ModifiedProtein.PtmParticulars.Index.Add(All_Fix_PTMs[fixedIndex].Index);
                ModifiedProtein.PtmScore = ModifiedProtein.PtmScore + All_Fix_PTMs[fixedIndex].Score;
                //ModifiedProtein.PtmParticulars.Site.Add(All_Fix_PTMs[fixedIndex].Site); 
                //ModifiedProtein.PtmParticulars.ModName.Add(All_Fix_PTMs[fixedIndex].ModName); 
                ModifiedProtein.PtmParticulars.Add(new PostTranslationModificationsSiteDto(All_Fix_PTMs[fixedIndex].Index, All_Fix_PTMs[fixedIndex].ModName, All_Fix_PTMs[fixedIndex].Site));
            }
            ModifiedProtein.PstScore = protein.PstScore;
            var Error = Math.Abs(protein.Mw - ModifiedProtein.Mw);
            if (Error == 0)
                ModifiedProtein.MwScore = 1;
            else
                ModifiedProtein.MwScore = Math.Pow((1 / 2), Error);

            ModifiedProtein.PtmScore = 1 - Math.Exp(-ModifiedProtein.PtmScore / 3);
            ModifiedProtSeq.Add(ModifiedProtein);
        }

        
       
        public int[] Combinations(string passingstr, int count)
        {
            string[] returnArray = new string[] { };
            if (passingstr.Length == 1)
                Convert.ToInt32(passingstr);
            char c = passingstr[passingstr.Length - 1];
            //if(passingstr.Length - 1 != 0) //Was Added for testing...
                returnArray = Array.ConvertAll(Combinations(passingstr.Substring(0, passingstr.Length - 1), count), x => x.ToString());
            List<string> finalArray = new List<string>();
            foreach (string s in returnArray)
                finalArray.Add(s);
            finalArray.Add(c.ToString());
            int j = 0;
            foreach (string s in returnArray)
            {
                finalArray.Add(s + c);
                finalArray.Add(c + s);
            }
            returnArray = finalArray.ToArray();
            foreach (string s in returnArray)
            {
                if (passingstr.Length == count)
                {
                    if (s.Length < passingstr.Length - 1)
                    {
                        foreach (char k in passingstr)
                        {
                            foreach (char m in passingstr)
                            {
                                if (k != m && !s.Contains(k) && !s.Contains(m))
                                {
                                    finalArray.Add(s + k);
                                    finalArray.Add(s + m + k);
                                    finalArray.Add(m.ToString() + k.ToString());
                                    finalArray.Add(m + s + k);
                                }
                            }
                        }
                    }
                }
                j++;
            }
            //Converting the string array to int array    
            int[] retarr = (Array.ConvertAll(finalArray.ToArray(), int.Parse)).Distinct().ToArray();
            //Sorting array    
            Array.Sort(retarr);
            return retarr;
        }
    }
}

