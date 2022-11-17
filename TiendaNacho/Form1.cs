using MySqlConnector;
using System.Data;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace TiendaNacho
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public DataSet ds { get; set; }

        static string fuente = "server=localhost;uid=root;pwd=contraseña; database=tiendaropa;";
        MySqlConnection ob = new MySqlConnection(fuente);

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBoxId.Text;
            string Marca = textBoxMarca.Text;
            string Precio = textBoxPrecio.Text;
            string Talla = textBoxTalla.Text;
            string Tipo = textBoxTipo.Text;
            string Descripcion = textBoxDesc.Text;

            if (textBoxMarca.Text.Equals("") || textBoxPrecio.Text.Equals("") || textBoxDesc.Text.Equals("") || textBoxTipo.Text.Equals("") || textBoxTalla.Text.Equals(""))
            {
                MessageBox.Show("Complete todos los campos");
            }
            else
            {

                string insertar = "INSERT INTO categorias (marca ,precio ,talla ,tipo ,descripcion ) VALUES ('" + textBoxMarca.Text + "' , '" + textBoxPrecio.Text + "' , '" + textBoxTalla.Text + "' , '" + textBoxTipo.Text + "' , '" + textBoxDesc.Text + " ')";
                MySqlCommand cmd = new MySqlCommand(insertar, ob);

                try
                {

                    ob.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Datos agregados con éxito");

                    ob.Close();
                    Limpiar();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Se ha producido un error contacte a soporte, "+ error);
                }
                //ACUALIZACION EN TIRMPO REAL
                string comando = "select * from categorias";
                MySqlCommand ejecuta = new MySqlCommand(comando, ob);
                MySqlDataAdapter con = new MySqlDataAdapter(ejecuta);

                ds = new DataSet();
                con.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBoxId.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el identificador del producto");


            }
            else
            {
                ob.Open();
                string id = textBoxId.Text;
                string query = ("delete from categorias where category_id = " + textBoxId.Text);
                MySqlCommand cmd = new MySqlCommand(query, ob);

                cmd.ExecuteNonQuery();
                MessageBox.Show("La categoría se ha eliminado con éxito");
                ob.Close();
                Limpiar();

                //actualizacion en tiempo real

                string comando = "select * from categorias";
                MySqlCommand ejecuta = new MySqlCommand(comando, ob);
                MySqlDataAdapter con = new MySqlDataAdapter(ejecuta);

                ds = new DataSet();
                con.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string query = "update categorias set precio =" + textBoxPrecio.Text + " where category_id=" + textBoxId.Text.ToString() + "";

            MySqlCommand cmd = new MySqlCommand(query, ob);

            ob.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registro actualizado");

            ob.Close(); 
            Limpiar();
            //ACTUALIZACION EN TIEPO REAL


            string comando = "select * from categorias";
            MySqlCommand ejecuta = new MySqlCommand(comando, ob);
            MySqlDataAdapter con = new MySqlDataAdapter(ejecuta);

            ds = new DataSet();
            con.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string comando = "select * from categorias";
            MySqlCommand ejecuta = new MySqlCommand(comando, ob);
            MySqlDataAdapter con = new MySqlDataAdapter(ejecuta);

            ds = new DataSet();
            con.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void Limpiar()
        {
            textBoxId.Text = "";
            textBoxMarca.Text = "";
            textBoxPrecio.Text = "";
            textBoxTalla.Text = "";
            textBoxTipo.Text = "";
            textBoxDesc.Text = "";
        }
    }
}