import axios from "axios";
import { environments } from "../../environments/environments";

export default class ProductoService {
    static async getProducto(idProducto) {
        return await axios.get(`${environments.api}/productos/${idProducto}`);
    }
}