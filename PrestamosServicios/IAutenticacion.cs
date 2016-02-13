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
    public interface IAutenticacion
    {
        [OperationContract]
        User VerificarExistenciaUsuario(string usuario, string password);
        [FaultContract(typeof(PasswordIncorrectaExcepcion))]
        [OperationContract]
        int VerificarPassword(User usuarioConUsername, string password);
        [OperationContract]
        int ObtenerTipoUsuario(User usuarioLogeado);
    }
}
