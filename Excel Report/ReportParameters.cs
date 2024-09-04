using QuestPDF.Infrastructure;
using QuestPDF.Fluent;

namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport
    {
        //CLASS FOR STORING REPORT PROPERTIES SUCH AS TITLE AND ELEMENT OF WORKS
        private void GenerateReportButton_Click(object sender, EventArgs e)
        {
            //UP TO THE BUTTON CLICK FOR THE REPORT
            if (!PDFCheckBox.Checked && !CSVCheckBox.Checked)
            {
                MessageUser.EmptyReportSelection();
                return;
            }
            if (PDFCheckBox.Checked)
            {
                var PDFReport = new PDFGenerator(this);
                var document = Document.Create(Container =>
                {
                    PDFReport.Compose(Container);
                });

                

                //PDFReport.Compose();
            }
            if (CSVCheckBox.Checked)
            {
                GenerateExcelReport();
            }
        }

        private void ProjectNameTextBox_TextChanged(object sender, EventArgs e)
        {
            ProjectTitle = ProjectNameTextBox.Text;
        }

        private void ElementOfWorksTextBox_TextChanged(object sender, EventArgs e)
        {
            ElementOfWorks = ElementOfWorksTextBox.Text;
        }
    }
}