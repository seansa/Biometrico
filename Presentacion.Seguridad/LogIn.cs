using PresentacionBase;
using PresentacionBase.Clases;
using Servicio.RecursoHumano.SubSector.DTOs;
using Servicio.Seguridad.LogIn;
using Servicio.Seguridad.Perfil.DTOs;
using Servicio.Seguridad.Usuario;
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
    public partial class LogIn : Form
    {
        public bool PuedeIngresarAlSistema { get; set; }
        private int _cantidadErrores = 0;

        public LogIn()
        {
            InitializeComponent();

            this.PuedeIngresarAlSistema = false;
            this.imgLogo.Image = PresentacionBase.Imagenes.BotonLogin;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(this.txtUsuario.Text)
                    && !string.IsNullOrEmpty(this.txtPassword.Text))
                {
                    var _usuarioServicio = new ServicioUsuario();
                    var _logInServicio = new LogInServicio();

                    if (_logInServicio.VerificarIngresoAdministrador(this.txtUsuario.Text, this.txtPassword.Text))
                    {
                        this.PuedeIngresarAlSistema = true;
                        Identidad.NombreUsuario = this.txtUsuario.Text;
                        Identidad.UsuarioId = (long?)null;
                        this.Close();
                    }
                    else
                    {
                        var _usuario = _usuarioServicio.ObtenerPorNombre(this.txtUsuario.Text);

                        if (_usuario != null)
                        {
                            if (_usuario.EstaBloqueado)
                            {
                                Mensaje.Mostrar("El usuario esta Bloqueado", TipoMensaje.Aviso);
                                this.txtUsuario.Clear();
                                this.txtPassword.Clear();
                                this.txtUsuario.Focus();
                                return;
                            }
                            else
                            {
                                if (_logInServicio.VerificarIngreso(
                                    this.txtUsuario.Text,
                                    this.txtPassword.Text))
                                {
                                    Identidad.UsuarioId = _usuario.Id;
                                    Identidad.NombreUsuario = _usuario.Nombre;
                                    Identidad.ApyNomAgente = $"{_usuario.Agente.Nombre} {_usuario.Agente.Apellido}";
                                    Identidad.Perfiles = _usuario.Perfiles.Select(x => new PerfilDTO
                                    {
                                        Id = x.Id,
                                        Descripcion = x.Descripcion,
                                    }).ToList();
                                    Identidad.SubSectores = _usuario.Agente.SubSectores.Select(x => new SubSectorDTO
                                    {
                                        Id = x.Id,
                                        Descripcion = x.Descripcion,
                                        Abreviatura = x.Abreviatura
                                    }).ToList();

                                    this.PuedeIngresarAlSistema = true;
                                    this.Close();
                                }
                                else
                                {
                                    if (_cantidadErrores < 3)
                                    {
                                        _cantidadErrores++;

                                        Mensaje.Mostrar("El usuario  o la contraseña son incorrectos", TipoMensaje.Aviso);
                                        this.txtPassword.Clear();
                                        this.txtPassword.Focus();
                                    }
                                    else
                                    {
                                        // Bloquear Usuario
                                        _usuarioServicio.BloquearUsuario(this.txtUsuario.Text);
                                        var mensajeUsuarioBloqueado =
                                            string.Format("Por seguridad el usuario {0} será BLOQUEADO.",
                                                this.txtUsuario.Text);
                                        Mensaje.Mostrar(mensajeUsuarioBloqueado, TipoMensaje.Aviso);
                                        Application.Exit();
                                    }
                                }
                            }
                        }
                        else
                        {
                            var mensajeUsuarioIcorrecto = string.Format("El usuario {0} no Existe.",
                                this.txtUsuario.Text);

                            Mensaje.Mostrar(mensajeUsuarioIcorrecto, TipoMensaje.Error);

                            this.txtUsuario.Clear();
                            this.txtPassword.Clear();
                            this.txtUsuario.Focus();
                        }
                    }
                }
                else
                {
                    Mensaje.Mostrar("Por favor ingrese un usuario y su contraseña", TipoMensaje.Aviso);
                    this.txtPassword.Focus();
                }
            }
            catch(Exception ex)
            {
                Mensaje.Mostrar("Ocurrió un error al Ingresar al sistema", TipoMensaje.Aviso);
                this.txtPassword.Clear();
                this.txtPassword.Focus();
            }            
        }

        private void txtUsuario_Enter(object sender, EventArgs e)
        {
            ((TextBox) sender).BackColor = PresentacionBase.Colores.ColorControlConFoco;
        }

        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            ((TextBox)sender).BackColor = PresentacionBase.Colores.ColorControlSinFoco;
        }

        private void LogIn_Load(object sender, EventArgs e)
        {
            this.txtUsuario.Text = "ADMIN";
            this.txtPassword.Text = "123";
            lblTitulo.Font = new FormularioBase().myFont;
        }
    }
}
