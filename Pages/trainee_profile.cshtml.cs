using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_4._0.Data;
using Test_4._0.Data.Model;

namespace TrainDEv.Pages
{
    public class trainee_profileModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IDapperRepository<Trainee> _traineeDapperRepository;
        private readonly IDapperRepository<PrivacyUser> _userDapperRepository;
        private readonly IDapperRepository<Linked> _linkedDapperRepository;
        public trainee_profileModel(IDapperRepository<Trainee> traineeDapperRepository, IDapperRepository<PrivacyUser> userDapperRepository, IWebHostEnvironment webHostEnvironment, IDapperRepository<Linked> linkedDapperRepository)
        {
            _traineeDapperRepository = traineeDapperRepository;
            _userDapperRepository = userDapperRepository;
            _webHostEnvironment = webHostEnvironment;
            _linkedDapperRepository = linkedDapperRepository;
        }
        [BindProperty]
        public Trainee Trainee { get; set; }

        [BindProperty]
        public PrivacyUser User { get; set; }

        [BindProperty]
        public List<Trainer> Trainers { get; set; }
        public void OnGet()
        {
            /*var value = HttpContext.Session.GetString("UserId");*/
            var value = Request.Query["Id"];
            if (string.IsNullOrEmpty(value))
            {
                value = HttpContext.Session.GetString("UserId");
            }
            if (!string.IsNullOrEmpty(value))
            {
                string sqlUser = "select * from PrivacyUser where FKId=  " + value;
                var privacyUser = _traineeDapperRepository.Query<PrivacyUser>(sqlUser, null)?.FirstOrDefault();
                if (privacyUser != null)
                {
                    User = privacyUser;
                }
                string sql = "select * from Trainee where Id=  " + value;
                var trainee = _traineeDapperRepository.Query<Trainee>(sql, null)?.FirstOrDefault();
                if (trainee != null)
                {
                    Trainee = trainee;
                }
                string sqlLiked = @"select t.* from dbo.Linked l
                                    LEFT JOIN dbo.Trainer t ON l.TrainerId=t.Id 
                                    WHERE Status=1 and TraineeId=  " + value;
                Trainers = _linkedDapperRepository.Query<Trainer>(sqlLiked, null).ToList();
            }
        }
    }
}
