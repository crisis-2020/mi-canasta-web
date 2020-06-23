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

    static async deleteUsuariofromFamilia(nombreFamilia, dni) {
        return await axios.delete(`${environments.api}/familias/${nombreFamilia}/usuarios/${dni}`);
    }

    static async desactivarSolicitud(idFamilia){
        return await axios.put(`${environments.api}/familias/${idFamilia}`);
    }
}