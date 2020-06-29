/*** Modelo para realizar una compra */
export class CompraRequest{
    FamiliaId;
    TiendaId;
    ProductoId;
    Cantidad;
    Confirmacion;
    Dni;
    FechaCompra;
  }
  
  export class UpdateRequest{
    FamiliaId;
    TiendaId;
    ProductoId;
    Cantidad;
    Confirmacion;
    Dni;
    FechaCompra;
  }
  
  export class CompraGet{
    nombreFamilia;
    ProductoId;
    Cantidad;
    FechaCompra;
  }