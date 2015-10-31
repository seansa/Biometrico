using PresentacionBase;
using PresentacionBase.Clases;
using Servicio.Seguridad.Perfil;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion.Seguridad
{
    public partial class _90003_ABM_Perfil : PresentacionBase.FormularioABM
    {
        private readonly IServicioPerfil _PerfilServicio;

        public _90003_ABM_Perfil()
            :base("ABM de Perfiles")
        {
            InitializeComponent();

            _PerfilServicio = new ServicioPerfil();

            this.txtDescripcion.Enter += Control_Enter;
            this.txtDescripcion.Leave += Control_Leave;

            this.txtDescripcion.KeyPress += Control_KeyPress;
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
                    var entidad = _PerfilServicio.ObtenerPorId(base._entidadId.Value);

                    this.txtDescripcion.Text = entidad.Descripcion;

                    if (base._operacion == TipoOperacion.Eliminar)
                        DesactivarControles(this, false);
                }
                
                this.Controls[1].Focus();
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
                var PerfilNuevo = new AccesoDatos.Perfil();
                PerfilNuevo.Descripcion = this.txtDescripcion.Text;

                _PerfilServicio.Insertar(PerfilNuevo);
                RealizoAlgunaOperacion = true;
                CargarDatos();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al insertar un Perfil", TipoMensaje.Error);
            }
        }

        public override void ModificarRegistro()
        {
            try
            {
                var PerfilModificar = _PerfilServicio.ObtenerPorId(base._entidadId.Value);
                PerfilModificar.Descripcion = this.txtDescripcion.Text;

                _PerfilServicio.Modificar(PerfilModificar);
                RealizoAlgunaOperacion = true;
                this.Close();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al modificar un Perfil", TipoMensaje.Error);
            }
        }

        public override void ElimnarRegistro()
        {
            try
            {
                _PerfilServicio.Eliminar(base._entidadId.Value);
                RealizoAlgunaOperacion = true;
                this.Close();
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al eliminar un Perfil", TipoMensaje.Error);
            }
        }

        public override bool VerificarSiExisteRegistro()
        {
            var resultado = _PerfilServicio.VerificarSiExiste(base._entidadId, this.txtDescripcion.Text);

            return resultado;
        }

        public override bool VerificarDatosObligatorios(object[] controlesParaVerificar)
        {
            return base.VerificarDatosObligatorios(new object[] { this.txtDescripcion });
        }

        private void txtDescripcion_Validating(object sender, CancelEventArgs e)
        {
            Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
        }
    }
}
