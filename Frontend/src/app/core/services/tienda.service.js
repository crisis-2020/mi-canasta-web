import axios from "axios";
import { environments } from "../../environments/environments";

export default class TiendaService {

    static async listarTienda(idTienda) {
        return await axios.get(`${environments.api}/tiendas/${idTienda}`);
    }

    static async getUsuariosByTiendaId(idTienda) {
        return await axios.get(`${environments.api}/tiendas/${idTienda}/usuarios`);
    }

    static async agregarSeller(idTienda, dni){
        return await axios.post(`${environments.api}/tiendas/${idTienda}/usuario/${dni}/usuariosportienda`);
    }

    static async GetLimiteTienda(idTienda) {
        return await axios.get(`${environments.api}/tiendas/${idTienda}/limite`);
    }

    static async putTienda(idTienda, dni, putTienda) {
        return await axios.put(`${environments.api}/tiendas/${idTienda}/${dni}`, putTienda);
    }

}

