using PresentacionBase;
using Servicio.RecursoHumano.TipoNovedadAgente;
using Servicio.RecursoHumano.TipoNovedadAgente.DTOs;
using System;
using System.Collections.Generic;

namespace PresentacionRecursoHumano
{
    public partial class _00018_ABM_TipoNovedadAgente : FormularioABM
    {
        TipoNovedadAgenteServicio _tipoNovedadAgente;

        public _00018_ABM_TipoNovedadAgente()
            : base("ABM Tipo de Novedad")
        {
            InitializeComponent();
            _tipoNovedadAgente = new TipoNovedadAgenteServicio();
        }

        public override void InsertarRegistro()
        {
            if (VerificarDatosObligatorios(new object[] { this.txtAbreviaturaCodigo, this.txtTipoNovedadAgente }))
            {
                try
                {
                    if (!VerificarSiExisteRegistro())
                    {
                        _tipoNovedadAgente.Insertar(
                        this.txtAbreviaturaCodigo.Text,
                        this.txtTipoNovedadAgente.Text,
                        this.cbJornadaCompleta.Checked);

                        RealizoAlgunaOperacion = true;
                        CargarDatos();
                    }
                }
                catch (Exception)
                {
                    Mensaje.Mostrar("Ocurrió un error al insertar un el Tipo de novedad", TipoMensaje.Error);
                }
            }
            else
            {
                Mensaje.Mostrar("Falto completar datos obligatorios.", TipoMensaje.Aviso);
            }
        }

        public override bool VerificarSiExisteRegistro()
        {
            return _tipoNovedadAgente.ObtenerPorFiltro(txtAbreviaturaCodigo.Text, txtTipoNovedadAgente.Text).Count > 0 ? true : false;
        }
    }
}
