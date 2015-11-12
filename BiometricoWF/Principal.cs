using Servicio.Seguridad.AccesoFormulario;
using Servicio.Seguridad.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PresentacionBase;
using Presentacion.Core;


namespace BiometricoWF
{
    public partial class Principal : PresentacionBase.FormularioBase
    {
        public Principal()
        {
            InitializeComponent();

            this.BackgroundImage = Properties.Resources.Fondo;
        }

        private void EjecutarFormulario(Form formulario)
        {
            if (AccesoFormularioServicio.TienePermiso(formulario.Name, Identidad.NombreUsuario))
            {
                formulario.MdiParent = this;
                formulario.Show();
            }
            else
            {
                PresentacionBase.Mensaje.Mostrar("Acceso Denegado", PresentacionBase.TipoMensaje.Aviso);
            }
        }

        private void EjecutarFormulario(PresentacionBase.FormularioABM formulario)
        {
            if (AccesoFormularioServicio.TienePermiso(formulario.Name, Identidad.NombreUsuario))
            {
                formulario.EntidadId = Identidad.UsuarioId;
                formulario.TipoOperacion = PresentacionBase.TipoOperacion.Insertar;
                formulario.ShowDialog();
            }
            else
            {
                PresentacionBase.Mensaje.Mostrar("Acceso Denegado", PresentacionBase.TipoMensaje.Aviso);
            }
        }

        private void EjecutarFormulario(PresentacionBase.FormularioABM formulario, TipoOperacion tipoOperacion, long id)
        {
            if (AccesoFormularioServicio.TienePermiso(formulario.Name, Identidad.NombreUsuario))
            {
                formulario.EntidadId = id;
                formulario.TipoOperacion = tipoOperacion;
                formulario.ShowDialog();
            }
            else
            {
                PresentacionBase.Mensaje.Mostrar("Acceso Denegado", PresentacionBase.TipoMensaje.Aviso);
            }
        }


        private void salirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void consultaDeSectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new PresentacionRecursoHumano._00001_Sectores());
        }

        private void nuevoSectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new PresentacionRecursoHumano._00002_ABM_Sector());
        }

        private void consultaDeSubSectoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new PresentacionRecursoHumano._00003_SubSectores());
        }

        private void nuevoSubSectorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new PresentacionRecursoHumano._00004_ABM_SubSector());
        }

        private void consultaDeAgentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new PresentacionRecursoHumano._00005_Agentes());

        }

        private void nuevoAgenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new PresentacionRecursoHumano._00006_ABM_Agente());
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void consultaDePerfilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new Presentacion.Seguridad._90002_Perfiles());
        }

        private void asignarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new Presentacion.Seguridad._90004_AsignarUsuarioPerfil());
        }

        private void formularioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listaAss = new List<Assembly>();
            listaAss.Add(Presentacion.Seguridad.SeguridadAssembly.Assembly);
            listaAss.Add(PresentacionRecursoHumano.RecursoHumanoAssembly.Assembly);

            EjecutarFormulario(new Presentacion.Seguridad._90007_Formularios(listaAss));
        }

        private void controlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var listaAss = new List<Assembly>();
            listaAss.Add(Presentacion.Seguridad.SeguridadAssembly.Assembly);
            listaAss.Add(PresentacionRecursoHumano.RecursoHumanoAssembly.Assembly);

            EjecutarFormulario(new Presentacion.Seguridad._90008_Controles(listaAss));
        }

        private void asginarFormulariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new Presentacion.Seguridad._90005_AsignarFormularioPerfil());
        }

        private void asignarControlesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new Presentacion.Seguridad._90006_AsignarControlPerfil());
        }

        private void asignarAgentesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new PresentacionRecursoHumano._00007_AsignarAgenteSubSector());
            MostrarInformacionUsuarioLogIn();
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.lblUsuario.Text = "Usuario: ";
            var _login = new Presentacion.Seguridad.LogIn();
            _login.ShowDialog();

            if (_login.PuedeIngresarAlSistema)
            {
                MostrarInformacionUsuarioLogIn();
            }
            else
            {
                Application.Exit();
            }
        }

        private void crearUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new Presentacion.Seguridad._90001_Usuario("Usuario del Sistema", "Lista de Usuarios"));
        }

        private void cambiarContraseñaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Identidad.UsuarioId.HasValue)
            {
                var _formulario = new Presentacion.Seguridad._90009_CambiarPassword();
                EjecutarFormulario(_formulario, TipoOperacion.CambiarPassword, Identidad.UsuarioId.Value);
            }
            else
            {
                Mensaje.Mostrar("El Administrador No  puede cambiar su Contraseña", TipoMensaje.Aviso);
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
            MostrarInformacionUsuarioLogIn();
        }

        private void MostrarInformacionUsuarioLogIn()
        {
            var informacionUsuario = string.Format("Usuario: {0}", Identidad.ApyNomAgente);

            //if (Identidad.SubSectores.Count == 1)
            //{
            //    informacionUsuario += " - SubSector: " + Identidad.SubSectores.FirstOrDefault().Abreviatura;
            //}

            this.lblUsuario.Text = informacionUsuario;
        }

        private void horariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fhorarios = new PresentacionRecursoHumano._00011_ABM_Horario();
            fhorarios.ShowDialog();
        }

        private void novedadesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EjecutarFormulario(new PresentacionRecursoHumano._00013_Novedades("Novedades"));
        }

        private void accesoDelAgenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var _formulario = new _10001_Acceso();
            _formulario.ShowDialog();
        }
    }
}
