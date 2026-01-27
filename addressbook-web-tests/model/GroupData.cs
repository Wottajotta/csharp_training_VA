using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

        public GroupData()
        {
        }

        public GroupData(string name)
        {
            Name = name;
        }



        public GroupData(string name, string header, string footer)
        {
            Name = name;
            Header = header;
            Footer = footer;
        }
        private string Normalize(string s)
        {
            if (s == null) return null;
            s = s.Replace("\u00A0", " ");
            s = System.Text.RegularExpressions.Regex.Replace(s, @"\s+", " ");
            s = s.Trim();
            return s.Normalize(System.Text.NormalizationForm.FormC);
        }

        public bool Equals(GroupData other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            return Normalize(Name) == Normalize(other.Name);
        }


        public override int GetHashCode()
        {
            return Normalize(Name)?.GetHashCode() ?? 0;
        }




        public override string ToString()
        {
            return "name = " + Name + "\nheader = " + Header + "\nfooter = " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        [Column(Name = "group_name"), NotNull]
        public string Name { get; set; }

        [Column(Name = "group_header"), NotNull]
        public string Header { get; set; }

        [Column(Name = "group_footer"), NotNull]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }


        public static List<GroupData> GetAll()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from g in db.Groups select g).ToList();
            }
        }


        public List<RecordData> GetRecord()
        {
            using (AddressBookDB db = new AddressBookDB())
            {
                return (from r in db.Records
                        from gcr in db.GCR.Where(p => p.GroupId == Id && p.RecordId == r.Id && r.Deprecated == "0000-00-00 00:00:00")
                        select r).Distinct().ToList();

            }
        }
    }
}
