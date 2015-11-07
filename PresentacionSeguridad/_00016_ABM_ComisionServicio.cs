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
    public partial class _00016_ABM_ComisionServicio : PresentacionBase.FormularioBase
    {
        public _00016_ABM_ComisionServicio()
        {
            InitializeComponent();
        }
        public _00016_ABM_ComisionServicio(string titulo) : this()
        {
            this.Text = titulo;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
