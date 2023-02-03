namespace NewManagingApp.Util
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
