using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using rdp.Data.Context;
using rdp.Data.Entities;
using rdp.Data.Interfaces;
using rdp.Data.Mapping;
using rdp.Data.Mapping.Abstract;
using rdp.Data.Repositories;
using rdp.Data.Uow;
using rdp.Models;

namespace rdp.Controllers;

public class HomeController : Controller
{
    private readonly IUow _uow;
    private readonly IUserMapper _userMapper;

    public HomeController( IUserMapper userMapper, IUow uow)
    {
        
        _userMapper = userMapper;
        _uow = uow;
    }


    public IActionResult Index()
    {
        
        var List = _userMapper.MapToUserList(_uow.GetRepository<ApplicationUser>().GetAll());
        return View(List);
    }

    public IActionResult Privacy()
    {

        var model = _userMapper.MapToUserList(_uow.GetRepository<ApplicationUser>().GetAll());
        return View(model);
    }

    [HttpGet]
    public IActionResult CreateUser(){

        return View();
    }

    [HttpPost]
    public IActionResult CreateUser(UserCreateModel User){
        _uow.GetRepository<ApplicationUser>().Create(new(){
            Name=User.Name,
            SurName=User.SurName
        });
        _uow.SaveChanges();
        return RedirectToAction("Privacy");
    }


    public IActionResult AccountList()
    {
        var list = _uow.GetRepository<Account>().GetAll();

        List<ListModel> listModel = list.Select(x => new ListModel(){
            ListAccount = _uow.GetRepository<Account>().GetById(x.Id),
            ListapplicationUser = _uow.GetRepository<ApplicationUser>().GetById(x.ApplicationUserId)
            
        }).ToList();
        return View(listModel); 
        // Query ile bunu zaten kolay bir şekilde yapabiliyoruz asagidaki kodda ne kadar kolay bir şekilde oldugu gozukuyor zaten 
    }



        public IActionResult AccountListQuery()
    {
        var list = _uow.GetRepository<Account>().GetQueryable().Include(x=>x.ApplicationUser).ToList();
        
        // Auto Mapper ogrendikten sonra dtolar dondureceğiz 
        return View(list);
    }

}