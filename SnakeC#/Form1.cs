namespace SnakeC_
{
    public partial class Form1 : Form
    {
        Game oGame;
        public Form1()
        {
            InitializeComponent();

            oGame = new Game(pictureBox1, labelPoint);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            oGame.Show();
            oGame.Next();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                oGame.ActualDirection = Game.Direccion.Up;
            }
            if (e.KeyCode == Keys.S)
            {
                oGame.ActualDirection = Game.Direccion.Down;
            }
            if (e.KeyCode == Keys.D)
            {
                oGame.ActualDirection = Game.Direccion.Right;
            }
            if (e.KeyCode == Keys.A)
            {
                oGame.ActualDirection = Game.Direccion.Left;
            }
        }

        private void labelPoints_Click(object sender, EventArgs e)
        {

        }
    }
}
