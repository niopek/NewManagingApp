using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewManagingApp
{
    internal class FileNameToString
    {
        public static async Task<string> GetString()
        {
            string fileName = "";
            await Task.Run(() =>
            {
                OpenFileDialog openFileDialog = new()
                {
                    InitialDirectory = @"C:\Users\admin\Desktop\Nowy folder"
                };
                if (openFileDialog.ShowDialog() == true)
                    fileName = openFileDialog.FileName;
            });
            return fileName;
        }
    }
}
