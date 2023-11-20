using System.Runtime.CompilerServices;
using static RobotIA.AEstrella;

namespace RobotIA
{
    public partial class Form1 : Form
    {
        private int[,] plano = new int[1000, 1000];
        Nodo inicio = new Nodo { X = 0, Y = 0 };
        Nodo objetivo = new Nodo { X = 0, Y = 0 };
        public Form1()
        {
            InitializeComponent();
            crearMapa();

        }
        public void crearMapa()
        {
            int Cx = 0;
            int Cy = 0;
            for (int i = 0; i < 25; i++)
            {
                Random rand = new Random();
                for (int j = 0; j < 25; j++)
                {
                    plano[i, j] = 0;

                    Button btn = new Button();
                    btn.Name = "btn_" + i + "_" + j;
                    btn.Tag =
                    btn.Height = 34;
                    btn.Width = 34;
                    Point loc = new Point();
                    loc.X = i * 34;
                    loc.Y = j * 34;
                    if (rand.NextDouble() > 0.8)
                    {
                        btn.BackColor = Color.Black;
                        plano[i, j] = 1;
                    }

                    btn.Location = loc;

                    btn.Margin = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    btn.Padding = new System.Windows.Forms.Padding(0, 0, 0, 0);
                    mapa.Controls.Add(btn);
                    btn.Click += Btn_Click;
                }
            }
        }
        private bool b = true;
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnClic = (Button)sender;
            if (plano[int.Parse(btnClic.Name.Split("_")[1]), int.Parse(btnClic.Name.Split("_")[2])]!=1)
            {
                if (b)
                {
                    btnClic.BackColor = Color.Orange;
                    inicio.X = int.Parse(btnClic.Name.ToString().Split("_")[1]);
                    inicio.Y = int.Parse(btnClic.Name.ToString().Split("_")[2]);
                    b = false;
                }
                else
                {
                    btnClic.BackColor = Color.Red;
                    objetivo.X = int.Parse(btnClic.Name.ToString().Split("_")[1]);
                    objetivo.Y = int.Parse(btnClic.Name.ToString().Split("_")[2]);
                }
            }
            else
            {
                MessageBox.Show("Esta posición es parte del mapa", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void comenzarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Generado camino", "", MessageBoxButtons.OK, MessageBoxIcon.Information);

                AEstrella aEstrella = new AEstrella(plano, inicio, objetivo);
                List<Nodo> camino = aEstrella.EncontrarCamino(inicio, objetivo);

                if (camino != null)
                {
                    int indice = 0;
                    foreach (Nodo nodo in camino)
                    {
                        string nombreBoton = "btn_" + nodo.X + "_" + nodo.Y;
                        Button boton = this.Controls.Find(nombreBoton, true).FirstOrDefault() as Button;
                        if (boton != null)
                        {
                            boton.BackColor = Color.Green;
                            Thread.Sleep(1000);
                        }
                    }
                    MessageBox.Show("Camino generado con exito", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Camino no encontrado", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void reiniciarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            crearMapa();
            b = true;
            inicio = new Nodo { X = 0, Y = 0 };
            objetivo = new Nodo { X = 0, Y = 0 };
        }
    }
}