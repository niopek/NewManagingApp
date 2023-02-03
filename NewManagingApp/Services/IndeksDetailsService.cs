namespace NewManagingApp.Services;

internal static class IndeksDetailsService
{
    public static void SaveListToExcelPlatform(this ObservableCollection<IndeksDetails> list)
    {
        var xlApp = new Excel.Application();
        if (xlApp == null)
        {
            MessageBox.Show("Zle zainstalowany excel??");
            return;
        }
        object misValue = System.Reflection.Missing.Value;
        var xlWorkBook = xlApp.Workbooks.Add(misValue);


        var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        xlWorkSheet.Cells[1, 1] = "Nazwa Produktu";
        xlWorkSheet.Cells[1, 2] = "Indeks Produktu";
        xlWorkSheet.Cells[1, 3] = "Ilość";
        xlWorkSheet.Cells[1, 4] = "Jednostka";
        xlWorkSheet.Cells[1, 5] = "Uwagi do produktu";
        xlWorkSheet.Cells[1, 6] = "Termin realizacji";
        xlWorkSheet.Cells[1, 7] = "Miejsce dostawy";
        xlWorkSheet.Cells[1, 8] = "Cena szacunkowa";
        xlWorkSheet.Cells[1, 9] = "Numer zapotrzebowania";
        xlWorkSheet.Cells[1, 10] = "Producent";
        xlWorkSheet.Cells[1, 11] = "Indeks producenta";


        int cellCount = 2;

        foreach (IndeksDetails i in list)
        {
            xlWorkSheet.Cells[cellCount, 1] = i.IndeksName;
            xlWorkSheet.Cells[cellCount, 2] = i.IndeksId;
            xlWorkSheet.Cells[cellCount, 3] = i.TotalAmount;
            xlWorkSheet.Cells[cellCount, 4] = "szt.";
            xlWorkSheet.Cells[cellCount, 5] = i.IndeksDescription;
            cellCount++;
        }


        string path = "";

        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Excel File|*.xls";
        saveFileDialog.Title = "Save an Excel File";
        if (saveFileDialog.ShowDialog() == true)
        {
            path = saveFileDialog.FileName;
        }

        xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        xlWorkBook.Close(true, misValue, misValue);
        xlApp.Quit();

        Marshal.ReleaseComObject(xlWorkSheet);
        Marshal.ReleaseComObject(xlWorkBook);
        Marshal.ReleaseComObject(xlApp);

        MessageBox.Show($"Plik utworzony pod scieżką: {path}");
    }

    public static void SaveListToExcelAsPriceList(this ObservableCollection<IndeksDetails> list)
    {
        var xlApp = new Excel.Application();
        if (xlApp == null)
        {
            MessageBox.Show("Zle zainstalowany excel??");
            return;
        }
        object misValue = System.Reflection.Missing.Value;
        var xlWorkBook = xlApp.Workbooks.Add(misValue);


        var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
        xlWorkSheet.Cells[1, 1] = "Indeks";
        xlWorkSheet.Cells[1, 2] = "Nazwa";
        xlWorkSheet.Cells[1, 3] = "Opis";
        xlWorkSheet.Cells[1, 4] = "Cena";
        xlWorkSheet.Cells[1, 5] = "Waluta";
        xlWorkSheet.Cells[1, 6] = "UWAGI";


        int cellCount = 2;

        foreach (IndeksDetails i in list)
        {
            xlWorkSheet.Cells[cellCount, 1] = i.IndeksId;
            xlWorkSheet.Cells[cellCount, 2] = i.IndeksName;
            xlWorkSheet.Cells[cellCount, 3] = i.IndeksDescription;
            cellCount++;
        }


        // border full table
        string range = "f" + cellCount;
        Excel.Range formatRange = xlWorkSheet.UsedRange;
        formatRange = xlWorkSheet.get_Range("a1", range);
        Excel.Borders border = formatRange.Borders;
        border.LineStyle = Excel.XlLineStyle.xlContinuous;
        border.Weight = 2d;
        //color titles
        formatRange = xlWorkSheet.get_Range("a1", "f1");
        formatRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightSteelBlue);
        formatRange = xlWorkSheet.get_Range("b1", "c1");
        formatRange.ColumnWidth = 45;


        string path = "";

        SaveFileDialog saveFileDialog = new SaveFileDialog();
        saveFileDialog.Filter = "Excel File|*.xls";
        saveFileDialog.Title = "Save an Excel File";
        if (saveFileDialog.ShowDialog() == true)
        {
            path = saveFileDialog.FileName;
        }

        xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
        xlWorkBook.Close(true, misValue, misValue);
        xlApp.Quit();

        Marshal.ReleaseComObject(xlWorkSheet);
        Marshal.ReleaseComObject(xlWorkBook);
        Marshal.ReleaseComObject(xlApp);

        MessageBox.Show($"Plik utworzony pod scieżką: {path}");
    }
}
