using PresentacionBase;
using PresentacionBase.Clases;
using Servicio.RecursoHumano.Sector;
using Servicio.RecursoHumano.SubSector;
using System;
using System.Windows.Forms;

namespace PresentacionRecursoHumano
{
    public partial class _00004_ABM_SubSector : PresentacionBase.FormularioABM
    {
        private readonly ISubSectorServicio _subSectorServicio;
        private readonly ISectorServicio _sectorServicio;

        public _00004_ABM_SubSector()
            :base("ABM de Sub-Sectores")
        {
            InitializeComponent();

            _subSectorServicio = new SubSectorServicio();
            _sectorServicio = new SectorServicio();

            this.nudCodigo.Enter += Control_Enter;
            this.txtDescripcion.Enter += Control_Enter;
            this.txtAbreviatura.Enter += Control_Enter;

            this.nudCodigo.Leave += Control_Leave;
            this.txtDescripcion.Leave += Control_Leave;
            this.txtAbreviatura.Leave += Control_Leave;

            PoblarComboBox(this.cmbSector, _sectorServicio.ObtenerTodo(), "Descripcion");

            this.txtDescripcion.Validating += (sender, e) => Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
            this.txtAbreviatura.Validating += (sender, e) => Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
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

                    var entidad = _subSectorServicio.ObtenerPorId(base._entidadId.Value);

                    this.nudCodigo.Value = entidad.Codigo;
                    this.txtDescripcion.Text = entidad.Descripcion;
                    this.cmbSector.SelectedValue = entidad.SectorId;
                    this.txtAbreviatura.Text = entidad.Abreviatura;                        

                    if (base._operacion == PresentacionBase.TipoOperacion.Eliminar)
                        DesactivarControles(this, false);
                }
                else
                {
                    this.nudCodigo.Value = _subSectorServicio.ObtenerSiguienteNroCodigo();
                }

                this.Controls[1].Focus();
            }
            catch(Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Cargar los datos del SubGrupo", TipoMensaje.Error);
            }
        }

        public override void InsertarRegistro()
        {
            try
            {
                _subSectorServicio.Insertar(Convert.ToInt64(this.cmbSector.SelectedValue),
                   Convert.ToInt32(this.nudCodigo.Value),
                   this.txtDescripcion.Text,
                   this.txtAbreviatura.Text);

                RealizoAlgunaOperacion = true;
                CargarDatos();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Insertar un SubGrupo", TipoMensaje.Error);
            }           
        }

        public override void ModificarRegistro()
        {
            try
            {
                _subSectorServicio.Modificar(base._entidadId.Value,
                    Convert.ToInt64(this.cmbSector.SelectedValue),
                   Convert.ToInt32(this.nudCodigo.Value),
                   this.txtDescripcion.Text,
                   this.txtAbreviatura.Text);

                RealizoAlgunaOperacion = true;
                this.Close();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Modificar un SubGrupo", TipoMensaje.Error);
            }            
        }

        public override void ElimnarRegistro()
        {
            try
            {
                _subSectorServicio.Eliminar(base._entidadId.Value);
                RealizoAlgunaOperacion = true;
                this.Close();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Eliminar un SubGrupo",TipoMensaje.Error);
            }           
        }

        public override bool VerificarSiExisteRegistro()
        {
            var resultado = _subSectorServicio.VerificarSiExiste(base._entidadId,
                Convert.ToInt64(this.cmbSector.SelectedValue), 
                Convert.ToInt32(this.nudCodigo.Value), 
                this.txtDescripcion.Text,
                this.txtAbreviatura.Text);

            return resultado;
        }

        public override bool VerificarDatosObligatorios(object[] controlesParaVerificar)
        {
            return base.VerificarDatosObligatorios(new object[] { this.nudCodigo, this.txtDescripcion });
        }

        private void btnNuevoSector_Click(object sender, EventArgs e)
        {
            var formularioNuevoSector = new _00002_ABM_Sector();
            formularioNuevoSector.EntidadId = null;
            formularioNuevoSector.TipoOperacion = PresentacionBase.TipoOperacion.Insertar;
            formularioNuevoSector.ShowDialog();

            if (formularioNuevoSector.RealizoAlgunaOperacion)
            {
                PoblarComboBox(this.cmbSector, _sectorServicio.ObtenerTodo(), "Descripcion");
            }
        }

        private void txtDescripcion_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NoInyeccion(sender, e);
            Validacion.NoSimbolos(sender, e);
        }

        private void txtAbreviatura_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NoInyeccion(sender, e);
            Validacion.NoSimbolos(sender, e);
        }

        private void nudCodigo_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
        }
    }
}

