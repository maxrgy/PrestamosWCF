﻿using PrestamosServicios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PrestamosServicios
{
    [ServiceContract]
    public interface IModelos
    {
        [OperationContract]
        Modelo CrearModelo(string modelo);
        [OperationContract]
        Modelo ObtenerModelo(int codigo);
        [OperationContract]
        Modelo ModificarModelo(int codigo, string modelo);
        [OperationContract]
        void EliminarModelo(int codigo);
        [OperationContract]
        List<Modelo> ListarModelo();
    }
}