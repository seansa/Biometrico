using PresentacionBase;
using PresentacionBase.Clases;
using Servicio.RecursoHumano.Agente;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PresentacionRecursoHumano
{
    public partial class _00006_ABM_Agente : PresentacionBase.FormularioABM
    {
        private readonly IAgenteServicio _agenteServicio;

        public _00006_ABM_Agente()
            :base("ABM de Agentes")
        {
            InitializeComponent();

            _agenteServicio = new AgenteServicio();

            this.txtLegajo.Enter += new EventHandler(Control_Enter);
            this.txtApellido.Enter += new EventHandler(Control_Enter);
            this.txtNombre.Enter += new EventHandler(Control_Enter);
            this.txtNroDocumento.Enter += new EventHandler(Control_Enter);
            this.txtTelefono.Enter += new EventHandler(Control_Enter);
            this.txtCelular.Enter += new EventHandler(Control_Enter);
            this.txtMail.Enter += new EventHandler(Control_Enter);

            this.txtLegajo.Leave += new EventHandler(Control_Leave);
            this.txtApellido.Leave += new EventHandler(Control_Leave);
            this.txtNombre.Leave += new EventHandler(Control_Leave);
            this.txtNroDocumento.Leave += new EventHandler(Control_Leave);
            this.txtTelefono.Leave += new EventHandler(Control_Leave);
            this.txtCelular.Leave += new EventHandler(Control_Leave);
            this.txtMail.Leave += new EventHandler(Control_Leave);

            this.txtApellido.Validating += (sender, e) => Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
            this.txtNombre.Validating += (sender, e) => Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
            this.txtLegajo.Validating += (sender, e) => Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
            this.txtNroDocumento.Validating += (sender, e) => Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
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
                    var entidad = _agenteServicio.ObtenerPorId(base._entidadId.Value);

                    this.txtLegajo.Text = entidad.Legajo;
                    this.txtApellido.Text = entidad.Apellido;
                    this.txtNombre.Text = entidad.Nombre;
                    this.txtNroDocumento.Text = entidad.DNI;
                    this.txtTelefono.Text = entidad.Telefono;
                    this.txtCelular.Text = entidad.Celular;
                    this.txtMail.Text = entidad.Mail;
                    this.chkVisualizar.Checked = entidad.Visualizar;

                    if (base._operacion == PresentacionBase.TipoOperacion.Eliminar)
                        DesactivarControles(this, false);
                }
                else
                {
                    this.chkVisualizar.Checked = true;
                } 
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Cargar los datos", TipoMensaje.Error);
            }
        }

        public override void InsertarRegistro()
        {
            try
            {
                _agenteServicio.Insertar(this.txtLegajo.Text,
                    this.txtApellido.Text,
                    this.txtNombre.Text,
                    this.txtNroDocumento.Text,
                    this.txtTelefono.Text,
                    this.txtCelular.Text,
                    this.txtMail.Text,
                    this.chkVisualizar.Checked);

                RealizoAlgunaOperacion = true;
                CargarDatos();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al insertar un Agente", TipoMensaje.Error);
            }
        }

        public override void ModificarRegistro()
        {
            try
            {
                _agenteServicio.Modificar(base._entidadId.Value,
                    this.txtLegajo.Text,
                    this.txtApellido.Text,
                    this.txtNombre.Text,
                    this.txtNroDocumento.Text,
                    this.txtTelefono.Text,
                    this.txtCelular.Text,
                    this.txtMail.Text,
                    this.chkVisualizar.Checked);

                RealizoAlgunaOperacion = true;
                this.Close();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al modificar un Agente", TipoMensaje.Error);
            }
        }

        public override void ElimnarRegistro()
        {
            try
            {
                _agenteServicio.Eliminar(base._entidadId.Value);
                RealizoAlgunaOperacion = true;
                this.Close();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al eliminar un Agente", TipoMensaje.Error);
            }
        }

        public override bool VerificarSiExisteRegistro()
        {
            var resultado = _agenteServicio.VerificarSiExiste(base._entidadId, this.txtLegajo.Text);

            return resultado;
        }

        public override bool VerificarDatosObligatorios(object[] controlesParaVerificar)
        {
            return base.VerificarDatosObligatorios(new object[] { this.txtLegajo, this.txtApellido, this.txtNombre, this.txtNroDocumento });
        }

        private void txtLegajo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NoInyeccion(sender, e);
            Validacion.NoSimbolos(sender, e);
            Validacion.NoLetras(sender, e);

        }

        private void txtApellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validacion.NoInyeccion(sender, e);
            Validacion.NoSimbolos(sender, e);
        }

        private void txtMail_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter && VerificarDatosObligatorios(new object[] { this.txtLegajo, this.txtApellido,this.txtNombre, this.txtNroDocumento}))
            {
                InsertarRegistro();
            }
        }

        private void txtLegajo_Validating(object sender, CancelEventArgs e)
        {
            Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
        }
    }
}
