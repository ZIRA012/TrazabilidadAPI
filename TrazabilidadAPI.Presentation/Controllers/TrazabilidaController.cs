using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TrazabilidadAPI.Application.DTOs;
using TrazabilidadAPI.Application.Interfaces;
using TrazabilidadAPI.Domain.Entities;
using TrazabilidadAPI.Infrastructure.Repositories;
using TrazabilidadAPI.SharedLibraries.OperationResults;

namespace TrazabilidadAPI.Presentation.Controllers
{   //Controller Que Implementa las 4 tareas Pedidas en la Prueba
    //NOTA: Lo mejor Seria Tener diferentes controllers para cada Repositorio, pero para facilitar el Uso se inyecta todos los repositorios
    //A este CONTROLLER
    [Route("api/[controller]")]
    [ApiController]
    public class TrazabilidadController
        (IProcedureRepository procedureRepository, IDataSetRepository dataSetRepository,
        IUserRepository userRepository,IConfiguration config) : ControllerBase
    {

        //TAREA 1.- Obtener todos los DataSets asociados a un UserID específico a través de los Procedimientos que ha creado o modificado
        [HttpGet("user/{userId}/datasets")]
        public async Task<IActionResult> GetDataSetsByUser(int userId)
        {
            var result = await procedureRepository.GetDataSetsByUserIdAsync(userId);

            return result.Any()
                ? Ok(result)
                : NotFound($"No se encontraron DataSets para el usuario con ID {userId}");
        }


        //TAREA 2.-Crea un nuevo DataSet y asociarlo a un Procedure existente y a un Field específico
        [HttpPost("datasets")]
        public async Task<IActionResult> CreateDataSet([FromBody] CreateDataSetDTO dto)
        {
            var result = await dataSetRepository.CreateAsync(dto);

            return result.Flag
                ? Ok("DataSet creado correctamente.")
                : BadRequest(result.Message);
        }


        //TAREA 3.- 3.	Obtener todos los DataSets de un Procedure con el tipo de Field
        [HttpGet("procedures/{procedureId}/datasets")]
        public async Task<IActionResult> GetDataSetsByProcedure(int procedureId)
        {
            var result = await dataSetRepository.GetByProcedureIdWithFieldAsync(procedureId);

            return result.Any()
                ? Ok(result)
                : NotFound($"No se encontraron DataSets para el ProcedureID {procedureId}");
        }



        //TAREA 4.- Crear un Procedure con autorización de rol Admin

            //Usar el Endpoint de Login con la credendecia de Admin:  admin@example.com  admin123      
            //CreateProcedure.- Crea el Procedimiento solo si la peticion lleva un JWT con permiso Admin

     
        [Authorize(Roles = "Admin")]
        [HttpPost("procedures")]
        public async Task<IActionResult> CreateProcedure([FromBody] CreateProcedureDTO dto)
        {
            int userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);
            var procedure = new Procedure
            {
                ProcedureName = dto.ProcedureName,
                Description = dto.Description,
                CreatedByUserID = userId,
                CreatedDate = DateTime.UtcNow
            };

            var result = await procedureRepository.CreateAsync(procedure);

            return result.Flag ? Ok(result.Message) : BadRequest(result.Message);
        }

        //ATENCION: Se hizo el Login Sin Hash Por que en la base de datos venia sin Hash, se debe hacer Hash de las claves el usuario
        [HttpPost("login")]
        public async Task<ActionResult<OpertaionResult>> Login(LoginDTO login)
        {
            if (!ModelState.IsValid)
                return BadRequest("Se espera un correo y un Password");

            var user = await userRepository.GetUserWithRolesAsync(login);

            if (user == null) return BadRequest("Credenciales Incorrectas");

            var token = GenerateToken(user);

            return Ok(new OpertaionResult(true, token));

        }

        //////////////////////Authenticacion////////////////////////////////////////////////////////
        private String GenerateToken(User user)
        {
            var key = Encoding.UTF8.GetBytes(config.GetSection("Authentication:Key").Value!);
            var securityKet = new SymmetricSecurityKey(key);
            var credential = new SigningCredentials(securityKet, SecurityAlgorithms.HmacSha256);

            var role = user.UserRoles.FirstOrDefault()?.Role.RoleName;
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.Username!),
                new(ClaimTypes.Email, user.Email!),
                new(ClaimTypes.Role,role!),
                new(ClaimTypes.NameIdentifier,user.UserID.ToString())
            };

            var token = new JwtSecurityToken(
            issuer: config["Authentication:Issuer"],
            audience: config["Authentication:Audience"],
            claims: claims,
            expires: null,
            signingCredentials: credential
            );
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }


}
