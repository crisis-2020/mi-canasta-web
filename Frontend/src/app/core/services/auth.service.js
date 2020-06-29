import axios from "axios";
import { environments } from "../../environments/environments";
export default class AuthService {
  static async autenticacion(usuario) {
    return await axios({
      url: `${environments.api}/usuarios`,
      method: "POST",
      data: {
        dni: usuario.dni,
        contrasena: usuario.contrasena,
      },
    });
  }

  static getUsuarioAutenticacion() {
    return JSON.parse(sessionStorage.getItem("usuario"));
  }

  static saveUsuarioAutenticacion(usuarioAutenticacion) {
    sessionStorage.setItem("usuario", JSON.stringify(usuarioAutenticacion));
  }
}
