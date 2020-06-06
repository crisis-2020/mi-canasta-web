import axios from "axios";
import { environments } from "../../environments/environments";
export default class SolicitudService {
    static async crearSolicitud(solicitudRequest) {
        return await axios
            .post(`${environments.api}/solicitudes`, solicitudRequest)
    }
    static async obtenerSolicitudes(dni) {
        return await axios
            .get(`${environments.api}/solicitudes/${dni}`)
    }
}