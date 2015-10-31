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
    public partial class _90002_Perfiles : PresentacionBase.FormularioConsulta
    {
        private readonly IServicioPerfil _PerfilServicio;

        public _90002_Perfiles()
            :base("Consulta de Perfiles", "Lista de Perfiles",new _90003_ABM_Perfil())
        {
            InitializeComponent();

            _PerfilServicio = new ServicioPerfil();
            this.btnImprimir.Visible = false;

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

        public override void Actualizar(string cadenaBuscar)
        {
            var resultado = _PerfilServicio
                .ObtenerPorFiltro(cadenaBuscar);

            this.dgvGrilla.DataSource = resultado.ToList();

            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Descripcion"].Visible = true;
            dgv.Columns["Descripcion"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["Descripcion"].HeaderText = "Descripción";
            dgv.Columns["Descripcion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Descripcion"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["CantidadUsuarios"].Visible = true;
            dgv.Columns["CantidadUsuarios"].Width = 150;
            dgv.Columns["CantidadUsuarios"].HeaderText = "Cant. Usuarios";
            dgv.Columns["CantidadUsuarios"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["CantidadUsuarios"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
    }
}
