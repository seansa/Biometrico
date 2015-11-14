using PresentacionBase;
using Servicio.RecursoHumano.Configuracion;
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
    public partial class _00020_Configuracion : FormularioBase
    {
        IConfiguracionServicio _configuracion = new ConfiguracionServicio();
        AccesoDatos.Configuracion confi;
        public _00020_Configuracion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            _configuracion.GuardarConfiguracion(dtpEntradaPorDefecto.Value.TimeOfDay, dtpSalidaPorDefecto.Value.TimeOfDay, Convert.ToInt32(nudMinutosLactancia.Value), Convert.ToInt32(nudMinutosTarde.Value), Convert.ToInt32(nudMinutosAusente.Value));
        }

        private void _00020_Configuracion_Load(object sender, EventArgs e)
        {

            if (_configuracion.HayRegistros())
            {
                confi = _configuracion.ObtenerUltimaConfiguracion();
                CargarConfiguracion();
            }

        }
        private void CargarConfiguracion()
        {
            this.nudMinutosAusente.Value = (decimal)confi.MinutosToleranciaAusente;
            this.nudMinutosLactancia.Value = (decimal)confi.MinutosLactancia;
            this.nudMinutosTarde.Value = (decimal)confi.MinutosToleranciaLlegadaTarde;
            this.dtpEntradaPorDefecto.Value = Convert.ToDateTime(confi.HoraEntradaPorDefecto.ToString());
            this.dtpSalidaPorDefecto.Value = Convert.ToDateTime(confi.HoraSalidaPorDefecto.ToString());
        }
    }
}
