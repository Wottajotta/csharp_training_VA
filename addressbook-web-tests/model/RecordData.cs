using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class RecordData : IEquatable<RecordData>, IComparable<RecordData>
    {

        private string allPhones;
        private string allEmails;

        public RecordData() {}

        public RecordData(string firstname, string lastname)
        {
            Firstname = firstname;
            Lastname = lastname;
        }

        public RecordData(
            string firstname,
            string lastname,
            string address,
            string homePhone,
            string email,
            string burthdayData,
            string birthMonthData,
            string birthYearData
            )
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            HomePhone = homePhone;
            Email = email;
            BurthdayData = burthdayData;
            BirthMonthData = birthMonthData;
            BirthYearData = birthYearData;
        }

        public RecordData(
            string firstname,
            string lastname,
            string address,
            string homePhone,
            string email
            )
        {
            Firstname = firstname;
            Lastname = lastname;
            Address = address;
            HomePhone = homePhone;
            Email = email;
        }

        public RecordData(
            string middlename,
            string nickname,
            string title,
            string company
            )
        {
            Middlename = middlename;
            Nickname = nickname;
            Title = title;
            Company = company;
        }


        public bool Equals(RecordData other)
        {
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;

            string Normalize(string s) => s?.Normalize(NormalizationForm.FormC);

            return Normalize(Firstname) == Normalize(other.Firstname)
                && Normalize(Lastname) == Normalize(other.Lastname);
        }

        public override int GetHashCode()
        {
            string Normalize(string s) => s?.Normalize(NormalizationForm.FormC);
            return (Normalize(Firstname)?.GetHashCode() ?? 0) ^ (Normalize(Lastname)?.GetHashCode() ?? 0);
        }


        public override string ToString()
        {
            return "Firstname = " + Firstname + " LastName = " + Lastname;
        }

        public int CompareTo(RecordData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            int cmp = string.Compare(Lastname, other.Lastname, StringComparison.OrdinalIgnoreCase);
            if (cmp != 0)
            {
                return cmp;
            }
            return string.Compare(Firstname, other.Firstname, StringComparison.OrdinalIgnoreCase);
        }

        public string Firstname { get; set; }


        public string Middlename { get; set; }


        public string Lastname { get; set; }


        public string Nickname { get; set; }


        public string Title { get; set; }


        public string Company { get; set; }


        public string Address { get; set; }


        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllPhones {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                string[] phones = new[] { HomePhone, MobilePhone, WorkPhone };
                allPhones = string.Join("\r\n", phones.Select(Cleanup).Where(p => !string.IsNullOrEmpty(p)));
                return allPhones;
            }
                 
            set
            {
                allPhones = value;
            }
                 
        }

        public string Email { get; set; }

        public string AllEmails { get; set; }

        public string BurthdayData { get; set; }


        public string BirthMonthData { get; set; }


        public string BirthYearData { get; set; }


        private string Cleanup(string phone)
        {
            if (string.IsNullOrEmpty(phone))
                return "";

            char[] charsToRemove = new char[]
            {
        '(', ')', ' ', '-', '–', '—', '‒', '−', '‐', '‑'
            };

            foreach (var c in charsToRemove)
            {
                phone = phone.Replace(c.ToString(), "");
            }

            return phone;
        }


    }
}
