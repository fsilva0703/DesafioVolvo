using DesafioVolvo.DAO.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DesafioVolvo.DAL.Repository
{
    public class TruckRepository : ITruckRepository
    {
        private readonly DatabaseContext _context;

        public TruckRepository(DatabaseContext context)
        {
            _context = context;
        }

        public List<TruckModel> LoadTruckModels()
        {
            List<TruckModel> listModels = new List<TruckModel>();
            var result = _context.TruckModels.Select(x => new { x.TruckModelId, x.ModelName }).ToList();

            foreach (var x in result)
            {
                TruckModel item = new TruckModel
                {
                    ModelName = x.ModelName,
                    TruckModelId = x.TruckModelId
                };
                listModels.Add(item);
            }
            return listModels;
        }

        public List<Truck> LoadTrucks()
        {
            List<Truck> listTrucks = new List<Truck>();
            var result = from t in _context.Trucks
                         select new { t.TruckId, t.TruckName, t.ModelYear, t.ManufactureYear };

            foreach (var x in result)
            {
                Truck item = new Truck
                {
                    TruckName = x.TruckName,
                    TruckId = x.TruckId,
                    ManufactureYear = x.ManufactureYear,
                    ModelYear = x.ModelYear
                };
                listTrucks.Add(item);
            }
            return listTrucks;
        }

        public Truck LoadTruckById(int paramTruckId)
        {
            return _context.Trucks.First(a => a.TruckId == paramTruckId);
        }

        public List<Truck> LoadTrucksByIdModel(int paramTruckModelId)
        {
            List<Truck> listTrucks = new List<Truck>();
            var result = from t in _context.Trucks.Where(x => x.TruckModelId == paramTruckModelId)
                         select new { t.TruckId, t.TruckName, t.ModelYear, t.ManufactureYear };

            foreach (var x in result)
            {
                Truck item = new Truck
                {
                    TruckName = x.TruckName,
                    TruckId = x.TruckId,
                    ManufactureYear = x.ManufactureYear,
                    ModelYear = x.ModelYear
                };
                listTrucks.Add(item);
            }
            return listTrucks;
        }

        public void UpdateTruck(Truck TruckParameter)
        {
            var updateTruck = LoadTrucks().First(a => a.TruckId == TruckParameter.TruckId);
            updateTruck.TruckName = TruckParameter.TruckName;
            updateTruck.TruckModelId = TruckParameter.TruckModelId;
            updateTruck.ManufactureYear = TruckParameter.ManufactureYear;
            updateTruck.ModelYear = TruckParameter.ModelYear;

            _context.Entry(updateTruck).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void AddTruck(Truck TruckParameter)
        {
            _context.Trucks.Add(TruckParameter);
            _context.SaveChanges();
        }

        public void DeleteTruckById(int paramTruckId)
        {
            var result = _context.Trucks.First(a => a.TruckId == paramTruckId);
            _context.Trucks.Remove(result);
            _context.SaveChanges();
        }
    }
}