using PresentacionBase;
using PresentacionBase.Clases;
using Servicio.RecursoHumano.Sector;
using System;
using System.Windows.Forms;

namespace PresentacionRecursoHumano
{
    public partial class _00002_ABM_Sector : FormularioABM
    {
        private readonly ISectorServicio _sectorServicio;

        public _00002_ABM_Sector()
            :base("ABM de Sectores")
        {
            InitializeComponent();

            _sectorServicio = new SectorServicio();

            this.nudCodigo.Enter += new EventHandler(Control_Enter);
            this.txtDescripcion.Enter += new EventHandler(Control_Enter);

            this.nudCodigo.Leave += new EventHandler(Control_Leave);
            this.txtDescripcion.Leave += new EventHandler(Control_Leave);
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public override void CargarDatos()
        {
            try
            {
                base.CargarDatos();

                if (base._entidadId.HasValue)
                {
                    var entidad = _sectorServicio.ObtenerPorId(base._entidadId.Value);

                    this.nudCodigo.Value = entidad.Codigo;
                    this.txtDescripcion.Text = entidad.Descripcion;

                    if (base._operacion == TipoOperacion.Eliminar)
                        DesactivarControles(this, false);
                }
                else
                {
                    this.nudCodigo.Value = _sectorServicio.ObtenerSiguienteNroCodigo();
                }

                this.Controls[1].Focus();
            }
            catch(Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Cargar los datos", TipoMensaje.Error);
            }
        }

        public override void InsertarRegistro()
        {
            try
            {
                _sectorServicio.Insertar(Convert.ToInt32(this.nudCodigo.Value), this.txtDescripcion.Text);
                RealizoAlgunaOperacion = true;
                CargarDatos();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al insertar un Sector", TipoMensaje.Error);
            }
        }

        public override void ModificarRegistro()
        {
            try
            {
                _sectorServicio.Modificar(base._entidadId.Value, Convert.ToInt32(this.nudCodigo.Value), this.txtDescripcion.Text);
                RealizoAlgunaOperacion = true;
                this.Close();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al modificar un Sector", TipoMensaje.Error);
            }
        }

        public override void ElimnarRegistro()
        {
            try
            {
                _sectorServicio.Eliminar(base._entidadId.Value);
                RealizoAlgunaOperacion = true;
                this.Close();
            }
            catch(Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al eliminar un Sector", TipoMensaje.Error);
            }
        }

        public override bool VerificarSiExisteRegistro()
        {
            var resultado = _sectorServicio.VerificarSiExiste(base._entidadId, Convert.ToInt32(this.nudCodigo.Value), this.txtDescripcion.Text);

            return resultado;
        }

        public override bool VerificarDatosObligatorios(object[] controlesParaVerificar)
        {
            return base.VerificarDatosObligatorios(new object[] { this.nudCodigo, this.txtDescripcion });
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NoInyeccion(sender, e);
            Validacion.NoSimbolos(sender, e);
        }

        private void nudCodigo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
        }

        private void txtDescripcion_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
        }
    }
}
