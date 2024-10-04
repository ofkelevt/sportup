﻿                                                                                                              
using sportup.Models;
using sportup.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Humanizer;


namespace sportup.Controllers
{
    [Route("api")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //a variable to hold a reference to the db context!

        private LoginDemoDbContext context;

        //Use dependency injection to get the db context intot he constructor



        public LoginController(LoginDemoDbContext context)
        {
            this.context = context;
        }

        // POST api/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] DTO.LoginInfo loginDto)
        {
            try
            {
                HttpContext.Session.Clear(); //Logout any previous login attempt

                //Get model user class from DB with matching email. 

                Models.User modelsUser = context.GetUSerFromDB(loginDto.UserId);

                //Check if user exist for this email and if password match, if not return Access Denied (Error 403) 
                if (modelsUser == null || modelsUser.Password != loginDto.Password)
                {
                    return Unauthorized("user or password not valid/user not exists");
                }

                //Login suceed! now mark login in session memory!
                HttpContext.Session.SetString("loggedInUser", $"{modelsUser.UserId}");

                return Ok(new DTO.UserDTO(modelsUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }



        // Get api/check
        [HttpGet("check")]
        public IActionResult Check()
        {
            try
            {
                //Check if user is logged in 
                string userId = HttpContext.Session.GetString("loggedInUser");

                if (string.IsNullOrEmpty(userId))
                {
                    return Unauthorized("User is not logged in");
                }


                //user is logged in - lets check who is the user
                Models.User modelsUser = context.GetUSerFromDB(int.Parse(userId));

                return Ok(new DTO.UserDTO(modelsUser));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


    }
}
