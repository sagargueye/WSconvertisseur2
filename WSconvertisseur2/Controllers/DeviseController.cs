using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSconvertisseur2.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WSconvertisseur2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviseController : ControllerBase
    {
        List<Devise> devises;
        public DeviseController()
        {
            devises = new List<Devise>();
            devises.Add(new Devise(1, "dollars", 1.08 ));
            devises.Add(new Devise(2 , "Franc Suisse", 1.07));
            devises.Add(new Devise(3 , "Yen", 120));
        }



        /// <summary>retourne une seule devise. </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        /// <remarks>GetById avec gestion du notfound : on gere le 404</remarks>
        [HttpGet("{id}", Name = "GetDevise")]
        [ProducesResponseType(typeof(Devise), 200)]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            Devise devise = devises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            return Ok(devise);
        }

        /// <summary>retourne une seule devise. </summary>
        /// <returns>Http response</returns>
        /// <param name="id">The id of the currency</param>
        /// <remarks>GetById sans gestion du notfound : on gere le 404</remarks>
        // GET: api/<DeviseController>
        //[HttpGet("{id}", Name = "GetDevise")]
        //public Devise GetById(int id)
        //{
        //    Devise theGoodDevise =
        //    (
        //     from d in devises
        //     where d.Id == id
        //     select d
        //     ).FirstOrDefault();
        //    return theGoodDevise;
        //}


        /// <summary>GET: api/<DeviseController> </summary>
        /// <returns>Retourne toutes les devises</returns>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Devise>), 200)]
        public IEnumerable<Devise> GetAll()
        {
            return devises;
        }



        // POST api/<DeviseController>
        [HttpPost]
        [ProducesResponseType(typeof(Devise), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post([FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        // PUT api/<DeviseController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Devise), 204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Put(int id, [FromBody] Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = devises.FindIndex((d) => d.Id == id);

            if (index < 0)
            {
                return NotFound();
            }
            devises[index] = devise;
            return NoContent();
        }
        // DELETE api/<DeviseController>/5
        [HttpDelete("{id}")]
#pragma warning disable CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement
        public IActionResult Delete(int id)
#pragma warning restore CS1591 // Commentaire XML manquant pour le type ou le membre visible publiquement
        {
            Devise devise = devises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            else
            {
                devises.Remove(devise);
            }
            return Ok(devise);
        }

    }
}
