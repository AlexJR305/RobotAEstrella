using System.Runtime.CompilerServices;
using static RobotIA.AEstrella;

namespace RobotIA
{
    public partial class Form1 : Form
    {
        private int MapaSel = 0;
        private int[,] plano = new int[25, 25];
        Nodo inicio = new Nodo { X = 0, Y = 0 };
        Nodo objetivo = new Nodo { X = 0, Y = 0 };
        public Form1()
        {
            InitializeComponent();
            crearMapa(MapaSel);
        }
        public void crearMapa(int m)
        {
            for (int i = 0; i < 25; i++)
            {
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
                    plano[i, j] = 0;
                    if (i == 0 || i == 24 || j == 0 || j == 24)
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
            //Colocar barreras
            string NomMapa = "";
            if (m == 1)
            {
                NomMapa = "..\\Mapa1.txt";
            }
            else if (m == 2)
            {
                NomMapa = "..\\Mapa2.txt";
            }
            else if (m == 3)
            {
                NomMapa = "..\\Mapa3.txt";
            }
            else if (m == 4)
            {
                NomMapa = "..\\Mapa4.txt";
            }
            else if (m == 5)
            {
                NomMapa = "..\\Mapa5.txt";
            }
            else if (m == 6)
            {
                NomMapa = "..\\Mapa6.txt";
            }
            else if (m == 7)
            {
                NomMapa = "..\\Mapa7.txt";
            }
            else if (m == 8)
            {
                NomMapa = "..\\Mapa8.txt";
            }
            else if (m == 9)
            {
                NomMapa = "..\\Mapa9.txt";
            }
            else if (m == 10)
            {
                NomMapa = "..\\Mapa10.txt";
            }
            List<Nodo> lines = new List<Nodo>();
            String line = "";
            if (m != 0)
            {
                try
                {
                    StreamReader sr = new StreamReader(NomMapa);
                    line = sr.ReadLine();

                    while (line != null)
                    {
                        int t = line.Split(' ').Length;
                        for (int i = 0; i < t; i++)
                        {
                            Nodo cord = new Nodo();
                            cord.X = int.Parse((line.Split(' ')[i]).Split(',')[1]);
                            cord.Y = int.Parse((line.Split(' ')[i]).Split(',')[0]);
                            lines.Add(cord);
                            Console.WriteLine(cord.X + " " + cord.Y);
                        }
                        line = sr.ReadLine();
                    }
                    sr.Close();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                foreach (Nodo nodo in lines)
                {
                    string posBarr = "btn_" + nodo.X + "_" + nodo.Y;
                    Button boton = this.Controls.Find(posBarr, true).FirstOrDefault() as Button;
                    if (boton != null)
                    {
                        boton.BackColor = Color.Black;
                        plano[nodo.X, nodo.Y] = 1;
                    }
                }
            }

        }
        private bool b = true;

        private void Btn_Click(object sender, EventArgs e)
        {
            Button btnClic = (Button)sender;
            if (plano[int.Parse(btnClic.Name.Split("_")[1]), int.Parse(btnClic.Name.Split("_")[2])] != 1)
            {
                if (b)
                {
                    btnClic.BackColor = Color.Orange;
                    btnClic.Text = "S";
                    btnClic.ForeColor = Color.White;
                    inicio.X = int.Parse(btnClic.Name.ToString().Split("_")[1]);
                    inicio.Y = int.Parse(btnClic.Name.ToString().Split("_")[2]);
                    b = false;
                }
                else
                {
                    btnClic.BackColor = Color.Red;
                    btnClic.Text = "D";
                    btnClic.ForeColor = Color.White;
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
                //hilo
                List<Nodo> camino = aEstrella.EncontrarCamino(inicio, objetivo);
                //fin de hilo

                if (camino != null)
                {

                    List<Nodo> vecinos = aEstrella.TodosLosVecinosEncontrados();
                    foreach (Nodo nodo in vecinos)
                    {
                        string nombreVecino = "btn_" + nodo.X + "_" + nodo.Y;
                        Button boton = this.Controls.Find(nombreVecino, true).FirstOrDefault() as Button;
                        if (boton != null)
                        {
                            boton.BackColor = Color.CadetBlue;
                        }
                    }
                    foreach (Nodo nodo in camino)
                    {
                        string nombreBoton = "btn_" + nodo.X + "_" + nodo.Y;
                        Button boton = this.Controls.Find(nombreBoton, true).FirstOrDefault() as Button;
                        if (boton != null)
                        {
                            boton.BackColor = Color.Red;
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
            crearMapa(MapaSel);
            b = true;
            inicio = new Nodo { X = 0, Y = 0 };
            objetivo = new Nodo { X = 0, Y = 0 };
        }

        private void mapaNteriorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            b = true;
            inicio = new Nodo { X = 0, Y = 0 };
            objetivo = new Nodo { X = 0, Y = 0 };

            MapaSel--;
            if (MapaSel == -1)
            {
                MapaSel = 10;
            }
            crearMapa(MapaSel);
        }

        private void mapaSiguienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Controls.Clear();
            InitializeComponent();
            b = true;
            inicio = new Nodo { X = 0, Y = 0 };
            objetivo = new Nodo { X = 0, Y = 0 };

            MapaSel++;
            if (MapaSel == 11)
            {
                MapaSel = 0;
            }
            crearMapa(MapaSel);
        }
    }
}