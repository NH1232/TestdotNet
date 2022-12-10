using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis;
using RegisterUser.DataDB;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace RegisterUser.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {


        private readonly ILogger<UserController> _logger;
        RegisterUserContext ctx = new RegisterUserContext();
        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("registeruser")]
        public string RegisterUser(string firstName, string lastName, int age, string gender, string email, string phone, string password, DateTime birthDate)
        {
            Random generator = new Random();
            var u = ctx.Users.Where(x => x.Email.ToLower() == email.ToLower()).ToList();
            if (u.Any())
            {
                return "Fail";
            }
            User user = new User()
            {
                FirstName = firstName,
                LastName = lastName,
                Age = age,
                Gender = gender,
                Email = email,
                Phone = phone,
                Password = password,
                BirthDate=birthDate,
                Otp = generator.Next(0, 1000000).ToString("D6"),
                Confirm = 0

            };
            if (!String.IsNullOrEmpty(email))
            {

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("hungnv.test97@gmail.com");
                msg.To.Add(email);
                msg.Subject = "OTP Register User";
                msg.Body = "OTP: " + user.Otp;
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.Port = 587;
                smtpClient.Host = "smtp.gmail.com";
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new NetworkCredential("hungnv.test97@gmail.com", "yvtuxeiunaiqnbyv");
                smtpClient.Send(msg);
                ctx.Users.Add(user);
                ctx.SaveChanges();
                return "Success";
            }
            return "Fail";
        }

        [HttpPut]
        [Route("registeruser")]
        public string ConfirmMail(string email, string code)
        {
            var user=ctx.Users.Where(x => x.Email.ToLower()==email.ToLower() && x.Otp ==code).ToList();
            if (user.Any())
            {
                user[0].Confirm = 1;
                ctx.Users.Update(user[0]);
                ctx.SaveChanges();
                return "Sucess";
            }

            return "The code you just entered is incorrect";
        }
    }
}