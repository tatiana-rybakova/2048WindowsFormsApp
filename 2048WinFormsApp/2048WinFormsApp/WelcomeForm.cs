namespace _2048WinFormsApp
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            if (NameTextBox.Text == "")
            {
                MessageBox.Show("Введите имя!");
            }
            else
            {
                Close();
                DialogResult = DialogResult.OK;
            }
        }
    }
}
