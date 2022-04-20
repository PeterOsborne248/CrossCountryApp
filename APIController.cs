using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrossCountryApp.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Data.SqlClient;

namespace CrossCountryApp.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class APIController : ControllerBase
    {

        private readonly dbContextParticipantData _context;

        public APIController(dbContextParticipantData context)
        {
            _context = context;
        }



        // GET: api/API
        [HttpGet]
        public string Get()
        {
            return "Default Path api/API";
        }

        // GET: api/API/5
        // Uses the default path but has an id in the path
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value:" + id.ToString();
        }

        // GET: api/API/5/10
        // Uses the default path but has an id in the path
        [HttpGet("{id}/{myid}", Name = "GetMyId")]
        public string GetMyId(int id, int myid)
        {
            return "value:" + id.ToString() + " my Value:" + myid.ToString();
        }

        // GET: api/API/LoadData
        // Uses the default path but has an id in the path
        [HttpGet("LoadData", Name = "GetLoadData")]
        public IList<Participant> GetLoadData()
        {

            SeedData seedData = new();
            return seedData.Seeds;
        }

        [HttpGet("ReceiveData/{id}/{studentid}/{eventid}/{finishtime}/{place}", Name = "GetReceiveData")]
        public async Task<Participant> GetReceiveData(int id, int studentid, int eventid, string finishtime, int place)
        {
            Participant myNewParticipant = new Participant();
            myNewParticipant.StudentID = studentid;
            myNewParticipant.EventID = eventid;
            var FINISHTIME = DateTime.Parse(finishtime);
            myNewParticipant.FinishTime = FINISHTIME;// may have issue here
            myNewParticipant.Place = place;

            // load the context of the database

            _context.Participant.Add(myNewParticipant);
            await _context.SaveChangesAsync();

            return myNewParticipant;
        }


        // POST: api/API
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/API/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }



        //---------------------------------> Not Working <---------------------------------------//
        // DELETE: api/API/5
        [HttpDelete("{id}")]
        public string Delete (int id)
        {

            return id.ToString();
        }
    }
}