function Message = SearchQuery( BaseApiUrl )


import matlab.net.http.*
SendParameterAndUserInfo = RequestMessage('POST',[]);

PerceptronApiRegisterUserUrl =  BaseApiUrl + 'api/user/CallingPerceptronApi_LoginUserWithSearchQuery' %   CallingPerceptronApiRegisterUser'

EmailAddress = "farhan.biomedical.2022@gmail.com";
Password = "12345";
f = ':'


%%% ATTENTION!!! ALL PARAMETER VALUES ARE CASE SENSITIVE
%%% User will add values below...!!!
%Title
JobName = "Default Run";    % User can change the job title to one of their own choice

%FDRCutOff
FDRCutOff = "0.0"; % User can add values from 0-100

%ProteinDatabase : There are two Protein Databases in Perceptron Human & Ecoli
ProteinDatabase = "Human"; % User can also, select "Ecoli" as well 

%MassMode
MassMode = "M(Neutral)";  % User can also select MH+

%FilterDb
FilterDatabase = "True";     % User can also select "False"

%MwTolerance
ProteinMassTolerance = "500";   % User can select any desired tolerance value

%PeptideTolerance
PeptideTolerance = "15";    % User can select any desired tolerance value

% PeptideToleranceUnit
PeptideToleranceUnit = "ppm";   % User can also select "Da" or "mmu"

% Autotune
TuneIntactProteinMass = "False";    % User can also select "True" to enable intact protein mass tuning

% InsilicoFragType
InsilicoFragmentationType = "HCD";  % User can also select "CID", "ECD", "ETD", "EDD", "BIRD", "SID", "IMD" or "NETD"

% HandleIons
SpecialIons = "bo,bstar,yo,ystar";   
% User can select any or all of "bo,bstar,yo,ystar" for fragmentation types CID, IMD, BIRD, SID and HCD
% User can select any or all of "zo,zoo" for fragmentation types ECD and ETD
% User can select any or all of "ao,astar" for fragmentation types NETD and EDD
% Note: Order must be maintained while adding special ions

% DenovoAllow
DenovoAllow = "True";    % User can also select "False" to disable denovo sequencing

% MinimumPstLength
MinimumPeptideSequenceTagLength = "3";  % User can select any value ranging from 2 to 6

% MaximumPstLength
MaximumPeptideSequenceTagLength = "6"; % User can select any value ranging from 3 to 8

% HopThreshhold
PeptideSequenceTagHopThreshhold = "0.1";  % User can select any decimal value

% Hop_Tolerance_Unit
PeptideSequenceTag_Hop_Tolerance_Unit = "Da";  % User is only allowed to choose Dalton as units

% PSTTolerance
OverallPeptideSequenceTagTolerance = "0.45";    % User can select any decimal value

% Truncation
Truncation = "False";   % User can also select "True" to enable truncation of proteins

%TerminalModification
TerminalModification = "None,NME,NME_Acetylation,M_Acetylation";    % User can select any or all of these terminal modifications. Here NME is for N-Methionine Excision, NME_Acetylation is for N-Methionine Excision and Acetylation, and M_Acetylation is for N-Methionine Acetylation
% Note: Order must be maintained when adding terminal modifications

% PtmAllow
PostTranslationalModificationsAllow = "False";  % User can also select "True"to enable protein search on basis of protein translational modifications

% PtmTolerance
PostTranslationalModificationsTolerance = "0.5";    % User can select any decimal value

% List_of_Modifications
List_of_Modifications = "";

% Variable_Modifications
Variable_Modifications = "";    % User can select any or all modifications from "Acetylation_A,Acetylation_K,Acetylation_S,Amidation_F,Hydroxylation_P,Methylation_K,Methylation_R,N_Linked_Glycosylation_N,O_Linked_Glycosylation_T,O_Linked_Glycosylation_S,Phosphorylation_S,Phosphorylation_T,Phosphorylation_Y"

% MethionineChemicalModification
MethionineChemicalModification = "None";    % User can select any or all of "None,MSO,MSONE" where MSO being for Methionine Sulfoxide, and MSONE being for Methionine Sulfone 
% Note: Order must be maintained when adding methionine chemical modifications

% Fixed_Modification
Fixed_Modification = "";     % User can select any or all modifications from "Acetylation_A,Acetylation_K,Acetylation_S,Amidation_F,Hydroxylation_P,Methylation_K,Methylation_R,N_Linked_Glycosylation_N,O_Linked_Glycosylation_T,O_Linked_Glycosylation_S,Phosphorylation_S,Phosphorylation_T,Phosphorylation_Y"

% CysteineChemicalModification
CysteineChemicalModification = "None";  % User can select any or all of "None,Cys_CAM,Cys_PE,Cys_CM,Cys_PAM" where Cys_CAM being for Carboxyamidomethyl Cysteine, Cys_PE being for Pyridyl-Ethyl Cysteine, Cys_CM for Carboxymethyl Cysteine, and Cys_PAM for Propionamide Cysteine
% Note: Order must be maintained when adding cysteine chemical modifications

% MwSweight
MwScoringWeightage = "0";   % User can select the scoring weightage from 0 to 100

% PstSweight
PeptideSequenceTagScoringWeightage = "0";   % User can select the scoring weightage from 0 to 100

% InsilicoSweight
InsilicoScoringWeightage = "100";   % User can select the scoring weightage from 0 to 100

VariableModifications = "";

FixedModifications = "";

%%% User will add values above...!!!

ParameterValue = strcat(JobName,f,FDRCutOff,f,ProteinDatabase,f,MassMode,f,FilterDatabase,f,ProteinMassTolerance,f,PeptideTolerance,f,PeptideToleranceUnit,f,TuneIntactProteinMass,f,InsilicoFragmentationType,f,SpecialIons,f,DenovoAllow,f,MinimumPeptideSequenceTagLength,f,MaximumPeptideSequenceTagLength,f,PeptideSequenceTagHopThreshhold,f,PeptideSequenceTag_Hop_Tolerance_Unit,f,OverallPeptideSequenceTagTolerance,f,Truncation,f,TerminalModification,f,PostTranslationalModificationsAllow,f,PostTranslationalModificationsTolerance,f,List_of_Modifications,f,Variable_Modifications,f,MethionineChemicalModification,f,Fixed_Modification,f,CysteineChemicalModification,f,MwScoringWeightage,f,PeptideSequenceTagScoringWeightage,f,InsilicoScoringWeightage,f,VariableModifications,f,FixedModifications,f,EmailAddress,f,EmailAddress,f,Password);


SendParameterAndUserInfo.Body = ParameterValue;
Options = matlab.net.http.HTTPOptions('ConnectTimeout',1000);  %% 1000sec
Response = SendParameterAndUserInfo.send(PerceptronApiRegisterUserUrl, Options);

Message = Response.Body.Data;


end
