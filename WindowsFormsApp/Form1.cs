using dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using negocio;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {

        private List<Articulo> listaArticulos;
        public Form1()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargar();

        }
        private void cargar()
        {
            try
            {
                GenericoNegocio negocio = new GenericoNegocio();
                listaArticulos = negocio.listar();
                dgvNegocio.DataSource = listaArticulos;
                dgvNegocio.Columns["Imagen"].Visible = false;
                cargarImagen(listaArticulos[0].Imagen);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void dgvNegocio_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvNegocio.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.Imagen);
        }

        private void pbxArticulos_Click(object sender, EventArgs e)
        {

        }
        private void cargarImagen(string imagen)
        {
            try
            {
                
                pbxArticulos.Load(imagen);
            }
            catch (Exception ex)
            {
                pbxArticulos.Load("https://uning.es/wp-content/uploads/2016/08/ef3-placeholder-image.jpg");
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            FrmAltaArticulo frmAltaArticulo = new FrmAltaArticulo();
            frmAltaArticulo.ShowDialog();
            cargar();
        }
    }
}
