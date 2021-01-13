import { GetGenderInformationModel } from '../common/GetGenderInformationModel'

export class GetPatientInformationModel {
    id: string
    fullName: string
    email: string
    age: string
    phone: string
    gender: GetGenderInformationModel
    history: string
    caseNo: string
    photoPath: string
}