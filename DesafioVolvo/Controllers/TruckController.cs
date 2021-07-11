using DesafioVolvo.BLL.Interface;
using DesafioVolvo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesafioVolvo.Controllers
{
    public class TruckController : Controller
    {
        private ITruckService _truckService;

        public TruckController(ITruckService truckService)
        {
            _truckService = truckService;
        }

        public IActionResult Truck()
        {
            return View();
        }

        public IActionResult ListTrucks()
        {
            return View();
        }

        public IActionResult LoadTruckModels()
        {
            var result = _truckService.LoadTruckModels();

            return Json(result);
        }

        [HttpPost]
        public IActionResult RequestData()
        {
            var requestFormData = Request.Form;

            int idModel = string.IsNullOrEmpty(Request.Cookies["idModel"]) ? 0 : Convert.ToInt32(Request.Cookies["idModel"]);
            List<Truck> listaTrucks = _truckService.LoadTrucksByIdModel(idModel).ToList();

            var listaItensForm = ProcessarDadosForm(listaTrucks, requestFormData);

            dynamic response = new
            {
                Data = listaItensForm,
                Draw = requestFormData["draw"],
                RecordsFiltered = listaTrucks.Count,
                RecordsTotal = listaTrucks.Count
            };
            return Ok(response);
        }

        private List<Truck> ProcessarDadosForm(List<Truck> lstElements, IFormCollection requestFormData)
        {
            var skip = Convert.ToInt32(requestFormData["start"].ToString());
            var pageSize = Convert.ToInt32(requestFormData["length"].ToString());
            var searchValue = requestFormData["search[value]"].FirstOrDefault();
            Microsoft.Extensions.Primitives.StringValues tempOrder = new[] { "" };

            if (requestFormData.TryGetValue("order[0][column]", out tempOrder))
            {
                var columnIndex = requestFormData["order[0][column]"].ToString();
                var sortDirection = requestFormData["order[0][dir]"].ToString();
                tempOrder = new[] { "" };
                if (requestFormData.TryGetValue($"columns[{columnIndex}][data]", out tempOrder))
                {
                    var columName = requestFormData[$"columns[{columnIndex}][data]"].ToString();

                    if (pageSize > 0)
                    {
                        var prop = getProperty(columName);

                        if (!string.IsNullOrEmpty(searchValue))
                        {
                            return lstElements.Where(m => m.TruckName.IndexOf(searchValue) > 0).ToList();
                        }

                        if (sortDirection == "asc")
                        {
                            return lstElements.OrderBy(prop.GetValue).Skip(skip)
                                .Take(pageSize).ToList();
                        }
                        else
                            return lstElements.OrderByDescending(prop.GetValue)
                                .Skip(skip).Take(pageSize).ToList();
                    }
                    else
                        return lstElements;
                }
            }
            return null;
        }

        private PropertyInfo getProperty(string name)
        {
            var properties = typeof(Truck).GetProperties();
            PropertyInfo prop = null;
            foreach (var item in properties)
            {
                if (item.Name.ToLower().Equals(name.ToLower()))
                {
                    prop = item;
                    break;
                }
            }
            return prop;
        }

        [HttpPost]
        public ResultView Maintain([FromBody] Truck TruckParameter)
        {
            var result = _truckService.Maintain(TruckParameter);

            return result;
        }

        [HttpPost]
        public bool Delete([FromBody] int truckId)
        {
            return _truckService.DeleteTruckById(truckId);
        }

        [HttpPost]
        public Truck SelectTruckByTruckId([FromBody] int truckId)
        {
            Truck truckData = new Truck();

            if (truckId != 0)
                truckData = _truckService.LoadTruckById(truckId);

            return truckData;
        }
    }
}