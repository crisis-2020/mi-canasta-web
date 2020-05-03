import axios from "axios";
import { environments } from "../../environments/environments";
export default class AuthService {


    static async autenticacion(dni) {
        return await axios({
            url: `https://reniec-api.herokuapp.com/ciudadanos/${dni}`,
            method: "GET"
        })
    }

    /**
     * EJEMPLOS PARA PETICIONES POST
     */
    
     static async PeticionPost(){
         return await axios({
             url: `${environments.api}/registro`,
             method: "POST",
             data:{
                "name": "Jair",
                "edad": 20
             }
         })
     }

}