using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheBrains;

namespace WindowsFormsGUI
{
    public partial class Form1 : Form
    {


        private string filePath;
        private List<List<string>> results;


        public Form1()
        {
            InitializeComponent();
            InitializeDataGridView();
        }

        private void InitializeDataGridView()
        {
            dataGridView1.ColumnCount = 5;
            dataGridView1.Columns[0].Name = "Word 1";
            dataGridView1.Columns[1].Name = "Word 2";
            dataGridView1.Columns[2].Name = "Word 3";
            dataGridView1.Columns[3].Name = "Word 4";
            dataGridView1.Columns[4].Name = "Word 5";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog.FileName;
                MessageBox.Show("File selected: " + filePath);
            }
        }

        private void btnRunSolver_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("Please select a file first.");
                return;
            }

            // Call the Anagram Solver method here and store the results
            Brain anagramSolver = new Brain();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            results = anagramSolver.Solve(filePath);

            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;

            // Update labels with the number of combinations found and time taken
            lblCombinationsFound.Text = "Combinations Found: " + results.Count;
            lblTimeTaken.Text = "Time Taken: " + elapsedTime.ToString(@"mm\:ss\.ff");

            MessageBox.Show("Anagram Solver executed successfully!");

            // Populate the DataGridView with the results
            PopulateDataGridView();
        }


        private void PopulateDataGridView()
        {
            dataGridView1.Rows.Clear();

            foreach (var combination in results)
            {
                dataGridView1.Rows.Add(combination.ToArray());
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (results == null || results.Count == 0)
            {
                MessageBox.Show("No results to export.");
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.FileName = "anagram_results.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string outputPath = saveFileDialog.FileName;

                // Write results to the output file
                using (StreamWriter writer = new StreamWriter(outputPath))
                {
                    foreach (var combination in results)
                    {
                        writer.WriteLine(string.Join(" ", combination));
                    }
                }

                MessageBox.Show("Results exported successfully to: " + outputPath);
            }
        }
    }
}
