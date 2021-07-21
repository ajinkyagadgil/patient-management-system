import { PatientInformationBaseModel } from '../patient/PatientInformationBaseModel';

export interface RecordInformationModel {
    id: string
    patientId: string
    treatment: string
    amount: number
    recordDate: Date
    patientInformation: PatientInformationBaseModel
}