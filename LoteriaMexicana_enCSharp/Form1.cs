using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoteriaMexicana_enCSharp
{
    public partial class Form1 : Form
    {
        int chorro;
        int cuatroEsquinas;
        int centro;
        int llenas;

        public static int idCarta;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dibujarTablero();
        }

        private void dibujarTablero()
        {
            panelTablero.Controls.Clear();
            
            Label lbl1 = new Label();
            Random rnd = new Random();

            //List<string> cartas = new List<string> { "Elgallo", "El diablito", "La dama", "El catrín", "El paraguas", "La sirena", "La escalera", "La botella", "El barril", "El árbol", "El melón", "El valiente", "El gorrito", "La muerte", "La pera", "La bandera", "El bandolón", "El violoncello", "La garza", "El pájaro", "La mano", "La bota", "La luna", "El cotorro", "El borracho", "El negrito", "El corazón", "La sandía", "El tambor", "El camarón", "Las jaras", "El músico", "La araña", "El soldado", "La estrella", "El cazo", "El mundo", "El apache", "El nopal", "El alacrán", "La rosa", "La calavera", "La campana", "El cantarito", "El venado", "El sol", "La corona", "La chalupa", "El pino", "El pescado", "La palma", "La maceta", "El arpa", "La rana" };

            List<Image> imagenes = new List<Image> { Properties.Resources._1_ElGallo, Properties.Resources._2loteria, Properties.Resources._3loteria, Properties.Resources._4loteria, Properties.Resources._5loteria, Properties.Resources._6loteria,
            Properties.Resources._7loteria,Properties.Resources._8loteria,Properties.Resources._9loteria,Properties.Resources._10loteria,Properties.Resources._11loteria, Properties.Resources._12loteria,Properties.Resources._13loteria,Properties.Resources._14loteria,
            Properties.Resources._15loteria,Properties.Resources._16loteria,Properties.Resources._17loteria,Properties.Resources._18loteria};

            List<Image> cartasSeleccionadas = new List<Image>();



            

            for (int i = 1; i <= 16; i++) // Seleccionar 5 cartas
            {
                int cartaIndex = rnd.Next(0, imagenes.Count); // Generar un índice aleatorio

                while (cartasSeleccionadas.Contains(imagenes[cartaIndex])) // Verificar si la carta ya ha sido seleccionada
                {
                    cartaIndex = rnd.Next(0, imagenes.Count); // Si ya ha sido seleccionada, generar otro índice
                }

                cartasSeleccionadas.Add(imagenes[cartaIndex]); // Agregar la carta seleccionada a la lista de cartas seleccionadas
                Console.WriteLine(imagenes[cartaIndex]); // Imprimir la carta seleccionada
                Button b1 = new Button();
                Image imagen = imagenes[cartaIndex];
                b1.Size = new Size(153, 207);
                b1.FlatStyle = FlatStyle.Flat;
                b1.BackgroundImage = imagen;
                b1.BackgroundImageLayout = ImageLayout.Stretch;
                b1.Text = i.ToString();
                b1.Name = i.ToString();
                panelTablero.Controls.Add(b1);

                b1.Click += new EventHandler(eventoButton);
            }




            panelTablero.Controls.Add(lbl1);
        }

        private void btnOtraCarta_Click(object sender, EventArgs e)
        {
            dibujarTablero();
            chorro = 0;
            txtChorro.Text = chorro.ToString(); ;
        }

        private void VerificaChorro()
        {
            chorro++;
            txtChorro.Text = chorro.ToString();

            if (chorro == 4)
            {
                MessageBox.Show("Chorroooo");
            }
        }

        private void eventoButton(object sender, EventArgs e)
        {
            try
            {
                idCarta = Convert.ToInt32(((Button)sender).Name);
                

                foreach (Control botonCarta in panelTablero.Controls)
                {
                    if (botonCarta is Button)
                    {
                        if (botonCarta.Name == idCarta.ToString())
                        {
                            botonCarta.Enabled = false;
                            botonCarta.ForeColor = Color.Red;
                            VerificaChorro();
                        }

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
