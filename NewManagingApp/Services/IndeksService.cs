using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace NewManagingApp.Services
{
    internal static  class IndeksService
    {
        public async static void SaveListToExcelPlatform(this ObservableCollection<Indeks> list)
        {
            string path = PathService.GetPath();

            if (path != "")
            {
                bool IsSavingDone = await PlatformSavingModel(path, list);

                if (IsSavingDone)
                    MessageBox.Show($"Plik utworzony pod scieżką: {path}");
            }
            else
            {
                MessageBox.Show("Wybierz prawidlowa sciezke do pliku");
            }


        }
        private async static Task<bool> PlatformSavingModel(string path, ObservableCollection<Indeks> list)
        {
            bool test = false;
            await Task.Run(() =>
            {

                var xlApp = new Excel.Application();


                if (xlApp == null)
                {
                    MessageBox.Show("Zle zainstalowany excel??");
                    return test;
                }
                var xlWorkBook = xlApp.Workbooks.Add();


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

                foreach (Indeks i in list)
                {
                    xlWorkSheet.Cells[cellCount, 1] = i.IndeksName;
                    xlWorkSheet.Cells[cellCount, 2] = i.IndeksId;
                    xlWorkSheet.Cells[cellCount, 3] = 1;
                    xlWorkSheet.Cells[cellCount, 4] = "szt.";
                    xlWorkSheet.Cells[cellCount, 5] = i.IndeksDescription;
                    cellCount++;
                }

                try
                {
                    xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    xlWorkBook.Close(true);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                }

                test = true;
                return test;
            });
            return test;
        }

        public async static void SaveListToExcelAsPriceList(this ObservableCollection<Indeks> list)
        {
            string path = PathService.GetPath();

            if (path != "")
            {
                bool IsSavingDone = await PriceListSavingModel(path, list);

                if (IsSavingDone)
                    MessageBox.Show($"Plik utworzony pod scieżką: {path}");
            }
            else
            {
                MessageBox.Show("Wybierz prawidlowa sciezke do pliku");
            }
        }
        private async static Task<bool> PriceListSavingModel(string path, ObservableCollection<Indeks> list)
        {
            bool test = false;
            await Task.Run(() =>
            {

                var xlApp = new Excel.Application();


                if (xlApp == null)
                {
                    MessageBox.Show("Zle zainstalowany excel??");
                    return test;
                }
                var xlWorkBook = xlApp.Workbooks.Add();


                var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                xlWorkSheet.Cells[1, 1] = "Indeks";
                xlWorkSheet.Cells[1, 2] = "Nazwa";
                xlWorkSheet.Cells[1, 3] = "Opis";
                xlWorkSheet.Cells[1, 4] = "Cena";
                xlWorkSheet.Cells[1, 5] = "Waluta";
                xlWorkSheet.Cells[1, 6] = "UWAGI";


                int cellCount = 2;

                foreach (Indeks i in list)
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

                try
                {
                    xlWorkBook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    xlWorkBook.Close(true);
                    xlApp.Quit();
                    Marshal.ReleaseComObject(xlWorkSheet);
                    Marshal.ReleaseComObject(xlWorkBook);
                    Marshal.ReleaseComObject(xlApp);
                }
                test = true;
                return test;
            });
            return test;

        }

       
    }
}
