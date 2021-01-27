import { GetPatientInformationModel } from './GetPatientInformationModel';

export interface PatientDialogModel {
    isFromHomeScreen: boolean,
    patientInformation: GetPatientInformationModel
}