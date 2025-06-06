using OfficeOpenXml;

public class ReadExcel
{
    [Test]
    public void OpenExcel()
    {
        // Set EPPlus license context
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        // Excel file path
        string filePath = @"C:\Users\Saich\OneDrive\Documents\AmazonLoginDetails.xlsx";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("Excel file not found.");
            return;
        }

        // Load and read Excel file
        using (var package = new ExcelPackage(new FileInfo(filePath)))
        {
            var sheet = package.Workbook.Worksheets[0];
            int rows = sheet.Dimension.Rows;

            for (int row = 2; row <= rows; row++) // skip header row
            {
                string val1 = sheet.Cells[row, 1].Text;
                string val2 = sheet.Cells[row, 2].Text;
                string val3 = sheet.Cells[row, 3].Text;
                string val4 = sheet.Cells[row, 4].Text;

                Console.WriteLine($"{val1} | {val2} | {val3} | {val4}");
            }
        }
    }
}
