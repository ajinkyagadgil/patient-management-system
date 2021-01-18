import { GetGenderInformationModel } from '../common/GetGenderInformationModel'
import { GuidModel } from '../common/GuidModel'

export class GetPatientInformationModel {
    id: string = new GuidModel().Empty;
    firstName: string
    lastName: string
    email: string
    age: string
    phone: string
    gender: GetGenderInformationModel
    history: string
    caseNo: string
    photoPath: string
}