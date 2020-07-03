import { listCities } from './Const/CountriesAndCities';

export default class Utils{
    static getCountries(){
        var arr = listCities;
        var listCountry = [];
        arr.forEach(country => {
            listCountry.push(country);
        });
        return listCountry;
    }
}