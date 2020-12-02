using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPI.Model
{
    public class DatabaseActions
    {
        Adult ad1 = new Adult();
        Adult ad2 = new Adult();
        Adult ad3 = new Adult();
        public void setValue()
        {
            ad1.Id = 1;
            ad1.FirstName = "AD!";
            ad1.LastName = "LN!";
            ad1.Sex = "male";
            ad1.Height = 180;
            ad1.Weight = 100;
            ad1.HairColour = "black";
            ad1.EyeColour = "Brown";
            ad1.Job = "Student";
            ad2.Id = 2;
            ad2.FirstName = "AD@";
            ad2.LastName = "L@";
            ad2.Sex = "Female";
            ad2.Height = 160;
            ad2.Weight = 90;
            ad2.HairColour = "yellow";
            ad2.EyeColour = "red";
            ad2.Job = "chef";
            ad3.Id = 3;
            ad3.FirstName = "AD#";
            ad3.LastName = "LN#";
            ad3.Sex = "Null";
            ad3.Height = 200;
            ad3.Weight = 20;
            ad3.HairColour = "green";
            ad3.EyeColour = "blue";
            ad3.Job = "police";
        }
        public async Task InsertInit()
        {
            using (AdultContext dbContext = new AdultContext())
            {
                 await dbContext.Adults.AddAsync(ad1);
                await dbContext.SaveChangesAsync();
                Console.WriteLine(1+"/"+dbContext.Adults.FindAsync(ad1.Id));
                 await dbContext.Adults.AddAsync(ad2);
                await dbContext.SaveChangesAsync();
                Console.WriteLine(2);
                await dbContext.Adults.AddAsync(ad3);
                await dbContext.SaveChangesAsync();
                Console.WriteLine(3);
                Console.WriteLine(dbContext.Adults.FindAsync(ad1.Id)+">>>>>>>>>");
            }
        
        }
        public async Task InsertAdult(Adult adult)
        {
            using (AdultContext dbContext = new AdultContext())
            {
                await dbContext.Adults.AddAsync(adult);
                await dbContext.SaveChangesAsync();
            }
        }
        public async void DeleteAdult(Adult adult)
        {
            using (AdultContext dbContext = new AdultContext())
            {
                dbContext.Adults.Remove(adult);
                await dbContext.SaveChangesAsync();
            }
        }
        public Adult GetAdultById(int id)
        {
            using (AdultContext dbContext = new AdultContext())
            {
               Adult adult1 =  dbContext.Adults.Find(id);
               return adult1;
            }
        }
        public void UpdateDatabase(Adult adult)
        {
            using (AdultContext dbContext = new AdultContext())
            {
                dbContext.Adults.Update(adult);
                dbContext.SaveChanges();
            }
        }
        public int getsize()
        {
            int i = 0;
            using (AdultContext dbContext = new AdultContext())
            {
                //Console.WriteLine("<<>>");
                i = dbContext.Adults.Count<Adult>();
                //Console.WriteLine(dbContext.Adults.Find(1)+"????");
                Console.WriteLine("Size Of Loop: "+i);
            }
            return i;
        }
        
    }
}
