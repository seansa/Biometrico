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
    public partial class _00015_ComisionServicio : PresentacionBase.FormularioBase
    {
        public _00015_ComisionServicio()
        {
            InitializeComponent();
        }
        public _00015_ComisionServicio(string titulo) : this()
        {
            this.Text = titulo;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnNuevaComsion_Click(object sender, EventArgs e)
        {
            var formABM = new _00016_ABM_ComisionServicio("Modificar Comisiones de Servicio");
            formABM.ShowDialog();
        }
    }
}
