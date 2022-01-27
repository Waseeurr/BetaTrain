using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_4._0.Data;
using Test_4._0.Data.Model;

namespace Test_4._0.Pages
{
    public class trainer_profile_editModel : PageModel
    {
        private readonly IDapperRepository<Trainer> _trainerDapperRepository;
        private readonly IDapperRepository<PrivacyUser> _userDapperRepository;
        public trainer_profile_editModel(IDapperRepository<Trainer> trainerDapperRepository, IDapperRepository<PrivacyUser> userDapperRepository)
        {
            _trainerDapperRepository = trainerDapperRepository;
            _userDapperRepository = userDapperRepository;

        }
        [BindProperty]
        public Trainer Trainer { get; set; }

        [BindProperty]
        public PrivacyUser User { get; set; }
        public void OnGet()
        {
            var value = HttpContext.Session.GetString("UserId");
            if (!string.IsNullOrEmpty(value))
            {
                string sqlUser = "select * from PrivacyUser where FKId=  " + value;
                var privacyUser = _userDapperRepository.Query<PrivacyUser>(sqlUser, null)?.FirstOrDefault();
                if (privacyUser != null)
                {
                    User = privacyUser;
                }
                string sql = "select * from Trainer where Id=  " + value;
                var trainer = _trainerDapperRepository.Query<Trainer>(sql, null)?.FirstOrDefault();
                if (trainer != null)
                {
                    Trainer = trainer;
                }
            }
        }
        public IActionResult OnPostSave()
        {
            string sql = "update PrivacyUser set UserName='" + User.Username + "' where Id= " + User.Id;
            _userDapperRepository.Execute(sql);
            string sqlTrainer = "update Trainer set Gender='"+ Trainer .Gender+ "',KindOfTrainer='"+ Trainer.KindOfTrainer+ "',TeachingType='"+ Trainer.TeachingType+ "',DescribeYourself='"+Trainer.DescribeYourself+"' where id="+Trainer.Id;
            var traineeId = _trainerDapperRepository.Execute(sqlTrainer);
            if (traineeId>0)
            {
                return RedirectToPage("trainer_profile");
            }
            else
            {
                TempData["Message"] = "save failed, please contact the administrator";
                return Page();
            }
        }
    }
}
