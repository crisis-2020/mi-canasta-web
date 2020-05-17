import axios from "axios";
import { environments } from "../../environments/environments";
export default class FamiliaService {
    static async crearFamilia(familiaRequest) {
        return await axios
            .post(`${environments.api}/familias`, familiaRequest)
    }
}