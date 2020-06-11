import axios from "axios";
import { environments } from "../../environments/environments";
export default class UsuarioService {
    static async getUsuario(dni) {
        return await axios.get(`${environments.api}/usuarios/${dni}`);
    }
}