import axios from "axios";
import { environments } from "../../environments/environments";
export default class UsuarioService {
    static async getUsuario(dni) {
        return await axios.get(`${environments.api}/usuarios/${dni}`);
    }

    static async getSolicitudes(id) {
        return await axios.get(`${environments.api}/usuarios/${dni}/solicitudes`);
    }

    static async cancelarSolicitud(dni, idFamilia) {
        return await axios.delete(`${environments.api}/usuarios/${dni}/familia/${idFamilia}`);
    }

}