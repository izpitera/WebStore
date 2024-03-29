﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.ServiceHosting.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static readonly List<string> __Values = Enumerable
            .Range(1, 10)
            .Select(i => $"Value-{i:00}")
            .ToList();

        [HttpGet] // http://localhost:5002/api/values
        public IEnumerable<string> Get() => __Values; // no status codes

        //public ActionResult<IEnumerable<string>> Get() => __Values; // Returns status codes

        [HttpGet("{id}")] // http://localhost:5002/api/values/5
        public ActionResult<string> Get(int id)
        {
            if (id < 0)
                return BadRequest();
            if (id >= __Values.Count)
                return NotFound();
            return __Values[id];
        }

        [HttpPost]                // http://localhost:5002/api/values
        [HttpPost("add")] // http://localhost:5002/api/values/add
        public ActionResult Post([FromBody] string value)
        {
            __Values.Add(value);
            //return Ok();
            return CreatedAtAction(nameof(Get), new {id = __Values.Count - 1});
        }

        [HttpPut("{id}")]      // http://localhost:5002/api/values/5
        [HttpPut("edit/{id}")] // http://localhost:5002/api/values/add/5
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0)
                return BadRequest();
            if (id >= __Values.Count)
                return NotFound();

            __Values[id] = value;

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0)
                return BadRequest();
            if (id >= __Values.Count)
                return NotFound();

            __Values.RemoveAt(id);

            return Ok();
        }
    }
}
