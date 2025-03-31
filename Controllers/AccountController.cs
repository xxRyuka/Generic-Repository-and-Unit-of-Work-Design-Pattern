using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using rdp.Data.Context;
using rdp.Data.Entities;
using rdp.Data.Interfaces;
using rdp.Data.Mapping.Abstract;
using rdp.Data.Repositories;
using rdp.Data.Uow;
using rdp.Models;

namespace rdp.Controllers;

public class AccountController : Controller
{
    // Account Mapper yazalim

    private readonly IAccountMapper _accountMapper;
    private readonly IUow _uow;
    // private readonly IGenericRepository<Account> _genericRepositoryAccount;
    // private readonly IGenericRepository<ApplicationUser> _genericRepositoryUser;
    // private readonly IAccountRepository _accountRepository;
    // private readonly IApplicationUserRepository _applicationUserRepository;

    public AccountController( IAccountMapper accountMapper, IUow uow)
    {
        // _applicationUserRepository = applicationUser;
        // _accountRepository = accountRepository;
        _accountMapper = accountMapper;
        // _genericRepositoryAccount = genericRepositoryAccount;
        // _genericRepositoryUser = genericRepositoryUser;
        _uow = uow;
    }
    // GET
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create(int id)
    {
        var entity = _uow.GetRepository<ApplicationUser>().GetById(id);
        return View(entity);
    }

    [HttpPost]
    public IActionResult Create(AccountViewModel accountViewModel)
    {
        var account = _accountMapper.MapToAccount(accountViewModel);
        _uow.GetRepository<Account>().Create(account);
        _uow.SaveChanges();
        return RedirectToAction("GetByUserId",new { userId = accountViewModel.ApplicationUserId });
    }

    public IActionResult GetByUserId(int userId)
    {
        var query = _uow.GetRepository<Account>().GetQueryable(); 
        var accounts = query.Where(x => x.ApplicationUserId == userId).ToList();

        var user = _uow.GetRepository<ApplicationUser>().GetById(userId);
        ViewBag.FullName= $"{user!.Name} {user.SurName} ";
        List<AccountListModel> accountListModels = new List<AccountListModel>();
        foreach (var item in accounts)
        {
            accountListModels.Add(new()
                {
                    AccountNumber=item.AccountNumber,
                    Balance=item.Balance,
                    ApplicationUserId=item.ApplicationUserId,
                    Id=item.Id                    
                }
            );
        }
        

        return View(accountListModels);
    }

    [HttpGet]
    public IActionResult SendMoney(int accountId){
        var query = _uow.GetRepository<Account>().GetQueryable();
        var accounts = query.Where(x=> x.Id!=accountId).ToList();


        var accountListModels = new List<AccountListModel>();
        foreach (var item in accounts)
        {

            var Accuser = _uow.GetRepository<ApplicationUser>().GetQueryable()
        .Include(x=>x.Accounts).FirstOrDefault(x=>x.Accounts.Any(k=>k.Id==item.Id));
        // Linq onemli aga dondurdugu deger tiplerini iyi bilmek gerekiyor kompleks sorgularda cok onemli
            accountListModels.Add(new(){
               AccountNumber=item.AccountNumber,
               ApplicationUserId=item.ApplicationUserId,
               Balance=item.Balance,
               Id=item.Id,
               selectListInfo = item.ApplicationUser.Name +" " +item.AccountNumber
            });
        }
        var senderUser =_uow.GetRepository<ApplicationUser>()
                        .GetQueryable()
                        .Include(x=>x.Accounts)
                        .FirstOrDefault(x=>x.Accounts.Any(m=>m.Id==accountId));
                        
        ViewBag.SenderName=senderUser.Name;
        ViewBag.SenderAccount=_uow.GetRepository<Account>().GetById(accountId).AccountNumber;
        ViewBag.SenderId = accountId; 
        var selectList = new SelectList(accountListModels,"Id","selectListInfo");
        return View(selectList);
    }
    [HttpPost]
    public IActionResult SendMoney(SendMoneyModel model)
    {
        var sender = _uow.GetRepository<Account>().GetById(model.SenderId);
        var Amount = model.Amount;
        sender.Balance -=Amount;

        var account = _uow.GetRepository<Account>().GetById(model.AccountId);
        account.Balance+=Amount;

        _uow.SaveChanges();
        
        return RedirectToAction("feedback",model);
    }

    public IActionResult Feedback(SendMoneyModel model)
    {
        var senderAccount = _uow.GetRepository<Account>().GetById(model.SenderId);
 
        var senderUser = _uow.GetRepository<ApplicationUser>().GetById(senderAccount!.ApplicationUserId);
        
        var Amount = model.Amount;

        var recipientAccount = _uow.GetRepository<Account>().GetById(model.AccountId);
        var recipientUser = _uow.GetRepository<ApplicationUser>().GetById(senderAccount.ApplicationUserId);

        FeedbackViewModel viewModel = new(){
        SenderAccount=senderAccount,
        Amount=Amount,
        SenderUser=senderUser,
        RecipientAccount=recipientAccount,
        RecipientUser=recipientUser

        };
        return View(viewModel);
    }
}