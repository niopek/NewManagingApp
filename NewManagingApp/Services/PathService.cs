using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewManagingApp.Services
{
    internal static class PathService
    {
        public static string GetPath()
        {
            string path = "";
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel File|*.xls";
            saveFileDialog.Title = "Save an Excel File";
            if (saveFileDialog.ShowDialog() == true)
            {
                path = saveFileDialog.FileName;
            }
            return path;
        }
    }
}
