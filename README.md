# 📊 Stakeout Report Generator

**Stakeout Report Generator** is a C# WinForms application designed for civil Site Engineers and Land Surveyors to streamline the process of generating reports for stakeout points on construction sites. The app allows users to upload design data from the construction design team and generate detailed reports on the accuracy of staked points in the field, highlighting any deviations that exceed predefined positional tolerances.

## 🛠 Features

- **Upload Design Data:** Easily import design data from the construction team to compare with staked points.
- **Stakeout Accuracy Reporting:** Automatically calculate the accuracy of staked points and generate a detailed report.
- **Positional Tolerance Analysis:** Identify any points that have exceeded positional tolerances and highlight them in the report.
- **As-Built Data Sanitisation:** Any control points or station set ups within the As-Built data will be automatically erased from the input, leading to clean and concise reports.
- **User-Friendly Interface:** Simple and intuitive WinForms-based UI for ease of use by field engineers.

## 🚀 How It Works

1. **Upload Design Data:** The user uploads the design data file provided by the construction design team as a CSV file. File should be ordered; Point ID, Easting, Northing, Elevation, with no headers.
2. **Upload As-Built Data:** The user uploads the staked As-Built data from the field controller and specifies the prefix that has been prepended to the staked points. In Leica controllers, this is often "STKE".
3. **Point Comparison:** The application compares the design points with the staked points collected by the Site Engineer or Land Surveyor.
4. **Generate Report:** The app generates a comprehensive report detailing the accuracy of each staked point and highlights any points that exceed the positional tolerance limits in Excel, PDF or both!.

## 🎯 Use Case

The **Stakeout Report Generator** is ideal for:
- **Site Engineers and Land Surveryors** needing to verify the accuracy of staked points on construction sites.
- **Construction teams** requiring accurate reports on how closely the site work matches the design specifications.
- **Civil engineers** overseeing large-scale projects who need quick, reliable reporting on field accuracy.

## 💻 Technologies Used

- **C#**
- **WinForms**
- **.NET Framework**

## 📦 Installation & Usage

**Release**
1. Download the ZIP containing the exe from the release section
2. Unpack the ZIP file to your chosen destination, ensuring the contents of the file are maintained
3. Run the Exe within and get straight to work

**Building the project yourself**

1. Clone this repository:
    ```bash
    git clone https://github.com/yourusername/Construction-Stake-Out-Report-Generator.git
    ```

2. Open the project in **Visual Studio**.

3. Build the solution and run the application.

4. Use the interface to upload your design data and generate reports!

## 🤝 Contributing

Feel free to fork this repository and submit pull requests to help improve this project.

## Screenshots

## Main Interface
![Main UI](Screenshots/Main%20UI.png)

## Data Loaded
![Data Loaded](Screenshots/Data%20Loaded.png)

## Excel Report
![Excel Report](Screenshots/Excel%20Report.png)

## PDF Report
![PDF Report](Screenshots/PDF%20Report.png)

## 📝 License

This project is licensed under the **MIT License**.
