using MySqlConnector;
using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        static string fuente = "server= localhost; user=root; pwd=Humacontomatepapi11; database=tiendaropa;";
        MySqlConnection ob = new MySqlConnection(fuente);


        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBoxid.Text;
            string Marca = textBoxMARCA.Text;
            string Precio = textBoxprecio.Text;
            string Talla = textBoxtalla.Text;
            string Tipo = textBox4TIPO.Text;
            string Descripcion = textBoxDesc.Text;

            if (textBoxid.Text.Equals("") || textBoxMARCA.Text.Equals("") || textBoxprecio.Text.Equals("") || textBoxDesc.Text.Equals("") || textBox4TIPO.Text.Equals("") || textBoxtalla.Text.Equals(""))
            {
                MessageBox.Show("Complete todos los campos");
            }
            else
            {

                string insertar = "INSERT INTO 'categorias' (category_id ,marca ,precio ,talla ,tipo ,descripcion ) VALUES ('" + textBoxid.Text + "' , '" + textBoxMARCA.Text + "' , '" + textBoxprecio.Text + "' , '" + textBoxtalla.Text + "' , '" + textBox4TIPO.Text + "' , '" + textBoxDesc.Text + " ')";
                MySqlCommand cmd = new MySqlCommand(insertar, ob);

                try
                {

                    ob.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Datos agregados con éxito");

                    ob.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Se ha producido un error contacte a soporte");
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


        public DataSet ds { get; set; }

        private void buttonEli_Click(object sender, EventArgs e)
        {
            if (textBoxid.Text.Equals(""))
            {
                MessageBox.Show("Ingrese el identificador del producto");


            }
            else
            {
                ob.Open();
                string id = textBoxid.Text;
                string query = ("delete from categorias where category_id = " + textBoxid.Text);
                MySqlCommand cmd = new MySqlCommand(query, ob);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Éxito en la operación");
                ob.Clone();

                //actualizacion en tiempo real

                string comando = "select * from categotias";
                MySqlCommand ejecuta = new MySqlCommand(comando, ob);
                MySqlDataAdapter con = new MySqlDataAdapter(ejecuta);

                ds = new DataSet();
                con.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];

            }
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {

            string query = "update categorias set precio =" + textBoxprecio.Text + " where category_id=" + textBoxid.Text.ToString() + "";

            MySqlCommand cmd = new MySqlCommand(query, ob);

            ob.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Registro actualizado");


            //ACTUALIZACION EN TIEPO REAL


            string comando = "select * from categorias";
            MySqlCommand ejecuta = new MySqlCommand(comando, ob);
            MySqlDataAdapter con = new MySqlDataAdapter(ejecuta);

            ds = new DataSet();
            con.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

        }

        private void buttonSalir_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show("Salir del programa", "salir y cerrar conexión", MessageBoxButtons.YesNo,MessageBoxIcon.Question )) 
            //{

            //    ob.Clone();
            //    this.Close();
            //}
        }
        private void bottonVer_Click(object sender, EventArgs e)
        {
            textBoxid.Text = "";
            textBoxMARCA.Text = "";
            textBoxprecio.Text = "";
            textBoxtalla.Text = "";
            textBox4TIPO.Text = "";
            textBoxDesc.Text = "";




        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}




























