import { ErrorHandler, Injectable } from "@angular/core";
import { NotifierService } from "angular-notifier";
@Injectable()
export class AppErrorHandler implements ErrorHandler {

    constructor(private notifier: NotifierService) {


    }
    handleError(error: any): void {
        this.notifier.notify('success', 'You are awesome! I mean it!');

    }

}