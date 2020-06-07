import axios from "axios";
import { environments } from "../../environments/environments";
export default class FamiliaService {
    static async crearFamilia(familiaRequest) {
        return await axios
            .post(`${environments.api}/familias`, familiaRequest)
    }


    static async listarFamilia(id) {
        return await axios.get(`${environments.api}/familias/${id}`);
    }

    static async listarMiembrosDeFamilia(nombreFamilia) {
        return await axios.get(`${environments.api}/familias/${nombreFamilia}/usuarios`);
    }
}