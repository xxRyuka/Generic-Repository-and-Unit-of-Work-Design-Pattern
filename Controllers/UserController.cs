using Microsoft.AspNetCore.Mvc;
using rdp.Data.Entities;
using rdp.Data.Mapping.Abstract;
using rdp.Data.Uow;
using rdp.Models;

namespace rdp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserMapper _userMapper;
        private readonly IUow _uow;

        public UserController(IUow uow, IUserMapper userMapper)
        {
            _uow = uow;
            _userMapper = userMapper;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var entity = _uow.GetRepository<ApplicationUser>().GetById(id);
            UserListModel user = new();
            _userMapper.MapToUserModel(entity, user);

            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(UserListModel model)
        {
            var user = _uow.GetRepository<ApplicationUser>().GetById(model.Id);
            var entity = _userMapper.MapToUser(model, user);

            _uow.GetRepository<ApplicationUser>().Update(entity);
            _uow.SaveChanges();
            return RedirectToAction("Privacy", "Home");
        }

        [HttpPost]
        public IActionResult Remove(int id)
        {
            var entity = _uow.GetRepository<ApplicationUser>().GetById(id);
            if (entity == null)
            {
                return NotFound();
            }

            _uow.GetRepository<ApplicationUser>().Remove(entity);
            _uow.SaveChanges();

            return RedirectToAction("Privacy", "Home");
        }


    }
}
