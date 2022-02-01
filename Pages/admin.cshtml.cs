using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test_4._0.Data;
using Test_4._0.Data.Model;

namespace TrainDEv.Pages
{
    public class adminModel : PageModel
    {
        private readonly IDapperRepository<PrivacyUser> _userDapperRepository;
        private readonly IDapperRepository<Trainee> _traineeDapperRepository;
        private readonly IDapperRepository<Trainer> _trainerDapperRepository;
        public adminModel(IDapperRepository<PrivacyUser> userDapperRepository, IDapperRepository<Trainee> traineeDapperRepository, IDapperRepository<Trainer> trainerDapperRepository)
        {
            _userDapperRepository = userDapperRepository;
            _traineeDapperRepository = traineeDapperRepository;
            _trainerDapperRepository = trainerDapperRepository;
        }
        [BindProperty]
        public List<PrivacyUser> UserList { get; set; }
        public void OnGet()
        {
            UserList = _userDapperRepository.GetAll().Where(x => x.Username != "admin").ToList();
        }
        public IActionResult OnPostDeleteUser([FromBody] dynamic my)
        {
            string sql = "select * from PrivacyUser where Id=" + my;
            var privacyUser = _userDapperRepository.Query<PrivacyUser>(sql, null).FirstOrDefault();
            if (privacyUser != null)
            {
                _userDapperRepository.Delete(privacyUser);
                if (privacyUser.UserType == "Trainer")
                {
                    Trainer trainer = new Trainer() { Id = privacyUser.FKId };
                    _trainerDapperRepository.Delete(trainer);

                }
                else
                {
                    Trainee trainee = new Trainee() { Id = privacyUser.FKId };
                    _traineeDapperRepository.Delete(trainee);
                }
            }

            var mes = "Delete successfully";
            return new JsonResult(new { Mes = mes });
        }
    }
}
