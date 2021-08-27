using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDDll_L1_AFPE_DAVH.Models.Data;
using EDDll_L1_AFPE_DAVH.Models;
using DataStructures;
using Newtonsoft.Json;//Libreria usada para generar JSON en un formato especifico.
//COMMENT

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDDll_L1_AFPE_DAVH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        // GET: api/<MovieController>
        [HttpGet]
        

        // GET api/<MovieController>/5
        [HttpGet("{traversal}")]
        public ActionResult Get(string traversal)
        {
            if (Singleton.Instance.tree != null && traversal != "" && traversal != null)
            {
                if (traversal == "inOrder")
                {
                    string JSONresultinO = "";
                    DataStructures.DoubleLinkedList<MovieModel> list = Singleton.Instance.tree.traverse();
                    for (int i = 0; i < list.Length; i++)
                    {
                        MovieModel result = list.Get(i);
                        JSONresultinO += JsonConvert.SerializeObject(result, Formatting.Indented);
                    }
                    return Ok(JSONresultinO);
                }
                if (traversal == "preOrder")
                {
                    string JSONresultPRO = "";
                    return Ok(JSONresultPRO);
                }
                if (traversal == "postOrder")
                {
                    string JSONresultPO = "";
                    return Ok(JSONresultPO);
                }
                else
                {
                    return BadRequest();
                }
            }
            
            else {
                return BadRequest();
            }
            
        }

        // POST api/<MovieController>
        [HttpPost]
        public ActionResult Post([FromBody]  TreeDegree degree)
        {      
            
            if (Singleton.Instance.tree == null && degree.TreeD >= 3 && degree.TreeD % 2 == 1)
            {
                Singleton.Instance.TDegree = degree.TreeD;
                Singleton.Instance.tree = new B_Tree<MovieModel>(degree.TreeD);
                return Ok();
            }
            else {
                return BadRequest();
            }
        }

        // PUT api/<MovieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<MovieController>/5
        [HttpDelete]
        public void Delete()
        {
            Singleton.Instance.tree = new B_Tree<MovieModel>(0);
        }
    }
}
