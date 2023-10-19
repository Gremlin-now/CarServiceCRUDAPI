﻿using Microsoft.AspNetCore.Mvc;

namespace CarServiceCRUDAPI.Controllers
{
    [ApiController]
    [Route("api/")]
    public class ClientController : Controller
    {
        [HttpGet("client{clientId}/getClientInfo")]
        public ActionResult GetClient(int clientId)
        {
            try
            {
                return Ok(Storage.Clients[clientId]);
            }catch
            {
                return BadRequest("Клиент не найден");
            }
        }
        [HttpPost("clients/add")]
        public ActionResult PostClient(Client client)
        {
            Storage.Clients.Add(client);
            return Ok("Клиент успешно добавлен!");
        }
        [HttpPut("client{clientId}/update")]
        public ActionResult UpdateClient(int clientId, Client client)
        {
            try
            {

                Storage.Clients[clientId] = client;
                return Ok("Данные о клиенте успешно обновлены!");
            }catch
            {
                return BadRequest("Клиент не найден!");
            }
        }
        [HttpDelete("client{clientId}/delete")]
        public ActionResult DeleteClient(int clientId)
        {
            try
            {
                Storage.Clients.RemoveAt(clientId);
                return Ok("Данные о клиенте успешно удалены!");
            }
            catch
            {
                return BadRequest("Клиент не найден!");
            }
        }
        [HttpGet("client{clientId}/getAllCars")]
        public ActionResult GetAllCars(int clientId)
        {
            try
            {
                return Ok(Storage.Clients[clientId].Cars);
            }
            catch
            {
                return BadRequest("Клиент не найден!");
            }
        }
        [HttpGet("client{clientId}/getAllOrders")]
        public ActionResult GetAllOrders(int clientId)
        {
            try
            {
                return Ok(Storage.Clients[clientId].Orders);
            }
            catch
            {
                return BadRequest("Клиент не найден!");
            }
        }
    }
}
