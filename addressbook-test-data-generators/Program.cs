using Newtonsoft.Json;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests;
using Excel = Microsoft.Office.Interop.Excel;


namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = args[0];
            if (type == "groups")
            {
                writerGroupsData(args);
            }
            else if (type == "records")
            {
                writerRecordsData(args);
            }
            else
            {
                System.Console.Out.Write("Unrecognized type" + type);
            }
        }

        private static void writerGroupsData(string[] args)
        {
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(100),
                    Footer = TestBase.GenerateRandomString(100)
                });
            }
            if (format == "excel")
            {
                writeGroupsToExcelFile(groups, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "csv")
                {
                    writeGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    writeGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    writeGroupsToJsonFile(groups, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }
        }

        private static void writerRecordsData(string[] args)
        {
            int count = Convert.ToInt32(args[1]);
            string filename = args[2];
            string format = args[3];
            List<RecordData> records = new List<RecordData>();
            for (int i = 0; i < count; i++)
            {
                records.Add(new RecordData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(10)));
            }
            if (format == "excel")
            {
                writeRecordToExcelFile(records, filename);
            }
            else
            {
                StreamWriter writer = new StreamWriter(filename);
                if (format == "xml")
                {
                    writeRecordToXMLFile(records, writer);
                }
                else if (format == "json")
                {
                    writeRecordToJSONFile(records, writer);
                }
                else
                {
                    System.Console.Out.Write("Unrecognized format" + format);
                }
                writer.Close();
            }
        }

        /// Records
        private static void writeRecordToExcelFile(List<RecordData> records, string filename)
        {
            return;
        }

        private static void writeRecordToJSONFile(List<RecordData> records, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(records, Newtonsoft.Json.Formatting.Indented));
        }

        private static void writeRecordToXMLFile(List<RecordData> records, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<RecordData>))
               .Serialize(writer, records);
        }

        
        // Groups
        private static void writeGroupsToExcelFile(List<GroupData> groups, string filename)
        {
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Add();
            Excel.Worksheet sheet =  wb.ActiveSheet;

            int row = 1;
            foreach(GroupData group in groups)
            {
                sheet.Cells[row, 1] = group.Name;
                sheet.Cells[row, 2] = group.Header;
                sheet.Cells[row, 3] = group.Footer;
                row++;
            }
            string fullpath = Path.Combine(Directory.GetCurrentDirectory(), filename);
            File.Delete(fullpath);
            wb.SaveAs(fullpath);

            wb.Close();
            app.Visible = false;
            app.Quit();
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name,
                    group.Header,
                    group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>))
                .Serialize(writer, groups);
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }
    }
}