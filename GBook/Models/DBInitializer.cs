using System.Collections.Generic;
using System.Data.Entity;

namespace GBook.Models
{
    public class DBInitializer : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext db)
        {
            List<Record> records = new List<Record>();

            for (int i = 1; i <= 50; i++)
            {
                
                records.Add(new Record
                {
                    RecordId = i,
                    UserName = "User " + i.ToString(),
                    EMail = "user" + i.ToString() + "@mail.com",
                    Homepage = @"http://user" + i.ToString() + ".com",
                    Text = "Hello! This is test text.",
                    IP = "192.168.0." + i.ToString(),
                    Browser = "IE10",
                    Created = System.DateTime.Now
                });
            }
            records.ForEach(x => db.Records.Add(x));
            db.SaveChanges();
        }
    }
}