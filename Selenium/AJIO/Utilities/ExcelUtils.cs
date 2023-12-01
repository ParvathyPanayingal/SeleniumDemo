using ExcelDataReader;
using System.Data;
using System.Text;

namespace AJIO.Utilities
{
    internal class ExcelUtils
    {

        public static List<ExcelData> ReadExcelData(string excelFilePath, string sheetName)
        {
            List<ExcelData> excelDataList = new List<ExcelData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            ExcelData excelData = new ExcelData
                            {
                                SearchText = GetValueOrDefault(row, "searchtext")
                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        public static List<CustomerCareExcelData> ReadCustomerCareExcelData(string excelFilePath, string sheetName)
        {
            List<CustomerCareExcelData> excelDataList = new List<CustomerCareExcelData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            CustomerCareExcelData customerExcelData = new CustomerCareExcelData
                            {
                                SearchQuery = GetValueOrDefault(row, "searchQuery")
                            };

                            excelDataList.Add(customerExcelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }








        public static List<RegistrationExcelData> ReadRegistrationExcelData(string excelFilePath, string sheetName)
        {
            List<RegistrationExcelData> excelDataList = new List<RegistrationExcelData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            RegistrationExcelData excelData = new RegistrationExcelData
                            {
                                UserId = GetValueOrDefault(row, "userId"),
                                Email = GetValueOrDefault(row, "email"),
                                Password = GetValueOrDefault(row, "password"),
                                ConPassword = GetValueOrDefault(row, "conPassword"),
                                FirstName = GetValueOrDefault(row, "firstName"),
                                LastName = GetValueOrDefault(row, "lastName"),
                                Date = GetValueOrDefault(row,"date"),
                                City = GetValueOrDefault(row, "city"),
                                MobileNo = GetValueOrDefault(row, "mobileNo"),
                                PassingDate = GetValueOrDefault(row, "passingDate"),
                                FilePath = GetValueOrDefault(row, "filePath"),
                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        public static List<SignUpExcelData> ReadSignUpExcelData(string excelFilePath, string sheetName)
        {
            List<SignUpExcelData> excelDataList = new List<SignUpExcelData>();
            Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = new FileStream(excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true,
                        }
                    });

                    var dataTable = result.Tables[sheetName];

                    if (dataTable != null)
                    {
                        foreach (DataRow row in dataTable.Rows)
                        {
                            SignUpExcelData excelData = new SignUpExcelData
                            {
                                MobileNumber = GetValueOrDefault(row, "mobileNumber"),
                                Name = GetValueOrDefault(row, "name"),
                                Email = GetValueOrDefault(row, "email")


                            };

                            excelDataList.Add(excelData);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Sheet '{sheetName}' not found in the Excel file.");
                    }
                }
            }

            return excelDataList;
        }

        static string GetValueOrDefault(DataRow row, string columnName)
        {
            //            Console.WriteLine(row + "  " + columnName);
            return row.Table.Columns.Contains(columnName) ? row[columnName]?.ToString() : null;
        }



    }
}