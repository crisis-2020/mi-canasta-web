import axios from "axios";
import { environments } from "../../environments/environments";
export default class SolicitudService {
    static async crearSolicitud(solicitudRequest) {
        return await axios
            .post(`${environments.api}/solicitudes`, solicitudRequest)
    }
}