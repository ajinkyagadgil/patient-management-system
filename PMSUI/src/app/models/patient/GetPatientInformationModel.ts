import { GetGenderInformationModel } from '../common/GetGenderInformationModel'
import { GuidModel } from '../common/GuidModel'
import { FileInformationModel } from '../common/FileInformationModel'
import { PatientInformationBaseModel } from './PatientInformationBaseModel'

export class GetPatientInformationModel extends PatientInformationBaseModel {
    patientPhotoInformation: FileInformationModel
}