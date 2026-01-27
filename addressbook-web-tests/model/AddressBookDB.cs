using LinqToDB;
using LinqToDB.Data;
using WebAddressbookTests;

namespace WebAddressbookTests
{
    public class AddressBookDB : DataConnection
    {
        public AddressBookDB() : base("AddressBook") { }

        public ITable<GroupData> Groups => this.GetTable<GroupData>();
        public ITable<RecordData> Records => this.GetTable<RecordData>();
        public ITable<GroupContactRelation> GCR => this.GetTable<GroupContactRelation>();
    }
}
