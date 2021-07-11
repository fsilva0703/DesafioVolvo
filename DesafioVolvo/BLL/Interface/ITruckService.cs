using DesafioVolvo.Models;
using System.Collections.Generic;

namespace DesafioVolvo.BLL.Interface
{
    public interface ITruckService
    {
        List<TruckModel> LoadTruckModels();

        List<Truck> LoadTrucks();

        Truck LoadTruckById(int paramTruckId);

        List<Truck> LoadTrucksByIdModel(int TruckModelId);

        ResultView Maintain(Truck TruckParameter);

        bool DeleteTruckById(int paramTruckId);

        ResultView IsValidManufactureYear(int paramManufactureYear);

        ResultView IsValidModelYear(int paramModelYear);

        ResultView IsValidModelsTruck(int paramTruckModelId);
    }
}