using Sistema.Negocio;
using Sistema.Negocios;
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
    public partial class FRMProveedores : Form
    {
        public FRMProveedores()
        {
            InitializeComponent();
        }


        private void Formato()
        {
            dgvListado.Columns[0].Visible = false; //ocualtar la columna Seleccionar
            dgvListado.Columns[1].Width = 50;  //ocultar la columna Id
            dgvListado.Columns[2].Visible = true;
            dgvListado.Columns[3].Width = 100;
            dgvListado.Columns[3].HeaderText = "Nombre";
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[5].Width = 100;
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[7].Width = 100;
            dgvListado.Columns[8].Width = 100;



        }//fin del metodo Formato




        private void Limpiar()
        {
            txtBuscar.Clear(); //limpia el textbox
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            txtNumeroDocumento.Clear();
            btnEliminar.Visible = false;
            btnInsertar.Visible = true; //muestra el boton de insertar categoria
            btnActualizar.Visible = false;
            chkSeleccionar.Checked = false;//corregir
            tabPrincipal.SelectedIndex = 0; //que aparezca el tab de Listado
        }//fin del metodo Limpiar

        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // Fin del metodo MensajeOK

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } // Fin del metodo MensajeOK
        private void ListarProveedores()
        {
            try
            {
                //llenar el dgvListado
                dgvListado.DataSource = NPersona.ListarProveedores();
                this.Formato();
                this.Limpiar();

                //mostrar cuantos registros hay en la base de datos
                lblTotal.Text = "Total de registros: " + Convert.ToString(dgvListado.RowCount);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message); //si ocurre un error, muestralo
            }
        } // fin del metodo listar



















        /*private void btnEliminar_Click(object sender, EventArgs e)
        {

        }

        private void btnDesactivar_Click(object sender, EventArgs e)
        {

        }

        private void btnActivar_Click(object sender, EventArgs e)
        {

        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }*/

        private void FRMProveedores_Load(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = NPersona.ListarProveedores();
                this.Formato();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }

            cmbTipoDocumento.Items.Add("Cedula");
            cmbTipoDocumento.Items.Add("Pasaporte");
            cmbTipoDocumento.Items.Add("licencia de trabajo");


            
           


        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = NPersona.BuscarProveedores(txtBuscar.Text);
                this.Formato();
                lblTotal.Text = "Total de registros:" + Convert.ToString(dgvListado.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
           

                try
                {
                    DialogResult opcion = MessageBox.Show("Realmente deseas eliminar el(los) registros(s)?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                    if (opcion == DialogResult.OK)
                    {
                        //EL USUARIO LE DA CLICK OK 
                        //int codigo; 
                        //string respuesta = "";

                        // como el usuario puede marcar varios usuario, debemos hacer bucle
                        foreach (DataGridViewRow row in dgvListado.Rows)
                        {
                            if (Convert.ToBoolean(row.Cells[0].Value))
                            {

                                //OBTENEMOS EL CODIGO DE LA CATEGORIA
                                int id  = Convert.ToInt32(row.Cells[1].Value);
                               string respuesta = NPersona.Eliminar(id);

                                if (respuesta == "OK")
                                {
                                    this.MensajeOK("Se  ha eliminado el registro: "/*+ Convert.ToString(row.Cells[1].Value)*/);
                                }
                                else
                                {
                                    this.MensajeError(respuesta);
                                }



                            }


                        }
                        this.ListarProveedores();


                    }
                }
                catch (Exception ex)
                {
                     MensajeError("Error al eliminar proveedor(es): " + ex.Message); ;
                }




            

        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {

            if (chkSeleccionar.Checked)
            {
                //si está marcado el checkbox, entonces
                dgvListado.Columns[0].Visible = true; //muestra la columna Seleccionar
                btnEliminar.Visible = true;
            }
            else
            {
                //si está desmarcado el checkbox, entonces
                dgvListado.Columns[0].Visible = false; //oculta la columna Seleccionar
                btnEliminar.Visible = false;
            }
        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                chk.Value = !Convert.ToBoolean(chk.Value);
            }



        }



        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if ( cmbTipoDocumento.Text == string.Empty|| txtNombre.Text == string.Empty || txtDireccion.Text == string.Empty || txtTelefono.Text == string.Empty || txtEmail.Text == string.Empty || txtNumeroDocumento.Text == String.Empty)
                {
                    MensajeError("Falta Ingresar datos Obligatorios");
                }
                else
                {
                    respuesta = NPersona.Insertar

                    (
                     txtNombre.Text.Trim(),
                     "Proveedor",
                     cmbTipoDocumento.Text.Trim(),
                     Convert.ToInt32(txtNumeroDocumento.Text.Trim()),
                     txtDireccion.Text.Trim(),
                     txtTelefono.Text.Trim(),
                     txtEmail.Text.Trim()
                     
                     //Encoding.UTF8.GetBytes(txtClave.Text)



                     );

                    if (respuesta == "OK")
                    {
                        MensajeOK("Se creo el usuario proveedor de manera correcta");
                        this.ListarProveedores(); //refresh datagrieview
                    }
                    else
                    {
                        MensajeError(respuesta);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        



        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if ( txtNombre.Text == string.Empty || txtDireccion.Text == string.Empty || txtTelefono.Text == String.Empty ||txtEmail.Text == string.Empty || cmbTipoDocumento.Text == String.Empty || txtNumeroDocumento.Text == String.Empty)
                {
                    MensajeError("Falta Ingresar datos Obligatorios");
                }
                else
                {
                    respuesta = NPersona.Actualizar


                        (Convert.ToInt32(txtId.Text),
                         "Proveedor",
                         txtNombre.Text.Trim(),
                         cmbTipoDocumento.Text.Trim(),
                         Convert.ToInt32(txtNumeroDocumento.Text.Trim()),
                         txtDireccion.Text.Trim(),
                         txtTelefono.Text.Trim(),
                         txtEmail.Text.Trim()
                       
                         //Encoding.UTF8.GetBytes(txtClave.Text)


                         );


                    if (respuesta == "OK")
                    {
                        MensajeOK("Se Actualizo el usuario proveedor  de manera correcta");
                        this.ListarProveedores(); //refresh datagrieview
                    }
                    else
                    {
                        MensajeError(respuesta);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void cmbTipoPersona_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();

                btnActualizar.Visible = true; //muestra el boton de actualizar
                btnInsertar.Visible = false; //oculta el boton de insertar
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["id"].Value);
                txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
                cmbTipoDocumento.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["Tipo_Documento"].Value);
                txtNumeroDocumento.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Num_Documento"].Value);
                txtDireccion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Direccion"].Value);
                txtTelefono.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Telefono"].Value);
                txtEmail.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Email"].Value);


                tabPrincipal.SelectedIndex = 1; // mueve la vista a la pantalla de mantenimiento.





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}

