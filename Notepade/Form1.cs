namespace Notepade
{
    public partial class Form1 : Form
    {
        private string currentFilePath = "";
        public Form1()
        {
            InitializeComponent();
        }
            private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (richTextBox1.Text.Length > 0)
                {
                    DialogResult result = MessageBox.Show("Сохранить изменения перед созданием нового файла?", "Блокнот", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes) сохранитьToolStripMenuItem_Click(sender, e);
                    if (result == DialogResult.Cancel) return;
                }

                richTextBox1.Clear();
                currentFilePath = "";
            }
            private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                openFileDialog.Title = "Открыть файл";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        richTextBox1.Text = File.ReadAllText(openFileDialog.FileName);
                        currentFilePath = openFileDialog.FileName;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при открытии файла: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (!string.IsNullOrEmpty(currentFilePath))
                {
                    try
                    {
                        File.WriteAllText(currentFilePath, richTextBox1.Text);
                        MessageBox.Show("Файл успешно сохранен!", "Блокнот", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    сохранитьКакToolStripMenuItem_Click(sender, e);
                }
            }
            private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                saveFileDialog.Title = "Сохранить файл как...";
                saveFileDialog.FileName = "Новый документ.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        File.WriteAllText(saveFileDialog.FileName, richTextBox1.Text);
                        currentFilePath = saveFileDialog.FileName;
                        MessageBox.Show("Файл успешно сохранен!", "Блокнот", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка при сохранении: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            private void выходToolStripMenuItem_Click(object sender, EventArgs e)
            {
                if (richTextBox1.Text.Length > 0)
                {
                    DialogResult result = MessageBox.Show("Вы уверены, что хотите выйти без сохранения?", "Блокнот", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.No) return;
                }
                Application.Exit();
            }
            private void richTextBox1_TextChanged(object sender, EventArgs e)
            {
            }
    }
}