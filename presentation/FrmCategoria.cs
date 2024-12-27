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
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
        }

        #region "Mis Metodos Personalizados"
        //Metodo Formato para dar los estilos al dgvListado
        private void Formato()
        {
            dgvListado.Columns[0].Visible = false; //ocualtar la columna Seleccionar
            dgvListado.Columns[1].Visible = false; //ocultar la columna Id
            dgvListado.Columns[2].Width = 170;
            dgvListado.Columns[3].Width = 350;
            dgvListado.Columns[3].HeaderText = "Descripción";
            dgvListado.Columns[4].Width = 100;

        }//fin del metodo Formato

        //Metodo Limpiar para dar formato a los botones y a los cuadros de texto
        private void Limpiar()
        {
            txtBuscar.Clear(); //limpia el textbox   
            txtNombre.Clear();
            txtId.Clear();
            txtDescripcion.Clear();
            btnActivar.Visible = false; //oculta este boton
            btnDesactivar.Visible = false;
            btnEliminar.Visible = false;
            btnInsertar.Visible = true;
            //muestra el boton de insertar categoria
            btnActualizar.Visible = false;
            chkSeleccionar.Checked = false;
            tabControl1.SelectedIndex = 0; //que aparezca el tab de Listado
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
                dgvListado.DataSource = NCategoria.Listar(); 
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


        #endregion

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            //mostramos las categorias
            this.Listar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";

                if (txtNombre.Text == "")
                {
                    this.MensajeError("Debe ingresar un nombre para la Categoría");
                }
                else
                {
                    respuesta = NCategoria.Insertar(txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if (respuesta == "OK")
                    {
                        this.MensajeOK("El registro se insertó de forma correcta");
                        this.Listar(); //refresque el dgvListado
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvListado.DataSource = NCategoria.Buscar(txtBuscar.Text.Trim());
                this.Formato();
                lblTotal.Text = "Total de registros: " + Convert.ToString(dgvListado.RowCount);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true; //muestra el boton de actualizar
                btnCancelar.Visible = true;
                btnInsertar.Visible = false; //oculta el boton de insertar

                txtId.Text = dgvListado.CurrentRow.Cells["ID"].Value.ToString();
                txtNombre.Text = dgvListado.CurrentRow.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = dgvListado.CurrentRow.Cells["Descripcion"].Value.ToString();

                tabControl1.SelectedIndex = 1; //mueve al tabpage de Mantenimiento
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string respuesta = "";
                if (txtNombre.Text == "")
                {
                    this.MensajeError("Debe completar el Campo Nombre");
                }
                else
                {
                    respuesta = NCategoria.Actualizar(Convert.ToInt32(txtId.Text), txtNombre.Text.Trim(), txtDescripcion.Text.Trim());
                    if (respuesta == "OK")
                    {
                        this.MensajeOK("El registro se actualizó correctamente");
                        this.Listar();
                        this.Limpiar();
                    }
                    else
                    {
                        this.MensajeError(respuesta);
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
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
            if (e.ColumnIndex == dgvListado.Columns["Seleccionar"].Index);
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvListado.Rows[e.RowIndex].Cells["Seleccionar"];
                chk.Value = !Convert.ToBoolean(chk.Value);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                 DialogResult opcion = MessageBox.Show("Realmente deseas activar el(los) registros(s)?", "Sistema de Ventas",MessageBoxButtons.OKCancel,MessageBoxIcon.Question);
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
                            respuesta = NCategoria.Activar(codigo);

                            if (respuesta == "OK")
                            {
                                this.MensajeOK("Se activo el registro:" + Convert.ToString(row.Cells[2].Value));
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
                            respuesta = NCategoria.Desactivar(codigo);

                            if (respuesta == "OK")
                            {
                                this.MensajeOK("Se desactivo el registro:" + Convert.ToString(row.Cells[2].Value));
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
                    int codigo; // Aqui vamos a capturar el codigo de cada categoria seleccionada por el usuario
                    string respuesta = "";

                    // como el usuario puede marcar varias categoria, debemos hacer bucle
                    foreach (DataGridViewRow row in dgvListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {

                            //OBTENEMOS EL CODIGO DE LA CATEGORIA
                            codigo = Convert.ToInt32(row.Cells[1].Value);
                            respuesta = NCategoria.Eliminar(codigo);

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

        private void btnDesactualizar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}











