import axios from "axios";
import { environments } from "../../environments/environments";

export default class CompraService {

    static async Create(compraRequest) {
        return await axios
            .post(`${environments.api}/compras`, compraRequest)
    }
    
    static async Update(updateRequest) {
        return await axios
        .put(`${environments.api}/compras`, compraRequest)
    }
}


