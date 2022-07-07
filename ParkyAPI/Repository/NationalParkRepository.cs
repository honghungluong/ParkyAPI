using ParkyAPI.Data;
using ParkyAPI.Interface;
using ParkyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkyAPI.Repository
{
    public class NationalParkRepository : INationalParkRepository
    {
        public NationalParkRepository(DataContext dataContext)
        {
            _DataContext = dataContext;
        }

        public DataContext _DataContext;

        public bool CreateNationalPark(NationalPark nationalPark)
        {
            _DataContext.NationalParks.Add(nationalPark);
            return Save();
        }

        public bool DeleteNationalPark(NationalPark nationalPark)
        {
            _DataContext.NationalParks.Remove(nationalPark);
            return Save();
        }

        public NationalPark GetNationalPark(int nationalParkId)
        {
            return _DataContext.NationalParks.FirstOrDefault(nP => nP.Id == nationalParkId);
        }

        public ICollection<NationalPark> GetNationalParks()
        {
            return _DataContext.NationalParks.OrderBy(nP => nP.Name).ToList();
        }

        public bool NationalParkExists(string name)
        {
            return _DataContext.NationalParks.Any(nP => nP.Name.ToLower().Trim() == name.ToLower().Trim());
        }

        public bool NationalParkExists(int id)
        {
            return _DataContext.NationalParks.Any(nP => nP.Id == id);
        }

        public bool Save()
        {
            return _DataContext.SaveChanges() > 0 ? true : false ;
        }

        public bool UpdateNationalPark(NationalPark nationalPark)
        {
            _DataContext.NationalParks.Update(nationalPark);
            return Save();
        }
    }
}

