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

        private void button4_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Najpierw wczytaj obraz.");
                return;
            }

            Bitmap bitmap = new Bitmap(pictureBox1.Image);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    Color invertedColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                    bitmap.SetPixel(x, y, invertedColor);
                }
            }

            pictureBox1.Image = bitmap;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (image == null)
            {
                MessageBox.Show("Najpierw wczytaj obraz.");
                return;
            }

            int rotateBy = (180 - currentAngle + 360) % 360;
            RotateFlipType rotation = rotateBy switch
            {
                90 => RotateFlipType.Rotate90FlipNone,
                180 => RotateFlipType.Rotate180FlipNone,
                270 => RotateFlipType.Rotate270FlipNone,
                0 => RotateFlipType.RotateNoneFlipNone,
                _ => RotateFlipType.RotateNoneFlipNone
            };

            image.RotateFlip(rotation);
            pictureBox1.Image = image;

            currentAngle = 180;
        }
    }
}
