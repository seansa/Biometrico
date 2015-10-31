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
using Servicio.Seguridad.Controles;
using Servicio.Seguridad.Controles.DTOs;
 using Servicio.Seguridad.Formulario;

namespace Presentacion.Seguridad
{
    public partial class _90008_Controles : PresentacionBase.FormularioBase
    {
        private readonly IControlSistemaServicio _ControlSistemaServicio;
        private readonly List<Assembly> _listaAssemblys;

        public _90008_Controles()
        {
            InitializeComponent();
        }

        public _90008_Controles(List<Assembly> listaAssemblys)
        {
            InitializeComponent();

            _ControlSistemaServicio = new ControlSistemaServicio();
            _listaAssemblys = listaAssemblys;

            this.txtBuscar.Enter += Control_Enter;
            this.txtBuscar.Leave += Control_Leave;

            this.btnGrabar.Image = Imagenes.BotonEjecutar;
            this.btnEliminar.Image = Imagenes.BotonBorrar;

            this.btnSalir.Image = Imagenes.BotonSalir;
            this.imgBuscar.Image = Imagenes.BotonBuscar;

            this.menu.BackColor = Colores.ColorMenuAccesoRapido;

            this.WindowState = FormWindowState.Maximized;
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

        private void Actualizar(string cadenaBuscar)
        {
            var resultado = _ControlSistemaServicio.ObtenerPorFiltro(_listaAssemblys, cadenaBuscar);

            this.btnGrabar.Enabled = resultado.Any(x => x.EstaEnBase == "NO");
            this.btnEliminar.Enabled = resultado.Any(x => x.EstaEnBase == "SI");

            this.dgvGrilla.DataSource = resultado.ToList();

            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Id"].Visible = false;

            dgv.Columns["Item"].Visible = true;
            dgv.Columns["Item"].Width = 100;
            dgv.Columns["Item"].HeaderText = "Item a Eliminar";
            dgv.Columns["Item"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Item"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Nombre";
            dgv.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Formulario"].Visible = true;
            dgv.Columns["Formulario"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Formulario"].HeaderText = "Formulario / Pantalla";
            dgv.Columns["Formulario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Formulario"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["EstaEnBase"].Visible = true;
            dgv.Columns["EstaEnBase"].Width = 80;
            dgv.Columns["EstaEnBase"].HeaderText = "Existe DB";
            dgv.Columns["EstaEnBase"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["EstaEnBase"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Activar(bool estado)
        {
            if (this.dgvGrilla.RowCount > 0)
            {
                for (int i = 0; i < this.dgvGrilla.RowCount; i++)
                {
                    this.dgvGrilla["Item", i].Value = estado;

                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Actualizar(this.txtBuscar.Text);
        }

        private void _90007_ControlSistemas_Load(object sender, EventArgs e)
        {
            if (!new FormularioServicio().VerificarSiSeCargaronFormularios())
            {
                Mensaje.Mostrar("Antes de poder Cargar los controles, por favor cargar los formularios.", TipoMensaje.Aviso);
                this.Close();
            }

            Actualizar(string.Empty);
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGrilla_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvGrilla.RowCount > 0)
            {
                this.dgvGrilla.EndEdit();
            }
        }

        private void txtBuscar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (int)Keys.Enter)
            {
                Actualizar(this.txtBuscar.Text);
                e.Handled = true;
            }
        }

        private void btnMarcaNoAsignados_Click(object sender, EventArgs e)
        {
            Activar(true);
        }

        private void btnDesmarcarNoAsignado_Click(object sender, EventArgs e)
        {
            Activar(false);
        }

        private void btnGrabar_Click(object sender, EventArgs e)
        {
            try
            {
                var ControlSistemas = (List<ControlSistemaDTO>)this.dgvGrilla.DataSource;

                _ControlSistemaServicio.Insertar(ControlSistemas);
                Actualizar(string.Empty);
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Grabar los Controles", TipoMensaje.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var ControlSistemas = (List<ControlSistemaDTO>)this.dgvGrilla.DataSource;

                _ControlSistemaServicio.Eliminar(ControlSistemas
                    .Where(x => x.Item)
                    .Select(x => x.Id.Value)
                    .ToList());

                Actualizar(string.Empty);
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Eliminar los Controles", TipoMensaje.Error);
            }
        }
    }
}
