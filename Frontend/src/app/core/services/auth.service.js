import axios from "axios";
import { environments } from "../../environments/environments";
export default class AuthService {
  /**
   * EJEMPLO PARA GET
   */

  // static async autenticacion(dni) {
  //     return await axios({
  //         url: `${environments.api}/${dni}`,
  //         method: "GET"
  //     })
  // }

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
}
