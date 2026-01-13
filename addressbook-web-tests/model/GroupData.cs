using System;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {

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

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return "name = " + Name;
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
