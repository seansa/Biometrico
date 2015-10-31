using PresentacionBase;
using PresentacionBase.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Servicio.Seguridad.LogIn;
using Servicio.Seguridad.Usuario;

namespace Presentacion.Seguridad
{
    public partial class _90009_CambiarPassword : PresentacionBase.FormularioABM
    {
        public _90009_CambiarPassword()
            : base(@"Cambiar Contraseña")
        {
            InitializeComponent();

            this.AgregarOpcionDiccionario(PresentacionBase.TipoOperacion.CambiarPassword, "CambiarPassword");

            this.txtPasswordNuevo.Enter += Control_Enter;
            this.txtPasswordViejo.Enter += Control_Enter;
            this.txtRepetirPassword.Enter += Control_Enter;

            this.txtPasswordNuevo.Leave += Control_Leave;
            this.txtPasswordViejo.Leave += Control_Leave;
            this.txtRepetirPassword.Leave += Control_Leave;


        }

        public void CambiarPassword()
        {
            try
            {
                var _usuarioServicio = new ServicioUsuario();
                var _loginServicio = new LogInServicio();

                if (!string.IsNullOrEmpty(this.txtPasswordNuevo.Text.Trim())
                    && !string.IsNullOrEmpty(this.txtPasswordViejo.Text.Trim())
                    && !string.IsNullOrEmpty(this.txtRepetirPassword.Text.Trim()))
                {
                    if (this.txtPasswordNuevo.Text == this.txtRepetirPassword.Text)
                    {
                        if (_loginServicio.VerificarIngreso(Identidad.NombreUsuario, this.txtPasswordViejo.Text))
                        {
                            _usuarioServicio.CambiarPassword(base._entidadId.Value, this.txtPasswordNuevo.Text);
                            Mensaje.Mostrar("La contraseña se cambio correctamente", TipoMensaje.Aviso);
                            this.RealizoAlgunaOperacion = true;
                            this.Close();
                        }
                        else
                        {
                            Mensaje.Mostrar("La contraseña vieja no es correcta", TipoMensaje.Aviso);
                            this.txtPasswordViejo.Clear();
                            this.txtPasswordViejo.Focus();
                        }
                    }
                    else
                    {
                        Mensaje.Mostrar("La contraseña Nueva y su verificación deben ser iguales", TipoMensaje.Aviso);
                        this.txtRepetirPassword.Clear();
                        this.txtRepetirPassword.Focus();
                    }
                }
                else
                {
                    Mensaje.Mostrar("Los datos marcados con * son Obligatorios", TipoMensaje.Aviso);
                }
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Cambiar la Contraseña", TipoMensaje.Error);
                this.txtPasswordNuevo.Focus();
            }
        }

        private void txtPasswordViejo_Validating(object sender, CancelEventArgs e)
        {
            Validacion.VerificarNoVacios(sender, e, errorProviderMensaje);
        }
    }
}
