using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using ExcelDataReader;
using System.Data;

namespace CompetitionTasks
{

    public class ExcelOperations
    {
        
            static List<Datacollection> dataCol = new List<Datacollection>();
            public class Datacollection
            {
                public int rowNumber { get; set; }
                public string colName { get; set; }
                public string colValue { get; set; }
            }

            public static void ClearData()
            {
                dataCol.Clear();
            }

            //reads the data as excel and return the data as tables.
            public static DataTable ExcelToDataTable(FileStream stream, string sheetName)
            {

                System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
                //createopenxmlreader via ExcelReaderFactory
                //createopenxmlreader reads the .xlsx files
                IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);


                // set the first row as column name
                DataSet result = excelReader.AsDataSet(new ExcelDataSetConfiguration()
                {
                    ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                    {
                        UseHeaderRow = true
                    }
                });

                //get all the tables into a datacollection table
                DataTableCollection table = result.Tables;

                //store it is data table.
                DataTable resultTable = table[sheetName];

                //return
                return resultTable;
            }

            public static string ReadData(int rowNumber, string columnName)
            {
                try
                {
                    //Retriving Data using LINQ to reduce much of iterations

                    string data = (from colData in dataCol
                                   where colData.colName == columnName && colData.rowNumber == rowNumber
                                   select colData.colValue).SingleOrDefault();

                    // retrieving data through lambda
                    //var datas = dataCol.Where(x => x.colName == columnName && x.rowNumber == rowNumber).SingleOrDefault().colValue;


                    return data.ToString();
                }

                catch (Exception e)
                {
                    //Added by shanthi
                    Console.WriteLine("Exception occurred in ExcelLib Class ReadData Method!" + Environment.NewLine + e.Message.ToString());
                    return null;
                }
            }

            public static void ReadDataTable(FileStream stream, string sheetName)
            {
                // Console.WriteLine("Sheet:"+ sheetName);
                DataTable table = ExcelToDataTable(stream, sheetName);
                //totalRowCount =table.Rows.Count;
                //Iterate through the rows and columns of the Table
                for (int row = 0; row < table.Rows.Count; row++)
                {
                    Datacollection data;

                    //Console.WriteLine("Row Number is " + (row + 1));
                    for (int col = 0; col < table.Columns.Count; col++)
                    {
                        data = new Datacollection();
                        data.rowNumber = row + 1;
                        data.colName = table.Columns[col].ColumnName;
                        data.colValue = table.Rows[row][col].ToString();
                        //Console.WriteLine("Column:" + table.Columns[col].ColumnName +
                        //  " |Value:" + table.Rows[row][col].ToString());
                        dataCol.Add(data);
                    }
                }
            }
        }


    }

