using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using PrestamosServicios.Dominio;
using PrestamosServicios.Persistencia;

namespace PrestamosServicios
{
    public class Modelos : IModelos
    {
        private ModeloDAO modeloDAO = null;
        private ModeloDAO ModeloDAO
        {
            get
            {
                if (modeloDAO == null)
                    modeloDAO = new ModeloDAO();
                return modeloDAO;
            }
        }

        public Modelo CrearModelo(string modelo)
        {
            Modelo modeloACrear = new Modelo()
            {
                Model = modelo,
            };
            return ModeloDAO.Crear(modeloACrear);
        }

        public void EliminarModelo(int codigo)
        {
            Modelo modeloExistente = ModeloDAO.Obtener(codigo);
            ModeloDAO.Eliminar(modeloExistente);
        }

        public List<Modelo> ListarModelo()
        {
            return ModeloDAO.ListarTodos().ToList();
        }

        public Modelo ModificarModelo(int codigo, string modelo)
        {
            Modelo modeloAModificar = new Modelo()
            {
                Codigo = codigo,
                Model = modelo,
            };
            return ModeloDAO.Modificar(modeloAModificar);
        }

        public Modelo ObtenerModelo(int codigo)
        {
            return ModeloDAO.Obtener(codigo);
        }
    }
}
