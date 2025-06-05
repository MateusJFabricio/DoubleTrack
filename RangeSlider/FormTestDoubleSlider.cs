namespace RangeSlider
{
    public partial class FormTestDoubleSlider : Form
    {
        int testeNumber = 1;
        public FormTestDoubleSlider()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mvRangeSlider1.Min -= 10;
            mvRangeSlider1.Max += 10;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mvRangeSlider1.Label = "Teste" + (testeNumber*=10).ToString();
        }
    }
}
