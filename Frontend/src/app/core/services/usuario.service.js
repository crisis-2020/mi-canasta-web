import axios from "axios";
import { environments } from "../../environments/environments";

export default class UsuarioService {
    static async getUsuario(dni) {
        return await axios.get(`${environments.api}/usuarios/${dni}`);
    }
    static async putUsuario(dni, usuarioPut) {
        return await axios.put(`${environments.api}/usuarios/${dni}`, usuarioPut);
    }
    static async cambiarRolUsuario(dni){
        return await axios.put(`${environments.api}/usuarios/${dni}/RolesPorUsuario`);
    }
}