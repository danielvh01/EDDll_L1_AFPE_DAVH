using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDDll_L1_AFPE_DAVH.Models.Data;
using EDDll_L1_AFPE_DAVH.Models;
using DataStructures;
using Microsoft.AspNetCore.Http;
using System.IO;
using Newtonsoft.Json;//Libreria usada para generar JSON en un formato especifico.
//COMMENT

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EDDll_L1_AFPE_DAVH.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
       //POST: api/<MovieController>/populate
       [HttpPost("populate")]
        public async Task<IActionResult> Post()
        {
            if (Singleton.Instance.tree != null)
            {
                try
                {
                    StreamReader reader = new StreamReader(Request.Body);
                    string content = await reader.ReadToEndAsync();
                    MovieModel[] Movies = JsonConvert.DeserializeObject<MovieModel[]>(content);
                    foreach (MovieModel movie in Movies)
                    {
                        Singleton.Instance.tree.Insert(movie);
                    }
                    return Ok();
                }
                catch
                {
                    return StatusCode(500);
                }
            }
            else
            {
                return StatusCode(500);
            }
        }

        //DELETE: api/<MovieController>/populate
        [HttpDelete("populate/{id}")]
        public ActionResult Delete(string id)
        {
            if (Singleton.Instance.tree != null && id != null && id != "")
            {
                var node = Singleton.Instance.tree.search(x => x.Title.CompareTo(id));
                if (node != null)
                {
                    Singleton.Instance.tree.Remove(node);
                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return StatusCode(500);
            }
        }


        // GET api/<MovieController>/5
        [HttpGet("{traversal}")]
        public ActionResult Get(string traversal)
        {
            if (Singleton.Instance.tree != null && traversal != "" && traversal != null)
            {
                string JSONresult = "";
                DataStructures.DoubleLinkedList<MovieModel> list;
                if (traversal == "inOrder")
                {
                    
                    list = Singleton.Instance.tree.inOrder();
                    JSONresult = JsonConvert.SerializeObject(list.GetEnumerator());
                    JSONresult = JSONresult.Substring(13, JSONresult.Length - 14);
                    return Ok(JSONresult);   
                }
                if (traversal == "preOrder")
                {
                    list = Singleton.Instance.tree.preOrder();
                    JSONresult = JsonConvert.SerializeObject(list.GetEnumerator());
                    JSONresult = JSONresult.Substring(13, JSONresult.Length - 14);
                    return Ok(JSONresult);
                }
                if (traversal == "postOrder")
                {
                    list = Singleton.Instance.tree.postOrder();
                    JSONresult = JsonConvert.SerializeObject(list.GetEnumerator());
                    JSONresult = JSONresult.Substring(13, JSONresult.Length - 14);
                    return Ok(JSONresult);
                }
                else
                {
                    return StatusCode(500);;
                }
            }
            
            else {
                return StatusCode(500);;
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
                return StatusCode(500);;
            }
        }


        // DELETE api/<MovieController>/5
        [HttpDelete]
        public void Delete()
        {
            Singleton.Instance.tree = null;
        }
    }
}
