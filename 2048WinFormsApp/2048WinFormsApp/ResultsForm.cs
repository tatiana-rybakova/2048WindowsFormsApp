using _2048ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
