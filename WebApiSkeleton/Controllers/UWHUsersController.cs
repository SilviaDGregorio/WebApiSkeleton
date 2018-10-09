using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApiSkeleton.Controllers
{
    [Route("api/[controller]")]
    [Authorization]
    [ApiController]
    public class UWHUsersController : ControllerBase
    {
        Models.Interfaces.IUWHUsersModel _uwhUsers;
        public UWHUsersController(Models.Interfaces.IUWHUsersModel uwhUsers){
            _uwhUsers = uwhUsers;
        }

        // GET api/UWHUsers
        [HttpGet]
        [ProducesResponseType(typeof(List<DTO.UWHUsers>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [Route("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _uwhUsers.Get());
        }

        // GET api/UWHUsers/Id
        [HttpGet]
        [ProducesResponseType(typeof(DTO.UWHUsers), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id <= 0)
            {
                return  BadRequest("UWHUser id is not valid");                             
            }
            return Ok(await _uwhUsers.Get(id));
        }

        // POST api/UWHUsers
        [HttpPost]
        [ProducesResponseType(typeof(List<DTO.UWHUsers>), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult>  Post([FromBody] List<DTO.UWHUsers> userList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _uwhUsers.Save(userList));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(DTO.UWHUsers), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public async Task<IActionResult>  Put(int id, [FromBody] DTO.UWHUsers user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(await _uwhUsers.Update(id,user));
        }
              // DELETE api/values/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(401)]
        [ProducesResponseType(500)]
        public  async Task<IActionResult> Delete(int id)
        {
            if(id<=0) {
                return BadRequest("UWHUser id is not valid");
            }
            return Ok(await _uwhUsers.Delete(id));
        }
    }
}
