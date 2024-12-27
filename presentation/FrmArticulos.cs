using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace presentation
{
    public partial class FrmArticulos : Form
    {
        public FrmArticulos()
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

        //Metodo Limpiar para dar formato a los botones y a los cuadros de texto
        private void Limpiar()
        {
            txtBuscar.Clear(); //limpia el textbox
            txtNombre.Clear();
            txtStock.Clear();
            txtPrecioVenta.Clear();
            txtDescripcion.Clear();
            txtCodigoBarras.Clear();
            btnActivar.Visible = false; //oculta este boton
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = true; //muestra el boton de insertar categoria
            btnActualizar.Visible = false;
            btnDesactualizar.Visible = false;
            chkSeleccionar.Checked = false;
            tabPrincipal.SelectedIndex = 0; //que aparezca el tab de Listado
        }//fin del metodo Limpiar

        //Mensaje de Ok
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        } // Fin del metodo MensajeOK

        //Mensaje de Error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } // Fin del metodo MensajeOK

        //Metodo para listar las categorias en el DataGridView dgvListado
        private void Listar()
        {
            try
            {
                //llenar el dgvListado
                dgvListado.DataSource = NArticulo.Listar();
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

        private void ListarCategoriasArticulos()

        {
            try
            {
                cmbCategoria.DataSource = NCategoria.ListarCategoriasArticulos();
                cmbCategoria.ValueMember = "idcategoria";
                cmbCategoria.DisplayMember = "Nombre";


            }
            catch (Exception ex)
            {

            }


        }




        private void FrmArticulos_Load(object sender, EventArgs e)
        {
           
                this.Listar();
                this.ListarCategoriasArticulos(); 
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = NArticulo.Buscar(txtBuscar.Text);
                this.Formato();
                lblTotal.Text = "Total de registros:" + Convert.ToString(dgvListado.DataSource);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
            
            
                

        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if(cmbCategoria.Text == string.Empty || txtNombre.Text ==  string.Empty ||txtPrecioVenta.Text == string.Empty || txtStock.Text == String.Empty)
                {
                    MensajeError("Falta Ingresar datos Obligatorios");
                }
                else 
                {
                    respuesta = NArticulo.Insertar

                    (Convert.ToInt32(cmbCategoria.SelectedValue),
                      txtCodigoBarras.Text.Trim(),
                      txtNombre.Text.Trim(),
                      Convert.ToDecimal(txtPrecioVenta.Text),
                      Convert.ToInt32(txtStock.Text),
                      txtDescripcion.Text,"");
                
                if (respuesta == "OK")
                    {
                        MensajeOK("Se inserto el registro de manera correcta");
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




        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

      
        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true; //muestra el boton de actualizar
                btnDesactualizar.Visible = true;
                btnCancelar.Visible = true;
                btnInsertar.Visible = false; //oculta el boton de insertar
                txtId.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Id"].Value);
                cmbCategoria.SelectedValue = Convert.ToString(dgvListado.CurrentRow.Cells["idcategoria"].Value);
                txtCodigoBarras.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Codigo"].Value);
                txtNombre.Text = Convert.ToString(dgvListado.CurrentRow.Cells["Nombre"].Value);
                txtPrecioVenta.Text = Convert.ToString(dgvListado.CurrentRow.Cells["precio_venta"].Value);
                txtStock.Text = Convert.ToString(dgvListado.CurrentRow.Cells["stock"].Value);
                txtDescripcion.Text = Convert.ToString(dgvListado.CurrentRow.Cells["descripcion"].Value);
                txtImagen.Text = "";

                tabPrincipal.SelectedIndex = 1; // mueve la vista a la pantalla de mantenimiento.





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
                if (cmbCategoria.Text == string.Empty || txtNombre.Text == string.Empty || txtPrecioVenta.Text == string.Empty || txtStock.Text == String.Empty)
                {
                    MensajeError("Falta Ingresar datos Obligatorios");
                }
                else
                {
                    respuesta = NArticulo.Actualizar

                    ( Convert.ToInt32(txtId.Text),
                    Convert.ToInt32(cmbCategoria.SelectedValue),
                      txtCodigoBarras.Text.Trim(),
                      txtNombre.Text.Trim(),
                      Convert.ToDecimal(txtPrecioVenta.Text),
                      Convert.ToInt32(txtStock.Text),
                      txtDescripcion.Text, "");

                    if (respuesta == "OK")
                    {
                        MensajeOK("Se Actualizo el registro de manera correcta");
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void chkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeleccionar.Checked)
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
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index) ;
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                chk.Value = !Convert.ToBoolean(chk.Value);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("Realmente deseas activar el(los) registros(s)?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
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
                            respuesta = NArticulo.Activar(codigo);

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

        private void btnDesactivar_Click(object sender, EventArgs e)
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
                            respuesta = NArticulo.Desactivar(codigo);

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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult opcion = MessageBox.Show("Realmente deseas eliminar el(los) registros(s)?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (opcion == DialogResult.OK)
                {
                    //EL USUARIO LE DA CLICK OK 
                    int id; // Aqui vamos a capturar el codigo de cada categoria seleccionada por el usuario
                    string respuesta = "";

                    // como el usuario puede marcar varias categoria, debemos hacer bucle
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {

                            //OBTENEMOS EL CODIGO DE LA CATEGORIA
                            id = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = NArticulo.Eliminar(id);

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
    }
  }
    
    
    

