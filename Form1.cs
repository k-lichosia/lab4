namespace lab4
{
    public partial class Form1 : Form
    {
        private Image image;
        private int currentAngle = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Pliki BMP (*.bmp)|*.bmp|Wszystkie pliki (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = Image.FromFile(openFileDialog.FileName);
                pictureBox1.Image = image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Najpierw wczytaj obraz.");
                return;
            }

            int angle = 0;

            if (radioButton1.Checked)
                angle = 90;
            else if (radioButton2.Checked)
                angle = 180;
            else if (radioButton3.Checked)
                angle = 270;

            currentAngle = (currentAngle + angle) % 360;

            RotateFlipType rotation = angle switch
            {
                90 => RotateFlipType.Rotate90FlipNone,
                180 => RotateFlipType.Rotate180FlipNone,
                270 => RotateFlipType.Rotate270FlipNone,
                _ => RotateFlipType.RotateNoneFlipNone
            };

            image.RotateFlip(rotation);
            pictureBox1.Image = image;
        }
    }
}
