﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PerceptronLocalService.DTO;

namespace PerceptronLocalService.Interfaces
{
    public interface ITruncation
    {
        void PreTruncation(SearchParametersDto parameters, List<ProteinDto> CandidateProteinListTruncated, List<ProteinDto> CandidateProteinListTruncatedLeft, List<ProteinDto> CandidateProteinListTruncatedRight, List<newMsPeaksDto> peakData2DList);

        void TruncationLeft(SearchParametersDto parameters, List<ProteinDto> CandidateProteinListTruncatedLeft, List<ProteinDto> CandidateListTruncationLeftProcessed, List<ProteinDto> RemainingProteinsLeft, List<newMsPeaksDto> peakData2DList);

        void TruncationRight(SearchParametersDto parameters, List<ProteinDto> CandidateProteinListTruncatedRight, List<ProteinDto> CandidateListTruncationRightProcessed, List<ProteinDto> RemainingProteinsRight, List<newMsPeaksDto> peakData2DList);

        //(List<ProteinDto> CandidateProteinListTruncatedLeft, List<ProteinDto> CandidateListTruncationLeftProcessed, List<ProteinDto> RemainingProteinsLeft, List<newMsPeaksDto> peakData2DList)

        //void TruncationRight(List<ProteinDto> CandidateProteinListTruncatedRight, List<ProteinDto> CandidateListTruncationRightProcessed, List<ProteinDto> RemainingProteinsRight, List<newMsPeaksDto> peakData2DList);


        //void TruncationRight(List<ProteinDto> CandidateProteinListTruncatedLeft, List<newMsPeaksDto> peakData2DList);





        //void PreTruncation(List<ProteinDto> proteinList, MsPeaksDto peakData, SearchParametersDto parameters,
        //    List<ProteinDto> proteinListLeft, List<ProteinDto> proteinListRight

        //void TruncationLeft(List<ProteinDto> proteinList, MsPeaksDto peakData, SearchParametersDto parameters,
        //    List<ProteinDto> proteinListTruncated, List<ProteinDto> proteinListRemaining);

        //void TruncationRight(List<ProteinDto> proteinList, MsPeaksDto peakData, SearchParametersDto parameters,
        //    List<ProteinDto> proteinListTruncated, List<ProteinDto> proteinListRemaining);

        //void TruncationLeftWithMoification(List<ProteinDto> proteinList, MsPeaksDto peakData,
        //    SearchParametersDto parameters, List<ProteinDto> proteinListTruncated);

        //void TruncationRightWithModification(List<ProteinDto> proteinList, MsPeaksDto peakData,
        //    SearchParametersDto parameters, List<ProteinDto> proteinListTruncated);
    }
}
