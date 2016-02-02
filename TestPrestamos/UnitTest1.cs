using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestPrestamos.equiposWS;
using System.ServiceModel;
using System.Collections.Generic;

namespace TestPrestamos
{
    [TestClass]
    public class UnitTest1
    {
        //prueba
        [TestMethod]
        public void TestCrear()
        {
            equiposWS.EquiposClient proxy = new equiposWS.EquiposClient();
            Equipo creado = proxy.CrearEquipo(2, "P01022016", 2);
            Assert.IsNotNull(creado);
        }

        [TestMethod]
        public void TestCrearEquipoExcepcion()
        {
            equiposWS.EquiposClient proxy = new equiposWS.EquiposClient();
            try
            {
                proxy.CrearEquipo(2, "12345", 4);
            }
            catch (FaultException<equiposWS.ExcepcionEquipo> fe)
            {
                Assert.AreEqual("01", fe.Detail.Cod);
            }
        }

        [TestMethod]
        public void TestEliminar()
        {
            equiposWS.EquiposClient proxy = new equiposWS.EquiposClient();
            proxy.EliminarEquipo(1);
            Equipo eliminado = proxy.ObtenerEquipo(1);
            Assert.IsNull(eliminado);
        }

        [TestMethod]
        public void TestListar()
        {
            equiposWS.EquiposClient proxy = new equiposWS.EquiposClient();
            Equipo[] Lista = proxy.ListarEquipos();
            Assert.AreEqual(0,Lista.Length);
        }
    }
}
