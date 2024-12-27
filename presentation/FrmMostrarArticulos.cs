using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class MostrarArticulos : Form
    {
        public MostrarArticulos()
        {
            InitializeComponent();
        }
        private void Formato()
        {
            dgvListado.Columns[0].Visible = false; //ocualtar la columna Seleccionar
            dgvListado.Columns[1].Width = 50;  //ocultar la columna Id
            dgvListado.Columns[2].Visible = false;
            dgvListado.Columns[3].Width = 100;
            dgvListado.Columns[3].HeaderText = "Categoria";
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].Width = 100;



        }//fin del metodo Formato

        private void Buscar()
        {
            try
            {
                dgvListado.DataSource = NArticulo.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotal.Text = "Total de registros:" + Convert.ToString(dgvListado.DataSource);
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void MostrarArticulos_Load(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Variables.IdArticulo = Convert.ToInt32(dgvListado.CurrentRow.Cells["ID"].Value);
            Variables.Codigo = Convert.ToString(dgvListado.CurrentRow.Cells["Codigo"].Value);
            Variables.Nombre = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
            Variables.Precio = Convert.ToInt32(dgvListado.CurrentRow.Cells["Precio_Venta"].Value);

        }
    }
}
