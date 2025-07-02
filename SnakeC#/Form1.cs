namespace SnakeC_
{
    public partial class Form1 : Form
    {
        Game oGame;
        public Form1()
        {
            InitializeComponent();

            oGame = new Game(pictureBox1);
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
    }
}
