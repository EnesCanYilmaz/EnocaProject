using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using EnocaProject.DataAccess.Contexts;
using EnocaProject.Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EnocaProject.API.Controllers
{
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        [HttpPost]
        public ActionResult<string> CreateOrder([FromBody] Order order)
        {
            using (var context = new EnocaProjectDbContext())
            {
                var carriers = context.Carriers.Include(c => c.CarrierConfigurations).ToList();


                var selectedCarrier = carriers.Where(c => c.CarrierConfigurations.Any(cfg => order.OrderDesi >= cfg.CarrierMinDesi && order.OrderDesi <= cfg.CarrierMaxDesi)).
                    OrderBy(c => c.CarrierConfigurations.First(cfg => order.OrderDesi >= cfg.CarrierMinDesi && order.OrderDesi <= cfg.CarrierMaxDesi).CarrierCost).FirstOrDefault();
                string response;
                if (selectedCarrier == null)
                {
                    var nearestCarrierConfig = context.CarrierConfigurations
                        .Where(cfg => cfg.CarrierMinDesi <= order.OrderDesi)
                        .OrderBy(cfg => cfg.CarrierCost)
                        .FirstOrDefault();

                    if (nearestCarrierConfig != null)
                    {
                        var carrier = context.Carriers.Find(nearestCarrierConfig.CarrierId);
                        var price = nearestCarrierConfig.CarrierCost + ((order.OrderDesi - nearestCarrierConfig.CarrierMaxDesi) * carrier.CarrierPlusDesiCost);
                        response = $"En uygun taşıyıcı {carrier.CarrierName} ve fiyatı {price} ₺.";

                        order.OrderCarrierCost = price;
                        order.CarrierId = nearestCarrierConfig.CarrierId;
                    }
                    else
                    {
                        response = $"Taşıyıcı bulunamadı";
                    }
                }
                else
                {
                    var selectedCarrierConfig = selectedCarrier.CarrierConfigurations.First(cfg => order.OrderDesi >= cfg.CarrierMinDesi && order.OrderDesi <= cfg.CarrierMaxDesi);
                    var carrier = context.Carriers.Find(selectedCarrierConfig.CarrierId);
                    var price = selectedCarrierConfig.CarrierCost + ((order.OrderDesi - selectedCarrierConfig.CarrierMaxDesi) * carrier.CarrierPlusDesiCost);
                    response = $"En uygun taşıyıcı {carrier.CarrierName} ve fiyatı {price} ₺.";
                    order.OrderCarrierCost = price;
                    order.CarrierId = selectedCarrier.Id;
                }

                order.OrderDate = DateTime.Now;

                context.Orders.Add(order);
                context.SaveChanges();

                return response;
            }
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteOrder(int id)
        {
            using (var context = new EnocaProjectDbContext())
            {
                var order = context.Orders.Find(id);
                if (order == null)
                {
                    return NotFound();
                }

                context.Orders.Remove(order);
                context.SaveChanges();

                return NoContent();
            }
        }

    }
}