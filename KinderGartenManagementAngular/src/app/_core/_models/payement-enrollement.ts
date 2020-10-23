import { PayementDates } from './payement-dates';

export class PayementEnrollement {
    section:string;
    paid:number;
    payementid:number;
    comment:string;
    eleveid:number;
    eleveenrollementid:number;
    payementdatesmodels:PayementDates[];
    constructor(){
        this.payementdatesmodels=[];
    }
}
