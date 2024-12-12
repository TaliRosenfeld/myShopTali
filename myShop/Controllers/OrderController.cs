﻿using Microsoft.AspNetCore.Mvc;
using Services;
using Entities;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace myShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        IOrderServices orderService;
        IMapper _mapper;
        public OrderController(IOrderServices IOrderServices, IMapper mapper)
        {
            orderService=IOrderServices;
            _mapper = mapper;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public async Task<OrderDTO> Get(int id)
        {
            Order order = await orderService.getOrderById(id);
            OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
            return orderDTO;
        }

        // POST api/<OrderController>
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] Order newOrder)
        {
            try
            {
                await orderService.addOrder(newOrder);
                return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, newOrder);
            }catch(Exception ex)
            {
                throw new Exception("" + ex);
            }
            //Order order = await orderService.addOrder(newOrder);
            //OrderDTO orderDTO = _mapper.Map<Order, OrderDTO>(order);
            //return CreatedAtAction(nameof(Get), new { id = orderDTO.OrderId }, orderDTO);
        }

        // PUT api/<OrderController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<OrderController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
