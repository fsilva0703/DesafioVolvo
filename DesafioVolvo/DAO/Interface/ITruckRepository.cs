using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioVolvo.DAO.Interface
{
    public interface ITruckRepository
    {
        List<TruckModel> LoadTruckModels();

        List<Truck> LoadTrucks();

        Truck LoadTruckById(int paramTruckId);

        List<Truck> LoadTrucksByIdModel(int paramTruckModelId);

        void UpdateTruck(Truck TruckParameter);

        void AddTruck(Truck TruckParameter);

        void DeleteTruckById(int paramTruckId);
    }
}