namespace _2048WinFormsApp
{
    public partial class ResultsForm : Form
    {
        public ResultsForm()
        {
            InitializeComponent();
        }

        private void ResultsForm_Load(object sender, EventArgs e)
        {
            var bestUser = UserRepository.GetBest();
            ResultsDataGridView.Rows.Add("Лучший результат", bestUser.Name, bestUser.Score);
            var results = UserRepository.GetAll();
            foreach (var result in results)
            {
                ResultsDataGridView.Rows.Add("", result.Name, result.Score);
            }
        }
    }
}
