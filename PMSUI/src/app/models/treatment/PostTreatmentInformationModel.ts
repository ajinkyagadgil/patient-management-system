import { TreatmentBaseModel } from './TreatmentBaseModel';

export interface PostTreatmentInformationModel extends TreatmentBaseModel {
    treatmentFiles: File[]
}