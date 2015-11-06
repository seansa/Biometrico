using PresentacionBase;
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
    public partial class _00005_Agentes : PresentacionBase.FormularioConsulta
    {
        private readonly IAgenteServicio _agenteServicio;
        public long agentesel { get; set; }

        public _00005_Agentes()
            :base("Consulta de Agentes", "Lista de Agentes",new _00006_ABM_Agente())
        {
            InitializeComponent();

            _agenteServicio = new AgenteServicio();
            this.btnImprimir.Visible = false;
            
            this.WindowState = FormWindowState.Maximized;
            this.btnLactancia.Visible = true;
        }

        public virtual void AgregarBotonMenu(ToolStripButton boton, Size? tamaño = null)
        {
            boton.ForeColor = Colores.ColorTexto;
            boton.ImageTransparentColor = System.Drawing.Color.Magenta;
            boton.Size = tamaño ?? new System.Drawing.Size(46, 49);
            boton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            Menu.Items.Add(boton);
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
            var resultado = _agenteServicio.ObtenerPorFiltro(cadenaBuscar);
            this.dgvGrilla.DataSource = resultado.ToList();

            FormatearGrilla(this.dgvGrilla);
        }

        public override void FormatearGrilla(DataGridView dgv)
        {
            base.FormatearGrilla(dgv);

            dgv.Columns["Legajo"].Visible = true;
            dgv.Columns["Legajo"].Width = 100;
            dgv.Columns["Legajo"].HeaderText = "Legajo";
            dgv.Columns["Legajo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Legajo"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["ApyNom"].Visible = true;
            dgv.Columns["ApyNom"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv.Columns["ApyNom"].HeaderText = "Apellido y Nombre";
            dgv.Columns["ApyNom"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["ApyNom"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["DNI"].Visible = true;
            dgv.Columns["DNI"].Width = 100;
            dgv.Columns["DNI"].HeaderText = "Nro Documento";
            dgv.Columns["DNI"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["DNI"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Telefono"].Visible = true;
            dgv.Columns["Telefono"].Width = 100;
            dgv.Columns["Telefono"].HeaderText = "Teléfono";
            dgv.Columns["Telefono"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Telefono"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Celular"].Visible = true;
            dgv.Columns["Celular"].Width = 100;
            dgv.Columns["Celular"].HeaderText = "Celular";
            dgv.Columns["Celular"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Celular"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Mail"].Visible = true;
            dgv.Columns["Mail"].Width = 200;
            dgv.Columns["Mail"].HeaderText = "E-Mail";
            dgv.Columns["Mail"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv.Columns["Mail"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgv.Columns["Visualizar"].Visible = true;
            dgv.Columns["Visualizar"].Width = 70;
            dgv.Columns["Visualizar"].HeaderText = "Visible";
            dgv.Columns["Visualizar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Visualizar"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void _00005_Agentes_Load(object sender, EventArgs e)
        {
            base.FormularioConsulta_Load(sender, e);

            ToolStripButton btnComisiones = new ToolStripButton("Comisiones", null, Comisiones_Click);
            AgregarBotonMenu(btnComisiones);
        }

        private void Comisiones_Click(object sender, EventArgs e)
        {
            var formComisiones = new _00015_ComisionServicio("Comisiones de Sevicio");
            formComisiones.ShowDialog();
        }
      
        public override void dgvGrilla_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgvGrilla.RowCount > 0)
            {
                this._formularioABM.EntidadId = Convert.ToInt64(this.dgvGrilla["Id", e.RowIndex].Value);

                //mio
                //ayuda.idmio = Convert.ToInt64(this.dgvGrilla["Id", e.RowIndex].Value);
                agentesel = Convert.ToInt64(this.dgvGrilla["Id", e.RowIndex].Value);
            }
            else
            {
                this._formularioABM.EntidadId = (long?)null;
            }
        }
        public override void btnHorarios_Click(object sender, EventArgs e)
        {
            var fhorarios = new PresentacionRecursoHumano._00010_Horarios("Lista de Horarios");
            fhorarios.IdAgente = agentesel;
            fhorarios.ShowDialog();
        }
        public override void btnLactancia_Click(object sender, EventArgs e)
        {


            if (this.dgvGrilla.RowCount > 0)
            {
                var _formaulario = new _00012_Lactancia();
                _formaulario.AgenteId = agentesel;
                _formaulario.ShowDialog();

            }
            else
            {
                MessageBox.Show("No se puede Agregar Lactancia si no Seleccionó ningún Agente");
            }
        }

    }
}
