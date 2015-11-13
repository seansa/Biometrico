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
    public partial class _00017_NovedadAgente : PresentacionBase.FormularioBase
    {
        public _00017_NovedadAgente()
        {
            InitializeComponent();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {

        }

        private void btnTipoNovedad_Click(object sender, EventArgs e)
        {
            var _formulario = new _00019_ABM_TipoNovedadAgente();
            _formulario.TipoOperacion = PresentacionBase.TipoOperacion.Insertar;
            _formulario.ShowDialog();
        }
    }
}
