using NewManagingApp.Classes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NewManagingApp.Services
{
    internal static class LoadingExcelService
    {
        public static async Task<DataTable> GetDataTableFromExcel(string filePath)
        {
            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
            DataTable dataTable = new();
            await Task.Run(() =>
            {
                try
                {
                    using OleDbConnection oleDbConnection = new(connectionString);
                    try
                    {
                        oleDbConnection.Open();
                        //     MessageBox.Show("Connection Successful");

                        DataTable? dtSchema = oleDbConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                        string? Sheet1 = dtSchema.Rows[0].Field<string>("TABLE_NAME");

                        using OleDbDataAdapter objDA = new($"select * from [{Sheet1}]", connectionString);
                        try
                        {
                            objDA.Fill(dataTable);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }

            });
            return dataTable;

        }

        public static async Task<ObservableCollection<Indeks>> DataTableToListOfBaseIndeks(DataTable dataTable)
        {
            ObservableCollection<Indeks> list = new();

            await Task.Run(() =>
            {
                foreach (DataRow dataRow in dataTable.AsEnumerable())
                {
                    if (dataRow[1].ToString() != "" && dataRow[1].ToString() != null &&                        //        
                    dataRow[2].ToString() != "" && dataRow[2].ToString() != null &&                            //        
                    dataRow[3].ToString() != "" && dataRow[3].ToString() != null &&                            //        
                                                   dataRow[4].ToString() != null &&                            //        
                    dataRow[5].ToString() != "" && dataRow[5].ToString() != null &&                            //        
                    dataRow[6].ToString() != "" && dataRow[6].ToString() != null &&                            //        
                    dataRow[7].ToString() != "" && dataRow[7].ToString() != null &&                            //        
                    dataRow[7].ToString() != "" && dataRow[7].ToString() != null                               //
                    )
                    {

                        long PkuiwNumber = long.Parse(dataRow[0].ToString()!);
                        int IndeksId = int.Parse(dataRow[1].ToString()!);
                        string IndeksName = dataRow[2].ToString()!;
                        string? IndeksDescription = dataRow[3].ToString();
                        string IndeksUnitOfMeasure = dataRow[4].ToString()!;
                        int IndeksGroupOfMaterial = int.Parse(dataRow[5].ToString()!);
                        int IndeksClassOfMaterial = int.Parse(dataRow[6].ToString()!);
                        string IndeksTc = dataRow[7].ToString()!;
                        try
                        {
                            if (IndeksDescription != null)
                            {
                                list.Add(new(PkuiwNumber, IndeksId, IndeksName, IndeksDescription, IndeksUnitOfMeasure, IndeksGroupOfMaterial, IndeksClassOfMaterial, IndeksTc));
                            }
                            else
                            {
                                list.Add(new(PkuiwNumber, IndeksId, IndeksName, IndeksUnitOfMeasure, IndeksGroupOfMaterial, IndeksClassOfMaterial, IndeksTc));
                            }
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                }
            });

            return list;
        }
    }
}
