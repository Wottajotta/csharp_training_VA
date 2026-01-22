using System;
using System.Text;
using System.Text.RegularExpressions;

namespace WebAddressbookTests
{
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



        public string Name { get; set; }

        public override string ToString()
        {
            return "name = " + Name + "\nheader = " + Header + "\nfooter = " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if(Object.ReferenceEquals(other,null)) 
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public string Header { get; set; }


        public string Footer { get; set; }

        public string Id { get; set; }

    }
}
