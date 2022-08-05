using _2048ClassLibrary;

namespace _2048WinFormsApp
{
    public partial class MainForm : Form
    {
        private Label[,] labelsMap;
        private static Random random = new Random();
        private int score = 0;
        private List<string> numbers = new List<string>() { "2", "2", "2", "4" };
        User user;
        Map map;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            WelcomeForm welcomeForm = new WelcomeForm();
            welcomeForm.ShowDialog();

            if (welcomeForm.DialogResult == DialogResult.Cancel)
            {
                Application.Exit();
            }

            user = new User(welcomeForm.NameTextBox.Text);

            switch (welcomeForm.sizeListBox.SelectedIndex)
            {
                case 0: map = new Map(4); break;
                case 1: map = new Map(7); break;
                case 2: map = new Map(9); break;
            }

            InitMap();
            GenerateNumber();
            ShowScore();
        }

        private void InitMap()
        {
            labelsMap = new Label[map.Size, map.Size];
            for (var i = 0; i < map.Size; i++)
            {
                for (var j = 0; j < map.Size; j++)
                {
                    var newLabel = CreateLabel(i, j);
                    Controls.Add(newLabel);
                    labelsMap[i, j] = newLabel;
                }
            }
        }

        private Label CreateLabel(int indexRow, int indexColumn)
        {
            var label = new Label();
            label.BackColor = SystemColors.ActiveCaption;
            label.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            int x = 10 + indexColumn * 76;
            int y = 70 + indexRow * 76;
            label.Location = new Point(x, y);
            label.Size = new Size(70, 70);
            label.TextAlign = ContentAlignment.MiddleCenter;
            return label;
        }

        private void GenerateNumber()
        {
            var emptyLabels = CheckEmpty();
            var win = CheckWinning();
            if(win)
            {
                MessageBox.Show("Победа! Вы получили 2048!");
                user.Score = score;
                UserRepository.SaveBestResult(user);
                UserRepository.SaveResults(user);
            }            
            else if (!emptyLabels)
            {
                MessageBox.Show("Игра окончена! Ходов больше нет");
                user.Score = score;
                UserRepository.SaveBestResult(user);
                UserRepository.SaveResults(user);
            }
            else
            {
                while (true)
                {
                    var randomNumberLabel = random.Next(map.Size * map.Size);
                    var randomColumn = randomNumberLabel % map.Size;
                    var randomRow = randomNumberLabel / map.Size;
                    if (labelsMap[randomRow, randomColumn].Text == string.Empty)
                    {
                        var randomNumber = random.Next(0, 4);
                        labelsMap[randomRow, randomColumn].Text = numbers[randomNumber];
                        labelsMap[randomRow, randomColumn].BackColor = LabelColor(numbers[randomNumber]);
                        break;
                    }
                }
            }
        }

        private bool CheckWinning()
        {
            for (var i = 0; i < map.Size; i++)
            {
                for (var j = 0; j < map.Size; j++)
                {
                    if (labelsMap[i, j].Text == "2048")
                    {
                        return true;
                        break;
                    }                                      
                }
            } 
            return false; 
        }

        private bool CheckEmpty()
        {
            int emptyLabels = 0;
            for (var i = 0; i < map.Size; i++)
            {
                for (var j = 0; j < map.Size; j++)
                {
                    if (labelsMap[i, j].Text == string.Empty)
                        emptyLabels++;
                }
            }
            return emptyLabels > 0;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                for (var i = 0; i < map.Size; i++)
                {
                    for (var j = map.Size - 1; j >= 0; j--)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (var k = j - 1; k >= 0; k--)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    if (labelsMap[i, j].Text == labelsMap[i, k].Text)
                                    {
                                        var number = int.Parse(labelsMap[i, j].Text);
                                        score += number * 2;
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[i, j].BackColor = LabelColor((number * 2).ToString());
                                        labelsMap[i, k].Text = string.Empty;
                                        labelsMap[i, k].BackColor = LabelColor("");
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (var i = 0; i < map.Size; i++)
                {
                    for (var j = map.Size - 1; j >= 0; j--)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (var k = j - 1; k >= 0; k--)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    labelsMap[i, j].Text = labelsMap[i, k].Text;
                                    labelsMap[i, j].BackColor = LabelColor(labelsMap[i, k].Text);
                                    labelsMap[i, k].Text = string.Empty;
                                    labelsMap[i, k].BackColor = LabelColor("");
                                    break;
                                }
                            }
                        }
                    }
                }
                GenerateNumber();
            }
            if (e.KeyCode == Keys.Left)
            {
                for (var i = 0; i < map.Size; i++)
                {
                    for (var j = 0; j < map.Size; j++)
                    {
                        if (labelsMap[i, j].Text != string.Empty)
                        {
                            for (var k = j + 1; k < map.Size; k++)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    if (labelsMap[i, j].Text == labelsMap[i, k].Text)
                                    {
                                        var number = int.Parse(labelsMap[i, j].Text);
                                        score += number * 2;
                                        labelsMap[i, j].Text = (number * 2).ToString();
                                        labelsMap[i, j].BackColor = LabelColor((number * 2).ToString());
                                        labelsMap[i, k].Text = string.Empty;
                                        labelsMap[i, k].BackColor = LabelColor("");
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (var i = 0; i < map.Size; i++)
                {
                    for (var j = 0; j < map.Size; j++)
                    {
                        if (labelsMap[i, j].Text == string.Empty)
                        {
                            for (var k = j + 1; k < map.Size; k++)
                            {
                                if (labelsMap[i, k].Text != string.Empty)
                                {
                                    labelsMap[i, j].Text = labelsMap[i, k].Text;
                                    labelsMap[i, j].BackColor = LabelColor(labelsMap[i, k].Text);
                                    labelsMap[i, k].Text = string.Empty;
                                    labelsMap[i, k].BackColor = LabelColor("");
                                    break;
                                }
                            }
                        }
                    }
                }
                GenerateNumber();
            }

            if (e.KeyCode == Keys.Down)
            {
                for (var i = 0; i < map.Size; i++)
                {
                    for (var j = map.Size - 1; j >= 0; j--)
                    {
                        if (labelsMap[j, i].Text != string.Empty)
                        {
                            for (var k = j - 1; k >= 0; k--)
                            {
                                if (labelsMap[k, i].Text != string.Empty)
                                {
                                    if (labelsMap[j, i].Text == labelsMap[k, i].Text)
                                    {
                                        var number = int.Parse(labelsMap[j, i].Text);
                                        score += number * 2;
                                        labelsMap[j, i].Text = (number * 2).ToString();
                                        labelsMap[j, i].BackColor = LabelColor((number * 2).ToString());
                                        labelsMap[k, i].Text = string.Empty;
                                        labelsMap[k, i].BackColor = LabelColor("");
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (var i = 0; i < map.Size; i++)
                {
                    for (var j = map.Size - 1; j >= 0; j--)
                    {
                        if (labelsMap[j, i].Text == string.Empty)
                        {
                            for (var k = j - 1; k >= 0; k--)
                            {
                                if (labelsMap[k, i].Text != string.Empty)
                                {
                                    labelsMap[j, i].Text = labelsMap[k, i].Text;
                                    labelsMap[j, i].BackColor = LabelColor(labelsMap[k, i].Text);
                                    labelsMap[k, i].Text = string.Empty;
                                    labelsMap[k, i].BackColor = LabelColor("");
                                    break;
                                }
                            }
                        }
                    }
                }
                GenerateNumber();
            }
            if (e.KeyCode == Keys.Up)
            {
                for (var i = 0; i < map.Size; i++)
                {
                    for (var j = 0; j < map.Size; j++)
                    {
                        if (labelsMap[j, i].Text != string.Empty)
                        {
                            for (var k = j + 1; k < map.Size; k++)
                            {
                                if (labelsMap[k, i].Text != string.Empty)
                                {
                                    if (labelsMap[j, i].Text == labelsMap[k, i].Text)
                                    {
                                        var number = int.Parse(labelsMap[j, i].Text);
                                        score += number * 2;
                                        labelsMap[j, i].Text = (number * 2).ToString();
                                        labelsMap[j, i].BackColor = LabelColor((number * 2).ToString());
                                        labelsMap[k, i].Text = string.Empty;
                                        labelsMap[k, i].BackColor = LabelColor("");
                                    }
                                    break;
                                }
                            }
                        }
                    }
                }
                for (var i = 0; i < map.Size; i++)
                {
                    for (var j = 0; j < map.Size; j++)
                    {
                        if (labelsMap[j, i].Text == string.Empty)
                        {
                            for (var k = j + 1; k < map.Size; k++)
                            {
                                if (labelsMap[k, i].Text != string.Empty)
                                {
                                    labelsMap[j, i].Text = labelsMap[k, i].Text;
                                    labelsMap[j, i].BackColor = LabelColor(labelsMap[k, i].Text);
                                    labelsMap[k, i].Text = string.Empty;
                                    labelsMap[k, i].BackColor = LabelColor("");
                                    break;
                                }
                            }
                        }
                    }
                }
                GenerateNumber();
            }
            ShowScore();
        }

        private void ShowScore()
        {
            ScoreLabel.Text = score.ToString();
            var bestUser = UserRepository.GetBest();
            bestSoreLabel.Text = bestUser.Score.ToString();
        }

        private Color LabelColor(string number)
        {
            switch (number)
            {               
                case "4": return SystemColors.MenuHighlight; 
                case "8": return SystemColors.Highlight; 
                case "16": return SystemColors.HotTrack; 
                case "32": return SystemColors.GradientActiveCaption; 
                case "64": return SystemColors.ScrollBar; 
                case "128": return SystemColors.ButtonShadow; 
                case "256": return SystemColors.Info; 
                case "512": return SystemColors.GradientInactiveCaption; 
                case "1024": return SystemColors.AppWorkspace;
                case "2048": return SystemColors.Window;
                default : return SystemColors.ActiveCaption;
            }            
        }

        private void правилаИгрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В каждом раунде появляется плитка номинала 2 (с вероятностью 90 %) или 4 (с вероятностью 10 %). " +
                "Нажатием стрелки игрок может скинуть все плитки игрового поля в одну из 4 сторон.Если при сбрасывании две плитки одного номинала " +
                "«налетают» одна на другую, то они превращаются в одну, номинал которой равен сумме соединившихся плиток." +
                "После каждого хода на свободной секции поля появляется новая плитка номиналом «2» или «4». " +
                "Если при нажатии кнопки местоположение плиток или их номинал не изменится, то ход не совершается." +
                "Если в одной строчке или в одном столбце находится более двух плиток одного номинала, " +
                "то при сбрасывании они начинают соединяться с той стороны, в которую были направлены." +
                "Например, находящиеся в одной строке плитки(4, 4, 4) после хода влево превратятся в(8, 4), " +
                "а после хода вправо — в(4, 8).Данная обработка неоднозначности позволяет более точно формировать стратегию игры. " +
                "За каждое соединение игровые очки увеличиваются на номинал получившейся плитки. Игра заканчивается поражением, " +
                "если после очередного хода невозможно совершить действие.");
        }

        private void зановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void таблицаРезультатовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResultsForm resultsForm = new ResultsForm();
            resultsForm.Show();
        }
    }
}



