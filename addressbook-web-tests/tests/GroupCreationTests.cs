using Microsoft.Office.Interop.Excel;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using WebAddressbookTests.tests;
using Excel = Microsoft.Office.Interop.Excel;


namespace WebAddressbookTests
{
    [TestFixture]
    public class CreateGroupsTest : AuthTestBase
    {

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i <5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                {
                    Header = GenerateRandomString(100),
                    Footer = GenerateRandomString(100)
                });
            }
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");
            foreach(string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }
            return groups;
        }


        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                .Deserialize(new StreamReader(@"group.xml"));
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
           return(JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"group.json")));
        }

        public static IEnumerable<GroupData> GroupDataFromExcelFile()
        {
            List<GroupData> groups = new List<GroupData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"group.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;

            for (int i = 1; i<= range.Rows.Count; i++)
            {
                groups.Add(new GroupData()
                {
                    Name = range.Cells[i, 1].Value,
                    Header = range.Cells[i, 2].Value,
                    Footer = range.Cells[i, 3].Value

                });
            }
            wb.Close();
            app.Visible=false;
            app.Quit();
            return groups;
        }


        [Test, TestCaseSource("GroupDataFromExcelFile")]
        public void CreateGroupTest(GroupData group)
        {

            List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups.Create(group);

            Assert.That(oldGroups.Count+1, Is.EqualTo(app.Groups.GetGroupCount()));

            List<GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.That(newGroups, Is.EqualTo(oldGroups));
        }
    }
}
