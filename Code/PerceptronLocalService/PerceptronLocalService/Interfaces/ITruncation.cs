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
        void PreTruncation(double IntactProteinMass, double MwTolerance, List<string> IndividualModifications, List<ProteinDto> CandidateProteinListTruncated, List<ProteinDto> CandidateProteinListTruncatedLeft, List<ProteinDto> CandidateProteinListTruncatedRight, List<newMsPeaksDto> peakData2DList);

        void TruncationLeft(double IntactProteinMass, string PtmAllow, List<ProteinDto> CandidateProteinListTruncatedLeft, List<ProteinDto> CandidateListTruncationLeftProcessed, List<ProteinDto> RemainingProteinsLeft, List<newMsPeaksDto> peakData2DList);

        void TruncationRight(double IntactProteinMass, string PtmAllow, List<ProteinDto> CandidateProteinListTruncatedRight, List<ProteinDto> CandidateListTruncationRightProcessed, List<ProteinDto> RemainingProteinsRight, List<newMsPeaksDto> peakData2DList);

        List<ProteinDto> FilterTruncatedProteins(SearchParametersDto parameters, List<ProteinDto> CandidateProteinListUnModified, List<PstTagList> PstTags);
    }
}
