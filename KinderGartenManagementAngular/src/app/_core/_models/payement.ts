import { Modalite } from './modalite';
import { PayementEnrollement } from './payement-enrollement';

export class Payement {
    receiptnumber:number;
    payementenrollementmodels:PayementEnrollement[];
    modalitemodels:Modalite[];
    constructor(){
        this.modalitemodels=[new Modalite()];
    }
}
