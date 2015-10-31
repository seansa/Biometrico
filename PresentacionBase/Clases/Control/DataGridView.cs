using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentacionBase.Clases.Control
{
    public class DataGridView : System.Windows.Forms.DataGridView
    {
        public DataGridView() : base()
        {
            this.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            this.DefaultCellStyle.SelectionForeColor = Color.Black;
            this.RowHeadersVisible = false;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
            this.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;         
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
