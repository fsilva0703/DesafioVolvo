using DesafioVolvo.BLL.Interface;
using DesafioVolvo.DAO.Interface;
using DesafioVolvo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioVolvo.BLL.Service
{
    public class TruckService : ITruckService
    {
        private ITruckRepository _truckRepository;

        public TruckService(ITruckRepository paramTruckRepository)
        {
            _truckRepository = paramTruckRepository;
        }

        public List<TruckModel> LoadTruckModels()
        {
            return _truckRepository.LoadTruckModels();
        }

        public List<Truck> LoadTrucks()
        {
            return _truckRepository.LoadTrucks();
        }

        public Truck LoadTruckById(int paramTruckId)
        {
            return _truckRepository.LoadTruckById(paramTruckId);
        }

        public List<Truck> LoadTrucksByIdModel(int paramTruckModelId)
        {
            return _truckRepository.LoadTrucksByIdModel(paramTruckModelId);
        }

        public bool DeleteTruckById(int paramTruckId)
        {
            try
            {
                _truckRepository.DeleteTruckById(paramTruckId);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public ResultView Maintain(Truck TruckParameter)
        {
            ResultView result = new ResultView();

            try
            {
                result = IsValidManufactureYear(TruckParameter.ManufactureYear);
                if (!result.IsValid)
                    return result;
                result = IsValidModelYear(TruckParameter.ModelYear);
                if (!result.IsValid)
                    return result;
                result = IsValidModelsTruck(TruckParameter.TruckModelId);
                if (!result.IsValid)
                    return result;

                var truckData = new Truck()
                {
                    TruckModelId = TruckParameter.TruckModelId,
                    TruckName = TruckParameter.TruckName,
                    ManufactureYear = TruckParameter.ManufactureYear,
                    ModelYear = TruckParameter.ModelYear
                };

                if (TruckParameter.TruckId != 0)
                    _truckRepository.UpdateTruck(TruckParameter);
                else
                    _truckRepository.AddTruck(TruckParameter);

                result.IsValid = true;
            }
            catch (Exception ex)
            {
                result.IsValid = false;
                result.ErrorMessage = "Estamos com problemas técnicos: " + ex.Message;
                return result;
            }

            return result;
        }

        public ResultView IsValidManufactureYear(int paramManufactureYear)
        {
            var result = new ResultView()
            {
                IsValid = true
            };

            if (paramManufactureYear != DateTime.Now.Year)
            {
                result.IsValid = false;
                result.ErrorMessage = "O ano de fabricação deve ser o ano atual: " + DateTime.Now.Year;
                return result;
            }
            return result;
        }

        public ResultView IsValidModelYear(int paramModelYear)
        {
            var result = new ResultView()
            {
                IsValid = true
            };

            if (paramModelYear != DateTime.Now.Year && paramModelYear != DateTime.Now.AddYears(1).Year)
            {
                result.IsValid = false;
                result.ErrorMessage = "O ano modelo deve ser o ano atual ou o ano subsequente: " + DateTime.Now.Year + " ou " + DateTime.Now.AddYears(1).Year;
                return result;
            }
            return result;
        }

        public ResultView IsValidModelsTruck(int paramTruckModelId)
        {
            var result = new ResultView()
            {
                IsValid = true
            };

            List<TruckModel> listModelsTruck = _truckRepository.LoadTruckModels().Where(x => x.ModelName == "FH" || x.ModelName == "FM").ToList();
            var isModelOk = listModelsTruck.Where(x => x.TruckModelId == paramTruckModelId).SingleOrDefault();
            if (isModelOk is null)
            {
                result.IsValid = false;
                result.ErrorMessage = "O modelo do caminhão deve: FH ou FM";
                return result;
            }
            return result;
        }
    }
}