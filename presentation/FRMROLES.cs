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

namespace presentation
{
    public partial class FRMROLES : Form
    {
        public FRMROLES()
        {
            InitializeComponent();

        }
        private void Formato()
        {
            dgvListado.Columns[0].Width = 100;
            dgvListado.Columns[0].HeaderText = "ID";
            dgvListado.Columns[1].Width = 150;
            dgvListado.Columns[1].HeaderText = "Name";

                
            
        }


        private void FRMROLES_Load(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = NRol.Listar();
                this.Formato();
            } 
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }


        }

        
    }
}
