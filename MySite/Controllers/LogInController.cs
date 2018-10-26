using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MySite.Models;
using System.Data.Entity;

namespace MySite.Controllers
{
    public class LogInController : Controller
    {

        //SiteDb db = new SiteDb();
        [HttpGet]
        public ActionResult Autorization()//при первом вызове страницы
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autorization(Users user)
        {
            List<Users> listusers = null;
            try
            {
                listusers = Users.Load();//загружаем список пользвоателей
                foreach(Users item in listusers)
                {
                    if(item.LOGIN== user.LOGIN && item.PASSWORD == user.PASSWORD)
                    {
                        ViewBag.Msg = "";
                        HttpCookie cookie = new HttpCookie("User");//в качестве cookie запоминаем эмаил пользователя
                        cookie.Expires = DateTime.Now.AddDays(31);
                        cookie.Value = item.EMAIL;
                        Response.Cookies.Add(cookie);
                        return RedirectToAction("Index","Home");//возвращаемся к домашней странцие
                    }
                }
                throw new Exception("Неверный логин или пароль");
            }
            catch (Exception exc)
            {
                ViewBag.Msg = exc.Message;
            }
            return View();
        }
    }
}