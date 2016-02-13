using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PrestamosServicios.Dominio;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;

namespace PrestamosServicios
{
    public class Autenticacion : IAutenticacion
    {
        public int ObtenerTipoUsuario(User usuarioLogeado)
        {
            throw new NotImplementedException();
        }

        public User VerificarExistenciaUsuario(string usuario, string password)
        {
            User userObtenido = new User();
            string direccion = "http://localhost:60474/Users.svc/Users/" + usuario;
            HttpWebRequest req2 = (HttpWebRequest)WebRequest
                .Create(direccion);
            req2.Method = "GET";
            try
            {
                HttpWebResponse res = (HttpWebResponse)req2.GetResponse();
                StreamReader reader = new StreamReader(res.GetResponseStream());
                string userJson2 = reader.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                userObtenido = js2.Deserialize<User>(userJson2);

            }
            catch (WebException e)
            {
                HttpStatusCode code = ((HttpWebResponse)e.Response).StatusCode;
                string message = ((HttpWebResponse)e.Response).StatusDescription;
                StreamReader reader = new StreamReader(e.Response.GetResponseStream());
                string error = reader.ReadToEnd();
                JavaScriptSerializer js2 = new JavaScriptSerializer();
                string mensaje = js2.Deserialize<string>(error);

            }

            return userObtenido;
        }

        public int VerificarPassword(User usuarioConUsername, string password)
        {
            if (usuarioConUsername.Password != password)
            {
                throw new FaultException<PasswordIncorrectaExcepcion>(
                    new PasswordIncorrectaExcepcion()
                    {
                        Codigo = "001",
                        Mensaje = "Contraseña errada"
                    },
                    new FaultReason("Validación de negocio"));
            }
            return usuarioConUsername.Tipo;
                
        }
    }
}
