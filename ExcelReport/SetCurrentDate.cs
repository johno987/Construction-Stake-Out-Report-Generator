namespace StakeOutReport_WinForms
{
    public partial class StakeOutReport
    {
        //method to add the current date to the label
        private void SetCurrentDate()
        {
            DateTime dateTime = DateTime.Now;
            CurrentDate.Text = dateTime.ToShortDateString();
        }
    }
}
