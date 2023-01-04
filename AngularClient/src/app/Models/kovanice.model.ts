export class kovanice{
    id: number;
    weight: number;
    name: string;
    countryOfOrigin: string;
    manufactuer: string;
    price:string;

    constructor(id: number, weight: number, name: string, countryOfOrigin: string, manufactuer: string, price: string)
    {
        this.id = id;
        this.weight = weight;
        this.countryOfOrigin = countryOfOrigin;
        this.manufactuer = manufactuer;
        this.price = price;
    }
}