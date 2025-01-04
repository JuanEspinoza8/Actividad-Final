using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
using accesoDatos;
using System.Data.SqlClient;

namespace negocio
{
    public class GenericoNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            //SqlConnection conexion = new SqlConnection();
            //SqlCommand comando = new SqlCommand();
            //SqlDataReader lector;

                Acceso datos = new Acceso();


            try
            {
                //conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true";
                //comando.CommandType = System.Data.CommandType.Text;
                //comando.CommandText = "Select Codigo, Nombre, A.Descripcion, ImagenUrl, M.Descripcion Marca, C.Descripcion Categoria, Precio \r\nFrom ARTICULOS A, CATEGORIAS C, MARCAS M\r\nWhere A.IdMarca = M.Id AND A.IdCategoria = C.Id";
                //comando.Connection = conexion;

                //conexion.Open();
                //lector = comando.ExecuteReader();
                datos.setearConsulta("Select Codigo, Nombre, A.Descripcion, ImagenUrl, M.Descripcion Marca, C.Descripcion Categoria, Precio \r\nFrom ARTICULOS A, CATEGORIAS C, MARCAS M\r\nWhere A.IdMarca = M.Id AND A.IdCategoria = C.Id");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Imagen = (string)datos.Lector["ImagenUrl"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Precio = (decimal)datos.Lector["Precio"];

                    lista.Add(aux);

                }

                datos.cerrarConexion();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
            
            
        }
    }
}
