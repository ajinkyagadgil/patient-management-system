import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'filePath'
})
export class FilePathPipe implements PipeTransform {

  transform(basePath: string, filePath: string, fileName: string): string {
    let fileLocation: string;
    fileLocation.concat(basePath, filePath, "/", fileName)
    return fileLocation;
  }

}
