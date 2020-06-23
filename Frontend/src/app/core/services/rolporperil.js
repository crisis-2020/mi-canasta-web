
import axios from "axios";
import { environments } from "../../environments/environments";

export default class RolPorPerfilService {

    static async GetPerfilById(idRolPerfil) {
        return await axios.get(`${environments.api}/rolesporperfil/${{idRolPerfil}}`);
    }

}