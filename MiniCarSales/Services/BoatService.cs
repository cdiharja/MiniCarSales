using Microsoft.EntityFrameworkCore;
using MiniCarSales.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniCarSales.Services
{
    public class BoatService:IRepositoryService<Boat>
    {

        private readonly MyContext myContext;
        public BoatService(MyContext myContext)
        {  
            this.myContext = myContext;
        }

        public IEnumerable<Boat> GetAll()
        {
            return myContext.Boats.ToList<Boat>();
        }

        public Boat Create(Boat boat)
        {   
            myContext.Boats.Add(boat);
            myContext.SaveChanges();
            return boat;
        }
    }
}
