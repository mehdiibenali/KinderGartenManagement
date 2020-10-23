export class PayementDates {
    datededebut:any;
    datedefin:any;
    ListOfMonths:any[];
    year:number;
    month:any;
    constructor(){
        this.ListOfMonths=[];
        this.year=new Date().getFullYear();
        this.month=new Date().toLocaleString("fr", { month: "long" });
    }
}
