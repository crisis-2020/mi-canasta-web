import axios from "axios";
import { environments } from "../../environments/environments";

export default class StockService {
    static async getStocks(idTienda) {
        return await axios.get(`${environments.api}/tiendas/${idTienda}/stocks`);
    }
}