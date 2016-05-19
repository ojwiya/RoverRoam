using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Api.Controllers
{
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class RoverController : ApiController
    {
        private readonly IRoverService _roverService;

        public RoverController(IRoverService roverService) {
            _roverService = roverService;
        }


        /// <summary>
        /// Search for restaurants by postcode(outcode).
        /// </summary>
        /// <param name="outcode"></param>
        /// <returns></returns>
        [Route("api/rover/roam")]
        public HttpResponseMessage Roam(string plateauSize, Instruction[] instructions)
        {

          string[] roverFinalPosition = _roverService.Roam(plateauSize,instructions);

            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, roverFinalPosition);
            return response;
            
        }

    }
}
