import { GetGenderInformationModel } from '../common/GetGenderInformationModel'

export class PatientInformationBaseModel {
    id: string
    firstName: string
    lastName: string
    email: string
    age: string
    phone: string
    gender: GetGenderInformationModel
    history: string
    caseNo: string
}