using PresentacionBase;
using Servicio.Seguridad.Formulario;
using Servicio.Seguridad.Formulario.DTOs;
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

namespace Presentacion.Seguridad
{
    public partial class _90007_Formularios : PresentacionBase.FormularioBase
    {
        private readonly IFormularioServicio _formularioServicio;
        private readonly List<Assembly> _listaAssemblys;

        public _90007_Formularios()
        {
            InitializeComponent();
        }

        public _90007_Formularios(List<Assembly> listaAssemblys)
        {
            InitializeComponent();

            _formularioServicio = new FormularioServicio();
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
            var resultado = _formularioServicio.ObtenerPorFiltro(_listaAssemblys, cadenaBuscar);

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

            dgv.Columns["Codigo"].Visible = true;
            dgv.Columns["Codigo"].Width = 100;
            dgv.Columns["Codigo"].HeaderText = "Código";
            dgv.Columns["Codigo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Codigo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Nombre";
            dgv.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["DescripcionCompleta"].Visible = true;
            dgv.Columns["DescripcionCompleta"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["DescripcionCompleta"].HeaderText = "Nombre Completo";
            dgv.Columns["DescripcionCompleta"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["DescripcionCompleta"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

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

        private void _90007_Formularios_Load(object sender, EventArgs e)
        {
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
                var formularios = (List<FormularioDTO>)this.dgvGrilla.DataSource;

                _formularioServicio.Insertar(formularios);
                Actualizar(string.Empty);
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Grabar los formularios", TipoMensaje.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                var formularios = (List<FormularioDTO>)this.dgvGrilla.DataSource;

                _formularioServicio.Eliminar(formularios
                    .Where(x => x.Item)
                    .Select(x => x.Id.Value)
                    .ToList());

                Actualizar(string.Empty);
            }
            catch (Exception)
            {
                Mensaje.Mostrar("Ocurrió un error al Eliminar los formularios", TipoMensaje.Error);
            }
        }
    }
}
