using BusinessLogic.QueryHandling;
using DataActions;

namespace DLX_homework_winforms
{
    public partial class Form1 : Form
    {
        private readonly Facade _facade;
        private readonly ApplicationDbContext _applicationDbContext;
        private readonly OutputHandler _outputHandler;
        public Form1(Facade facade, ApplicationDbContext applicationDbContext)
        {
            InitializeComponent();
            _facade = facade;
            _applicationDbContext = applicationDbContext;
            _outputHandler = new OutputHandler(txtResultsDisplay);
        }

        private async void btnExecuteQuery_Click(object sender, EventArgs e)
        {
            if (txtQueryInput.Text == "")
            {
                MessageBox.Show("Insert a search query.", "No query", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstSelectedFiles.Items.Count == 0)
            {
                MessageBox.Show("Select at least 1 file.", "No files selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string query = txtQueryInput.Text;

            List<string> filePaths = lstSelectedFiles.Items.Cast<string>().ToList();

            _facade.InitializeSettings(chkSaveToDb.Checked, chkAllowDuplicates.Checked);
            if (await _facade.ExecuteQuery(query, filePaths))
            {
                _outputHandler.AppendMessage("Query executed successfully!", MessageType.Success);

                switch (_facade.HighestSeverity())
                {
                    case 1:
                    case 2:
                    case 3:
                        _outputHandler.AppendMessage($"Highest severity: {_facade.HighestSeverity()}", MessageType.Success);
                        break;
                    case 4:
                    case 5:
                    case 6:
                    case 7:
                        _outputHandler.AppendMessage($"Highest severity: {_facade.HighestSeverity()}", MessageType.Default);
                        break;
                    case 8:
                    case 9:
                    case 10:
                        _outputHandler.AppendMessage($"Highest severity: {_facade.HighestSeverity()}", MessageType.Danger);
                        break;
                    default:
                        break;
                }

                if (chkPrintOnScreen.Checked)
                {
                    _outputHandler.AppendMessage(_facade.GetResultsJson(), MessageType.Default);
                }
            }
            else
            {
                _outputHandler.AppendMessage("Query execution failed.", MessageType.Danger);
            }

            foreach (var error in _facade.GetErrors())
            {
                _outputHandler.AppendMessage(error.errorMessage, MessageType.Danger);
                _outputHandler.AppendMessage(error.exceptionMessage, MessageType.Default);
            }
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV Files|*.csv";
            openFileDialog.Multiselect = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                foreach (string fileName in openFileDialog.FileNames)
                {
                    if (!lstSelectedFiles.Items.Contains(fileName))
                    {
                        lstSelectedFiles.Items.Add(fileName);
                    }
                    else
                    {
                        MessageBox.Show($"The file {Path.GetFileName(fileName)} is already added.", "Duplicate File", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void btnClearOutput_Click(object sender, EventArgs e)
        {
            txtResultsDisplay.Clear();
        }
    }
}