using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace presentation
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
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

        private void txtClave_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Formato()
        {
            dgvListado.Columns[0].Visible = false; //ocualtar la columna Seleccionar
            dgvListado.Columns[1].Width = 50;  //ocultar la columna Id
            dgvListado.Columns[2].Visible = false;
            dgvListado.Columns[3].Width = 100;
            dgvListado.Columns[3].HeaderText = "Rol";
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].Width = 100;
            dgvListado.Columns[4].Width = 100;
            btnActivar.Visible = false; //oculta este boton
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = true; //muestra el boton de insertar categoria
            btnActualizar.Visible = false;
            chkSeleccionar.Checked = false;//corregir
            tabControl1.SelectedIndex = 0; //que aparezca el tab de Listado




        }//fin del metodo Formato
        private void Limpiar()
        {
            txtBuscar.Clear(); //limpia el textbox
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtNumeroDocumento.Clear();
            txtEmail.Clear();
            txtClave.Clear();
            txtId.Clear();
            cmbTipoDocumento.SelectedIndex = 0;
            cmbRol.SelectedIndex = 0;
           
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
        private void Listar()
        {
            try
            {
                //llenar el dgvListado
                dgvListado.DataSource = NUsuario.Listar();
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

        private void ListarRolesUsuarios()

        {
            try
            {
                cmbRol.DataSource = NRol.Listar();
                cmbRol.ValueMember = "idrol";
                cmbRol.DisplayMember = "Nombre";


            }
            catch (Exception ex)
            {

            }


        }

        


        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = NUsuario.Listar();
                this.ListarRolesUsuarios();
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





        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            dgvListado.DataSource = NCategoria.Buscar(txtBuscar.Text.Trim());
            this.Formato();
            lblTotal.Text = "Total de registros: " + Convert.ToString(dgvListado.RowCount);



        }

        private void btnActivar_Click_1(object sender, EventArgs e)
        {

            try
            {
                DialogResult opcion = MessageBox.Show("Realmente deseas activar el(los) registros(s)?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    //EL USUARIO LE DA CLICK OK 
                    int codigo; // Aqui vamos a capturar el codigo de cada categoria seleccionada por el usuario
                    string respuesta = "";

                    // como el usuario puede marcar varios usuarios, debemos hacer bucle
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {

                            //OBTENEMOS EL CODIGO DE LA CATEGORIA
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = NUsuario.Activar(codigo);

                            if (respuesta == "OK")
                            {
                                this.MensajeOK("Se activo el registro:" + Convert.ToString(row.Cells[3].Value));
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }



                        }



                    }
                    this.Listar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void btnDesactivar_Click_1(object sender, EventArgs e)
        {

            try
            {
                DialogResult opcion = MessageBox.Show("Realmente deseas desactivar el(los) registros(s)?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    //EL USUARIO LE DA CLICK OK 
                    int codigo; // Aqui vamos a capturar el codigo de cada categoria seleccionada por el usuario
                    string respuesta = "";

                    // como el usuario puede marcar varias categoria, debemos hacer bucle
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {

                            //OBTENEMOS EL CODIGO DE LA CATEGORIA
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = NUsuario.Desactivar(codigo);

                            if (respuesta == "OK")
                            {
                                this.MensajeOK("Se desactivo el registro:" + Convert.ToString(row.Cells[3].Value));
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }



                        }



                    }
                    this.Listar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {


            try
            {
                DialogResult opcion = MessageBox.Show("Realmente deseas eliminar el(los) registros(s)?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    //EL USUARIO LE DA CLICK OK 
                    int id; // 
                    string respuesta = "";

                    // como el usuario puede marcar varios usuario, debemos hacer bucle
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {

                            //OBTENEMOS EL CODIGO DE LA CATEGORIA
                            id = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = NUsuario.Eliminar(id);

                            if (respuesta == "OK")
                            {
                                this.MensajeOK("Se  ha eliminado el registro:" + Convert.ToString(row.Cells[2].Value));
                            }
                            else
                            {
                                this.MensajeError(respuesta);
                            }



                        }



                    }
                    this.Listar();


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void checkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSeleccionar.Checked)
            {
                //si está marcado el checkbox, entonces
                dgvListado.Columns[0].Visible = true; //muestra la columna Seleccionar
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {
                //si está desmarcado el checkbox, entonces
                dgvListado.Columns[0].Visible = false; //oculta la columna Seleccionar
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;
            }


        }

        private void dgvListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Este codigo nos permite poder seleccionar un checkbox de una fila 
            // 0 registro
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
                if (cmbRol.Text == string.Empty || txtNombre.Text == string.Empty || txtDireccion.Text == string.Empty || txtTelefono.Text == string.Empty || cmbTipoDocumento.Text == string.Empty || txtNumeroDocumento.Text == String.Empty )
                {
                    MensajeError("Falta Ingresar datos Obligatorios");
                }
                else
                {
                    respuesta = NUsuario.Crear
                        
                    (Convert.ToInt32(cmbRol.SelectedValue),
                      txtNombre.Text.Trim(),
                      cmbTipoDocumento.Text.Trim(),
                      txtNumeroDocumento.Text.Trim(),
                      txtDireccion.Text.Trim(),
                      txtTelefono.Text.Trim(),
                      txtEmail.Text.Trim(),
                      txtClave .Text.Trim()
                      //Encoding.UTF8.GetBytes(txtClave.Text)
                      


                     );

                    if (respuesta == "OK")
                    {
                        MensajeOK("Se creo el usuario de manera correcta");
                        this.Listar(); //refresh datagrieview
                    }
                    else
                    {
                        MensajeError(respuesta);
                    }

                }
                this.Listar();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        } 
       

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (cmbRol.Text == string.Empty || txtNombre.Text == string.Empty || txtDireccion.Text == string.Empty || txtTelefono.Text == String.Empty || cmbTipoDocumento.Text == String.Empty || txtNumeroDocumento.Text == String.Empty )  
                {
                    MensajeError("Falta Ingresar datos Obligatorios");
                }
                else
                {
                    string clave = string.IsNullOrWhiteSpace(txtClave.Text) ? "" : txtClave.Text.Trim();


                    respuesta = NUsuario.Actualizar


                        (Convert.ToInt32(txtId.Text),
                        cmbRol.SelectedIndex = 0,
                         txtNombre.Text.Trim(),
                         cmbTipoDocumento.Text.Trim(), 
                         txtNumeroDocumento.Text.Trim(),
                         txtDireccion.Text.Trim(),
                         txtTelefono.Text.Trim(),
                         txtEmail.Text.Trim(),
                         clave

                         //Encoding.UTF8.GetBytes(txtClave.Text)


                         );




                    if (respuesta == "OK")
                    {
                        MensajeOK("Se Actualizo el usuario de manera correcta");
                        this.Listar(); //refresh datagrieview
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
        public static byte[] HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void groupBoxAcceso_Enter(object sender, EventArgs e)
        {

        }

        private void cmbRol_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumeroDocumento_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true; //muestra el boton de actualizar
                btnInsertar.Visible = false; //oculta el boton de insertar
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["ID"].Value);
                cmbRol.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["idRol"].Value);
                txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
                cmbTipoDocumento.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["Tipo_Documento"].Value);
                txtNumeroDocumento.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Num_Documento"].Value);
                txtDireccion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Direccion"].Value);
                txtTelefono.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Telefono"].Value);
                txtEmail.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Email"].Value);
                checkEstado.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Estado"].Value);


                tabControl1.SelectedIndex = 1; // mueve la vista a la pantalla de mantenimiento.





            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }

        }
    }
}
