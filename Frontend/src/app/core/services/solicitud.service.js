import axios from "axios";
import { environments } from "../../environments/environments";
export default class SolicitudService {
  static async crearSolicitud(solicitudRequest) {
    return await axios.post(
      `${environments.api}/solicitudes`,
      solicitudRequest
    );
  }
  static async obtenerSolicitudes(dni) {
    return await axios.get(`${environments.api}/solicitudes?Dni=${dni}`);
  }
  static async denegarSolicitud(dni) {
    return await axios.delete(`${environments.api}/solicitudes/${dni}`);
  }
  static async aceptarSolicitud(solicitudResponse) {
    return await axios.post(
      `${environments.api}/usuariosporfamilia`,
      solicitudResponse
    );
  }
  static async obtenerSolicitudesPorFamilia(familiaId) {
    return await axios.get(
      `${environments.api}/solicitudes?IdFamilia=${familiaId}`
    );
  }
}
