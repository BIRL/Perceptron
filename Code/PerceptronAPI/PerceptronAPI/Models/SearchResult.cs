//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PerceptronAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SearchResult
    {
        public string QueryId { get; set; }
        public string ResultId { get; set; }
        public string Header { get; set; }
        public string Sequence { get; set; }
        public double PstScore { get; set; }
        public double InsilicoScore { get; set; }
        public double PtmScore { get; set; }
        public double Score { get; set; }
        public double MwScore { get; set; }
        public double Mw { get; set; }
        public string FileId { get; set; }
        public string OriginalSequence { get; set; }
        public string PSTTags { get; set; }
        public string RightMatchedIndex { get; set; }
        public string RightPeakIndex { get; set; }
        public string RightType { get; set; }
        public string LeftMatchedIndex { get; set; }
        public string LeftPeakIndex { get; set; }
        public string LeftType { get; set; }
        public string InsilicoMassLeft { get; set; }
        public string InsilicoMassRight { get; set; }
        public string InsilicoMassLeftAo { get; set; }
        public string InsilicoMassLeftBo { get; set; }
        public string InsilicoMassLeftAstar { get; set; }
        public string InsilicoMassLeftBstar { get; set; }
        public string InsilicoMassRightYo { get; set; }
        public string InsilicoMassRightYstar { get; set; }
        public string InsilicoMassRightZo { get; set; }
        public string InsilicoMassRightZoo { get; set; }
        public string TerminalModification { get; set; }
        public string TruncationSite { get; set; }
        public int TruncationIndex { get; set; }
        public string FileUniqueId { get; set; }
        public double Evalue { get; set; }
        public string BlindPtmLocalization { get; set; }
        public int ProteinRank { get; set; }
    }
}
