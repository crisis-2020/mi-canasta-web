import axios from "axios";
import { environments } from "../../environments/environments";
export default class UsuarioService {

    static async deleteUsuariofromFamilia(dni, familiaId) {
        return await axios.delete(`${environments.api}/usuarios/${dni}/familia/${familiaId}`);
    }
}