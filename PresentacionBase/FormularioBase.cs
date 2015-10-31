using PresentacionBase.Clases;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PresentacionBase
{
    public partial class FormularioBase : Form
    {

        //MIO
        public long idmio { get; set; }
        public PrivateFontCollection fuentes;
        public Font HelveticaRoman;
        public Font HelveticaItalic;
        public Font HelveticaBold;
        public Font HelveticaBoldItalic;
        public Font HelveticaLightItalic;
        public Font HelveticaLight;
        public Font HelveticaThin;
        public Font HelveticaThinItalic;
        public FontFamily[] Helvetica;

        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont,
            IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection fonts = new PrivateFontCollection();

        public Font myFont;

        public FormularioBase()
        {
            InitializeComponent();

            this.BackColor = Colores.ColorFondoFormulario;
            this.fuentes = new PrivateFontCollection();

            byte[] fontData = RecursosCompartidos.OpenSans_ExtraBold;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, RecursosCompartidos.OpenSans_ExtraBold.Length);
            AddFontMemResourceEx(fontPtr, (uint)RecursosCompartidos.OpenSans_ExtraBold.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            myFont = new Font(fonts.Families[0], 20.0F);
        }

        public FormularioBase(Color colorFondoForm)             
        {
            this.BackColor = colorFondoForm;
        }
        
        public void PoblarComboBox(ComboBox cmb, object lista, string propiedadMostrar, string propiedadDevolver = "Id")
        {
            cmb.DataSource = lista;
            cmb.DisplayMember = propiedadMostrar;
            cmb.ValueMember = propiedadDevolver;
        }
        
        public void PoblarComboBox(ComboBox cmb, object obj, string propiedadMostrar, string propiedadDevolver, int elementoSeleccionadoId)
        {
            cmb.DataSource = obj;
            cmb.DisplayMember = propiedadMostrar;
            cmb.ValueMember = propiedadDevolver;
            cmb.SelectedValue = elementoSeleccionadoId;
        }

        public virtual bool VerificarSiHayDatosCargadosEnControles(FormularioABM form)
        {
            foreach (var ctrol in form.Controls)
            {
                if (VerificarControles(ctrol))
                {
                    return true;
                };
            }

            return false;
        }

        public virtual bool VerificarControles(object ctrol)
        {
            if (ctrol is TextBox)
            {
                return !string.IsNullOrEmpty(((TextBox)ctrol).Text);
            }

            if (ctrol is NumericUpDown)
            {
                return !string.IsNullOrEmpty(((NumericUpDown)ctrol).Text);
            }

            if (ctrol is CheckBox)
            {
                if (((CheckBox)ctrol).Checked)
                {
                    return true;
                }
            }

            if (ctrol is Panel)
            {
                VerificarControles(((Panel)ctrol));
            }

            return false;
        }

        public virtual void LimpiarControles(object obj)
        {
            if (obj is Form)
            {
                foreach (var ctrol in ((Form)obj).Controls)
                {
                    LimpiarControles(ctrol);
                }
            }

            if (obj is Panel)
            {
                foreach (var ctrol in ((Panel)obj).Controls)
                {
                    LimpiarControles(ctrol);
                }
            }

            if (obj is TextBox)
            {
                ((TextBox)obj).Clear();
            }

            if (obj is ComboBox)
            {
                if (((ComboBox)obj).Items.Count > 0)
                    ((ComboBox)obj).SelectedIndex = 0;
            }

            if (obj is CheckBox)
            {
                ((CheckBox)obj).Checked = false;
            }

            if (obj is DateTimePicker)
            {
                ((DateTimePicker)obj).Value = DateTime.Now;
            }
        }

        public virtual void LimpiarControles(object obj, bool valorPorDefectoCheckBox)
        {
            if (obj is Form)
            {
                foreach (var ctrol in ((Form)obj).Controls)
                {
                    LimpiarControles(ctrol);
                }
            }

            if (obj is Panel)
            {
                foreach (var ctrol in ((Panel)obj).Controls)
                {
                    LimpiarControles(ctrol);
                }
            }

            if (obj is TextBox)
            {
                ((TextBox)obj).Clear();
            }

            if (obj is ComboBox)
            {
                ((ComboBox)obj).SelectedIndex = 0;
            }

            if (obj is CheckBox)
            {
                ((CheckBox)obj).Checked = valorPorDefectoCheckBox;
            }

            if (obj is DateTimePicker)
            {
                ((DateTimePicker)obj).Value = DateTime.Now;
            }

            if (obj is NumericUpDown)
            {
                ((NumericUpDown)obj).Value = ((NumericUpDown)obj).Minimum;
            }

            
        }

        public virtual bool VerificarDatosObligatorios(object[] controlesParaVerificar)
        {
            if (controlesParaVerificar != null)
            {
                foreach (var ctrol in controlesParaVerificar)
                {
                    if (ctrol is TextBox)
                    {
                        if (VerificarSiTieneDatosCtrol(((TextBox)ctrol)))
                            return false;
                    }

                    if (ctrol is NumericUpDown)
                    {
                        if (VerificarSiTieneDatosCtrol(((NumericUpDown)ctrol)))
                            return false;
                    }

                    if (ctrol is ComboBox)
                    {
                        if (VerificarSiTieneDatosCtrol(((ComboBox)ctrol)))
                            return false;
                    }
                }
            }

            return true;
        }        

        public virtual bool VerificarSiTieneDatosCtrol(TextBox txt)
        {
            return string.IsNullOrEmpty(txt.Text) && string.IsNullOrWhiteSpace(txt.Text);
        }

        public virtual bool VerificarSiTieneDatosCtrol(NumericUpDown nud)
        {
            return string.IsNullOrEmpty(nud.Text) && string.IsNullOrWhiteSpace(nud.Text);
        }

        public virtual bool VerificarSiTieneDatosCtrol(ComboBox cmb)
        {
            return !string.IsNullOrEmpty(cmb.Text) && !string.IsNullOrWhiteSpace(cmb.Text) && cmb.Items.Count > 0;
        }

        public virtual void FormatearGrilla(DataGridView dgv)
        {
            for (int i = 0; i < dgv.ColumnCount; i++)
            {
                dgv.Columns[i].Visible = false;
            }
        }

        public virtual void DesactivarControles(object obj, bool estado)
        {
            if (obj is Form)
            {
                foreach (var ctrol in ((Form)obj).Controls)
                {
                    DesactivarControles(ctrol, estado);
                }
            }

            if (obj is Panel)
            {
                foreach (var ctrol in ((Panel)obj).Controls)
                {
                    DesactivarControles(ctrol, estado);
                }
            }

            if (obj is TextBox)
            {
                ((TextBox)obj).Enabled = estado;
            }

            if (obj is ComboBox)
            {
                ((ComboBox)obj).Enabled = estado;
            }

            if (obj is CheckBox)
            {
                ((CheckBox)obj).Enabled = estado;
            }

            if (obj is DateTimePicker)
            {
                ((DateTimePicker)obj).Enabled = estado;
            }

            if (obj is NumericUpDown)
            {
                ((NumericUpDown)obj).Enabled = estado;
            }

            if (obj is RadioButton)
            {
                ((RadioButton)obj).Enabled = estado;
            }
        }

        public virtual void Control_Enter(object sender, EventArgs e)
        {
            CambiarColorControl(sender, Colores.ColorControlConFoco);
        }

        public virtual void Control_Leave(object sender, EventArgs e)
        {
            CambiarColorControl(sender, Colores.ColorControlSinFoco);
        }

        public virtual void CambiarColorControl(object sender, Color colorControl)
        {
            if (sender is TextBox)
            {
                ((TextBox)sender).BackColor = colorControl;
            }

            if (sender is NumericUpDown)
            {
                ((NumericUpDown)sender).BackColor = colorControl;
            }
        }

        protected void CargarFuente(byte[] fuente)
        {
            
        }

        private void FormularioBase_Load(object sender, EventArgs e)
        {
            CargarFuente(RecursosCompartidos.HelveticaNeue_Bold);
            CargarFuente(RecursosCompartidos.HelveticaNeue_BoldItalic);
            CargarFuente(RecursosCompartidos.HelveticaNeue_Italic);
            CargarFuente(RecursosCompartidos.HelveticaNeue_Light);
            CargarFuente(RecursosCompartidos.HelveticaNeue_LightItalic);
            CargarFuente(RecursosCompartidos.HelveticaNeue_Roman);
            CargarFuente(RecursosCompartidos.HelveticaNeue_Thin);
            CargarFuente(RecursosCompartidos.HelveticaNeue_ThinItalic);

            //Helvetica = fuentes.Families;
            /*
            this.HelveticaBold = new  Font(fuentes.Families[0], 16f, FontStyle.Bold);
            this.HelveticaBoldItalic = new Font(fuentes.Families[1], 16, FontStyle.Italic, GraphicsUnit.Pixel);
            this.HelveticaItalic = new Font(fuentes.Families[2], 16, FontStyle.Italic, GraphicsUnit.Pixel);
            this.HelveticaLight = new Font(fuentes.Families[3], 16, FontStyle.Regular, GraphicsUnit.Pixel);
            this.HelveticaLightItalic = new Font(fuentes.Families[4], 16, FontStyle.Italic, GraphicsUnit.Pixel);
            this.HelveticaRoman = new Font(fuentes.Families[5], 16, FontStyle.Regular, GraphicsUnit.Pixel);
            this.HelveticaThin = new Font(fuentes.Families[6], 16, FontStyle.Regular, GraphicsUnit.Pixel);
            this.HelveticaThinItalic = new Font(fuentes.Families[7], 16, FontStyle.Italic, GraphicsUnit.Pixel);
     */   }
    }
}
