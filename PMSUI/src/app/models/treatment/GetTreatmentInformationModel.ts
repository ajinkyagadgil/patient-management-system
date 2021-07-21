import { TreatmentBaseModel } from './TreatmentBaseModel';
import { FileInformationModel } from '../common/FileInformationModel';

export interface GetTreatmentInformationModel extends TreatmentBaseModel {
    treatmentFiles: FileInformationModel[]
}