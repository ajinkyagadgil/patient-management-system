import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'genderToString'
})
export class GenderToStringPipe implements PipeTransform {
    transform(value: number): string {
        if(value == 1) {
            return 'Female'
        }
        else if(value == 2) {
            return 'Male'
        }
        else if(value == 3) {
            return 'Other'
        }
        else {
            return '-'
        }
    }
    
}