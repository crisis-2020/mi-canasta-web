import axios from "axios";
import { environments } from "../../environments/environments";

export default class TiendaService {

    static async listarTienda(id) {
        return await axios.get(`${environments.api}/tiendas/${id}`);
    }

    static async getUsuariosByTiendaId(idTienda) {
        return await axios.get(`${environments.api}/tiendas/${idTienda}/usuarios`);
    }

    static async agregarSeller(idTienda, dni){
        return await axios.post(`${environments.api}/tiendas/${idTienda}/usuario/${dni}/usuariosportienda`);
    }
}

