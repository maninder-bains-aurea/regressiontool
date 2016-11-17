using RegressionBusiness;
using RegressionEntities;
using RegressionUI.Models;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace RegressionUI.Controllers
{
    public class AccountController : BaseController
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            try
            {
                var userinfo = new UserManager().AuthenticateUser(model.UserName);

                if (userinfo == null)
                {
                    ModelState.AddModelError("", "User not found");
                    return View("");
                }
                else if (userinfo.Password != model.Password)
                {
                    ModelState.AddModelError("", "Incorrect credentials");
                    return View();
                }
                else if (userinfo.Password == model.Password)
                {
                    UserName = userinfo.UserName;
                    UserID = userinfo.Id;

                    // Create a new ticket used for authentication
                    FormsAuthenticationTicket ticket
                        = new FormsAuthenticationTicket(1, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(30),
                            true, "administrator", FormsAuthentication.FormsCookiePath);

                    // Encrypt the cookie using the machine key for secure transport
                    string hash = FormsAuthentication.Encrypt(ticket);
                    HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);

                    // Set the cookie's expiration time to the tickets expiration time
                    if (ticket.IsPersistent) cookie.Expires = ticket.Expiration;

                    // Add the cookie to the list for outgoing response
                    Response.Cookies.Add(cookie);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Incorrect credentials");
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View("");
            }
        }

        public ActionResult Logoff()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

//try
//{
//    using (var client = new HttpClient())
//    {
//        var form = new Dictionary<string, string> {
//               {"grant_type", "password"},
//               {"username", model.UserName},
//               {"password", model.Password},
//           };

//        client.BaseAddress = new Uri(BaseAddress);
//        client.DefaultRequestHeaders.Accept.Clear();
//        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//        var tokenResponse = client.PostAsync("/token", new FormUrlEncodedContent(form)).Result;

//        var token = tokenResponse.Content.ReadAsAsync<Token>(new[] { new JsonMediaTypeFormatter() }).Result;

//        if (string.IsNullOrEmpty(token.Error))
//            BearerToken = token.AccessToken;
//        else
//            Console.WriteLine("Error : {0}", token.Error);
//    }

//    return RedirectToAction("Index", "Home");
//}
//catch (Exception ex)
//{
//    return RedirectToAction("Login");
//}

//public ActionResult Register()
//{
//    return View();
//}

//[HttpPost]
//public ActionResult Register(UserModel model)
//{
//    try
//    {
//        using (var client = new HttpClient())
//        {
//            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["BaseAddress"]);
//            client.DefaultRequestHeaders.Accept.Clear();
//            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

//            HttpResponseMessage response = client.PostAsJsonAsync("api/account/register", model).Result;
//            if (response.IsSuccessStatusCode)
//            {
//                LoginUser user = response.Content.ReadAsAsync<LoginUser>().Result;

//                if (user != null)
//                {

//                }
//            }
//            else if (response.StatusCode == HttpStatusCode.NotFound)
//            {
//                ModelState.AddModelError(string.Empty, "Invalid User");
//            }
//        }

//        return RedirectToAction("Index");
//    }
//    catch (Exception ex)
//    {
//        return RedirectToAction("Register");
//    }
//}
