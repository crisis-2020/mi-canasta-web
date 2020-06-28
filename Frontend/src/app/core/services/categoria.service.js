import axios from "axios";
import { environments } from "../../environments/environments";

export default class CategoriaService {
    static async getCategoria(CategoriaId) {
        return await axios.get(`${environments.api}/categorias/${CategoriaId}`);
    }
}