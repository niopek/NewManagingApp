namespace NewManagingApp.Services;

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
                                               dataRow[3].ToString() != null &&                            //        
                dataRow[4].ToString() != "" && dataRow[4].ToString() != null &&                            //        
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

    public static async Task<ObservableCollection<Order>> DataTableToListOfOrders(DataTable dataTable)
    {
        ObservableCollection<Order> list = new();

        await Task.Run(() =>
        {
            foreach (DataRow dataRow in dataTable.AsEnumerable())
            {

                //MessageBox.Show(priceNoDots);
                if (dataRow[1].ToString() != "" && dataRow[1].ToString() != null &&                                 // row[3].ToString()!),               orderId
                dataRow[2].ToString() != "" && dataRow[2].ToString() != null &&                                  // int.Parse(row[0].ToString()!),     productId
                                               dataRow[3].ToString() != null &&                                     // row[1].ToString()!,                productName
                dataRow[4].ToString() != "" && dataRow[4].ToString() != null &&                                     // row[2].ToString()!,                productDescription
                dataRow[5].ToString() != "" && dataRow[5].ToString() != null &&                                     // int.Parse(row[4].ToString()!),     supplierId
                dataRow[6].ToString() != "" && dataRow[6].ToString() != null &&                                     // row[5].ToString()!,                supplierName
                dataRow[7].ToString() != "" && dataRow[7].ToString() != null &&                                     // int.Parse(row[6].ToString()!),     amount
                dataRow[8].ToString() != "" && dataRow[8].ToString() != null &&                                     // row[7].ToString()!,                unitOfMeasure
                dataRow[9].ToString() != "" && dataRow[9].ToString() != null &&                                     // decimal.Parse(row[8].ToString()!), price
                dataRow[10].ToString() != "" && dataRow[10].ToString() != null &&                                   // row[9].ToString()!,                currency
                dataRow[11].ToString() != "" && dataRow[11].ToString() != null &&                                   // row[10].ToString()!,               date
                dataRow[12].ToString() != "" && dataRow[12].ToString() != null &&                                   // int.Parse(row[11].ToString()!),    plant
                dataRow[13].ToString() != "" && dataRow[13].ToString() != null &&                                   // long.Parse(row[12].ToString()!),   pkuiw
                dataRow[14].ToString() != "" && dataRow[14].ToString() != null                                      // int.Parse(row[13].ToString()!),    materialMoveNumber
                )                                                                                                   // row[14].ToString()!));             materialCategory   
                {

                    
                    long orderId = long.Parse(dataRow[0].ToString()!);
                    int productId = int.Parse(dataRow[1].ToString()!);
                    string productName = dataRow[2].ToString()!;
                    string productDescription = dataRow[3].ToString()!;
                    int supplierId = int.Parse(dataRow[4].ToString()!);
                    string supplierName = dataRow[5].ToString()!;
                    string amountString = Utils.ClearDotsFromPrice(dataRow[6].ToString()!);
                    string unitOfMeasure = dataRow[7].ToString()!;
                    string priceString = Utils.ClearDotsFromPrice(dataRow[8].ToString()!);
                    string currency = dataRow[9].ToString()!;
                    string date = Utils.ClearHoursFromDate(dataRow[10].ToString()!);
                    Plant plant = new(int.Parse(dataRow[11].ToString()!));
                    long pkuiw = long.Parse(dataRow[12].ToString()!);
                    int materialMoveNumber = int.Parse(dataRow[13].ToString()!);
                    string materialCategory = dataRow[14].ToString()!;
                    
                    decimal price = decimal.Parse(priceString);
                    decimal amount = decimal.Parse(amountString);


                    try
                    {
                        list.Add(new(orderId, productId, productName, productDescription, supplierId, supplierName, amount, unitOfMeasure, price, currency, date, plant, pkuiw, materialMoveNumber, materialCategory));
                    }
                    catch (Exception ex) { MessageBox.Show(ex.Message); }

                }
            }
        });

        return list;
    }


}
