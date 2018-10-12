using Lab1A.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab1A.Data
{
    public class DealershipMgr
    {

        public static List<Dealership> dealership = new List<Dealership>
       {
             new Dealership
              {
                ID = 4,
                Name = "Sam",
                Email = "sam.sth@yahoo.com",
                PhoneNumber = "289-555-5555"
             },
             new Dealership
             {
                ID = 5,
                Name = "Jack",
                Email = "Jack.sth@yahoo.com"
              },
             new Dealership
             {
                ID = 3,
                Name = "Sara",
                Email = "Sara.sth@yahoo.com",
                PhoneNumber = "289-445-5555"
              }


    };

        public void Post(object p1, object p2, object p3, object p4)
        {
            throw new NotImplementedException();
        }

        public object Dealership { get; internal set; }

        public IEnumerable<Dealership> Get()
        {

            return dealership.AsEnumerable();

        }

        public void Post(Dealership info)
        {

            dealership.Append(info);

        }

        public void Put(Dealership info, int ID)
        {
            int userIndex = dealership.FindIndex(Dealership => Dealership.ID == ID);

            dealership.RemoveAt(userIndex);
            dealership.Add(info);



        }



        public Dealership GetOneDealer(int ID)
        {


            int userIndex = dealership.FindIndex(Dealership => Dealership.ID == ID);

            if (userIndex > 0)
            {

                return dealership.ElementAt(userIndex);
            }
            else
            {

                return dealership.ElementAt(0);
            }

        }



        public String DeleteOneDealer(int ID)
        {
            int userIndex = dealership.FindIndex(Dealership => Dealership.ID == ID);
            if (userIndex >= 0)
            {
                dealership.RemoveAt(userIndex);
                return ("Item has been deleted");
            }
            else
            {


                return ("dealership doesn't exists");
            }

        }
        public bool DealershipExists(int id)
        {


            int userIndex = dealership.FindIndex(Dealership => Dealership.ID == id);
            if (userIndex > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
