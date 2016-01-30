using PrestamosServicios.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace PrestamosServicios
{
    [ServiceContract]
    public interface IEquipos
    {
        [FaultContract(typeof(ExcepcionEquipo))]
        [OperationContract]
        Equipo CrearEquipo(int modelo, string estado, int categoria);
        [OperationContract]
        Equipo ObtenerEquipo(int codigo);
        [OperationContract]
        Equipo ModificarEquipo(int codigo, int modelo, string estado, int categoria);
        [OperationContract]
        void EliminarEquipo(int codigo);
        [OperationContract]
        List<Equipo> ListarEquipos();
    }
}
    