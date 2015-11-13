using PresentacionBase;
using Servicio.RecursoHumano.TipoNovedadAgente;
using System;

namespace PresentacionRecursoHumano
{
    public partial class _00019_ABM_TipoNovedadAgente : FormularioABM
    {
        TipoNovedadAgenteServicio _tipoNovedadAgente;

        public _00019_ABM_TipoNovedadAgente()
            : base("ABM Tipo de Novedad")
        {
            InitializeComponent();
            this.label1.Visible = false;
            _tipoNovedadAgente = new TipoNovedadAgenteServicio();
        }

        public override void InsertarRegistro()
        {
            try
            {
                _tipoNovedadAgente.Insertar(
                    this.txtAbreviaturaCodigo.Text,
                    this.txtTipoNovedadAgente.Text,
                    this.cbJornadaCompleta.Checked);

                RealizoAlgunaOperacion = true;
                CargarDatos();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al insertar un el Tipo de novedad", TipoMensaje.Error);
            }
        }
    }
}
