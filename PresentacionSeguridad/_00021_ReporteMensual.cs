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
    public partial class _00021_ReporteMensual : PresentacionBase.FormularioBase
    {
        public _00021_ReporteMensual()
        {
            InitializeComponent();
        }

        public _00021_ReporteMensual(string titulo) : this()
        {
            Text = titulo;
        }
    }
}
