using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class RecordData
    {
        private string firstname;
        private string middlename = "";
        private string lastname;
        private string nickname = "";
        private string title = "";
        private string company = "";
        private string address;
        private string homePhone;
        private string email;
        private string burthdayData;
        private string birthMonthData;
        private string birthYearData;

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
            this.firstname = firstname;
            this.lastname = lastname;
            this.address = address;
            this.homePhone = homePhone;
            this.email = email;
            this.burthdayData = burthdayData;
            this.birthMonthData = birthMonthData;
            this.birthYearData = birthYearData;
        }

        public RecordData(
            string middlename,
            string nickname,
            string title,
            string company
            )
        {
            this.middlename = middlename;
            this.nickname = nickname;
            this.title = title;
            this.company = company;
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Middlename
        {
            get { return middlename; }
            set { middlename = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Nickname
        {
            get { return nickname; }
            set { nickname = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public string Company
        {
            get { return company; }
            set { company = value; }
        }

        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public string HomePhone
        {
            get { return homePhone; }
            set { homePhone = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string BurthdayData
        {
            get { return burthdayData; }
            set { burthdayData = value; }
        }

        public string BirthMonthData
        {
            get { return birthMonthData; }
            set { birthMonthData = value; }
        }

        public string BirthYearData
        {
            get { return birthYearData; }
            set { birthYearData = value; }
        }



    }
}
