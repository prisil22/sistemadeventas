using Sistema.Negocio;
using Sistema.Presentacion;
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
    public partial class Frmlogin : Form
    {
        public Frmlogin()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {

            try
            {
                DataTable Tabla = new DataTable();
                Tabla = NUsuario.Login(txtEmail.Text.Trim(), txtClave.Text.Trim());
                if (Tabla.Rows.Count <= 0 )
                {
                    MessageBox.Show("El email o clave ingresados son incorrectos", "Acceso al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (Convert.ToBoolean(Tabla.Rows[0][4]) == false)
                    {
                        MessageBox.Show("Este usuario no esta activo", "Acesso al sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        FrmPrincipal frm = new FrmPrincipal();
                        frm.idUsuario = Convert.ToInt32(Tabla.Rows[0][0]);
                        Variables.IdUsuario = Convert.ToInt32(Tabla.Rows[0][0]);
                        frm.idRol = Convert.ToInt32(Tabla.Rows [0][1]);
                        frm.rol = Convert.ToString(Tabla.Rows[0][2]);
                        frm.nombre = Convert.ToString(Tabla.Rows[0][3]);
                        frm.estado = Convert.ToBoolean(Tabla.Rows[0][4]);
                        frm.Show();
                        this.Hide();
                    }
                        
                }

            }
            catch (Exception ex) 
            {

                throw;
            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
